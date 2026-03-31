using System;
using System.Collections.Generic;
using System.IO;

// PDF
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Fonts;

// Word (OpenXml)
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace AnketaStudenta.Services
{
    // ════════════════════════════════════════════════════════════════════════
    //  Резолвер шрифтов для PDFsharp 6.x
    //
    //  PDFsharp 6.x (в отличие от 1.x) не читает системные шрифты Windows
    //  автоматически — требует явной реализации IFontResolver.
    //  Этот класс сопоставляет имя семейства + стиль с файлом .ttf из
    //  C:\Windows\Fonts и возвращает байты шрифта PDFsharp-у.
    // ════════════════════════════════════════════════════════════════════════
    internal sealed class WindowsFontResolver : IFontResolver
    {
        // Путь к системным шрифтам
        private static readonly string FontsDir =
            Environment.GetFolderPath(Environment.SpecialFolder.Fonts);

        // Таблица: «FaceName» → имя файла в Fonts/
        // FaceName формируется как «FamilyName» + суффикс стиля.
        private static readonly Dictionary<string, string> FontFiles =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Arial",            "arial.ttf"   },
            { "Arial#b",          "arialbd.ttf" },  // Bold
            { "Arial#i",          "ariali.ttf"  },  // Italic
            { "Arial#bi",         "arialbi.ttf" },  // Bold+Italic
            { "Verdana",          "verdana.ttf" },
            { "Verdana#b",        "verdanab.ttf"},
            { "Times New Roman",  "times.ttf"   },
            { "Courier New",      "cour.ttf"    },
        };

        /// <summary>
        /// Возвращает информацию о начертании: PDFsharp вызывает этот метод,
        /// чтобы узнать, под каким именем запрашивать байты шрифта.
        /// </summary>
        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            // Строим суффикс: #b, #i, #bi или пусто
            string suffix = (isBold && isItalic) ? "#bi"
                          : isBold               ? "#b"
                          : isItalic             ? "#i"
                          :                        "";

            string faceName = familyName + suffix;

            // Если точное совпадение есть — используем его
            if (FontFiles.ContainsKey(faceName))
                return new FontResolverInfo(faceName);

            // Иначе откатываемся к базовому начертанию семейства
            return FontFiles.ContainsKey(familyName)
                ? new FontResolverInfo(familyName)
                : new FontResolverInfo("Arial"); // абсолютный fallback
        }

        /// <summary>
        /// Возвращает байты TTF-файла по имени начертания (faceName).
        /// PDFsharp вызывает этот метод после ResolveTypeface.
        /// </summary>
        public byte[] GetFont(string faceName)
        {
            if (FontFiles.TryGetValue(faceName, out string fileName))
            {
                string path = Path.Combine(FontsDir, fileName);
                if (File.Exists(path))
                    return File.ReadAllBytes(path);
            }

            // Крайний fallback — пробуем arial.ttf напрямую
            string arialPath = Path.Combine(FontsDir, "arial.ttf");
            if (File.Exists(arialPath))
                return File.ReadAllBytes(arialPath);

            throw new FileNotFoundException(
                $"Не удалось найти шрифт '{faceName}'. " +
                $"Убедитесь, что Arial установлен в {FontsDir}.");
        }
    }

    /// <summary>
    /// Сервис экспорта анкеты студента в форматы PDF и Word (.docx).
    /// Использует PDFsharp 6.x (установлен) и DocumentFormat.OpenXml.
    /// </summary>
    public static class ExportService
    {
        // Флаг: регистрируем FontResolver только один раз за время жизни процесса
        private static bool _fontResolverRegistered = false;

        /// <summary>
        /// Регистрирует WindowsFontResolver в PDFsharp, если он ещё не установлен.
        /// Должен вызываться перед любым использованием XFont.
        /// </summary>
        private static void EnsureFontResolver()
        {
            if (!_fontResolverRegistered)
            {
                GlobalFontSettings.FontResolver = new WindowsFontResolver();
                _fontResolverRegistered = true;
            }
        }

        // ════════════════════════════════════════════════════════════════════
        //  PDF  (PDFsharp 6.x)
        // ════════════════════════════════════════════════════════════════════

        /// <summary>Создаёт PDF-файл с оформленной анкетой студента.</summary>
        /// <param name="student">Данные студента.</param>
        /// <param name="filePath">Путь для сохранения .pdf файла.</param>
        /// <param name="photoPath">Путь к фото студента (может быть null).</param>
        public static void ExportToPdf(Student student, string filePath, string photoPath = null)
        {
            // Обязательно регистрируем резолвер шрифтов до первого XFont
            EnsureFontResolver();

            using (PdfDocument document = new PdfDocument())
            {
                document.Info.Title   = "Анкета студента";
                document.Info.Author  = student.FullName;
                document.Info.Creator = "StudentQuestionnaire";

                PdfPage page = document.AddPage();
                page.Size = PdfSharp.PageSize.A4;

                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    DrawPdfContent(gfx, page, student, photoPath);
                }

                document.Save(filePath);
            }
        }

        private static void DrawPdfContent(
            XGraphics gfx, PdfPage page, Student student, string photoPath)
        {
            // Шрифты (Arial — стандартный шрифт Windows, всегда доступен)
            XFont fontTitle   = new XFont("Arial", 16, XFontStyleEx.Bold);
            XFont fontSection = new XFont("Arial", 11, XFontStyleEx.Bold);
            XFont fontLabel   = new XFont("Arial",  9, XFontStyleEx.Bold);
            XFont fontValue   = new XFont("Arial",  9, XFontStyleEx.Regular);
            XFont fontFooter  = new XFont("Arial",  7, XFontStyleEx.Italic);

            // Цветовая схема
            XColor colHeader  = XColor.FromArgb(63, 84, 186);   // синий
            XColor colSection = XColor.FromArgb(232, 240, 254); // голубой
            XColor colLine    = XColor.FromArgb(200, 200, 200); // серый

            double pageW    = page.Width.Point;
            double pageH    = page.Height.Point;
            double lm = 50, rm = 50;
            double contentW = pageW - lm - rm;
            double y = 40;

            // ── Заголовок ─────────────────────────────────────────────────
            gfx.DrawRectangle(new XSolidBrush(colHeader), lm, y, contentW, 36);
            gfx.DrawString("АНКЕТА СТУДЕНТА", fontTitle, XBrushes.White,
                new XRect(lm, y, contentW, 36), XStringFormats.Center);
            y += 44;

            // ── Дата генерации ────────────────────────────────────────────
            gfx.DrawString($"Дата: {DateTime.Now:dd.MM.yyyy  HH:mm}", fontFooter,
                new XSolidBrush(XColor.FromArgb(120, 120, 120)),
                new XRect(lm, y, contentW, 14), XStringFormats.CenterRight);
            y += 18;

            // ── Фото студента (если загружено) ────────────────────────────
            double photoW = 100, photoH = 120;
            if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
            {
                try
                {
                    XImage img = XImage.FromFile(photoPath);
                    gfx.DrawRectangle(new XPen(colLine, 1),
                        pageW - rm - photoW - 4, y - 4, photoW + 8, photoH + 8);
                    gfx.DrawImage(img, pageW - rm - photoW, y, photoW, photoH);
                }
                catch { /* Фото не критично — продолжаем без него */ }
            }

            // ── Секция «Личные данные» ────────────────────────────────────
            DrawSection(gfx, "ЛИЧНЫЕ ДАННЫЕ", lm, ref y, contentW, colSection, fontSection);
            DrawField(gfx, "ФИО:",           student.FullName,                         lm, ref y, contentW, fontLabel, fontValue);
            DrawField(gfx, "Дата рождения:", student.BirthDate.ToString("dd.MM.yyyy"), lm, ref y, contentW, fontLabel, fontValue);
            DrawField(gfx, "Возраст:",       $"{student.GetAge()} лет",                lm, ref y, contentW, fontLabel, fontValue);
            DrawField(gfx, "Пол:",           student.Gender,                           lm, ref y, contentW, fontLabel, fontValue);
            DrawField(gfx, "Курс:",          student.Course.ToString(),                lm, ref y, contentW, fontLabel, fontValue);
            DrawField(gfx, "Специальность:", student.Speciality,                       lm, ref y, contentW, fontLabel, fontValue);
            y += 8;

            // ── Секция «Хобби» ────────────────────────────────────────────
            DrawSection(gfx, "ХОББИ", lm, ref y, contentW, colSection, fontSection);
            string hobbiesText = student.Hobbies.Count > 0
                ? string.Join(", ", student.Hobbies)
                : "не указаны";
            DrawField(gfx, "Увлечения:", hobbiesText, lm, ref y, contentW, fontLabel, fontValue);
            y += 14;

            // ── Разделительная линия + подпись ───────────────────────────
            gfx.DrawLine(new XPen(colLine, 0.5), lm, y, pageW - rm, y);
            gfx.DrawString(
                "Документ сгенерирован автоматически приложением «Анкета студента»",
                fontFooter, new XSolidBrush(XColor.FromArgb(150, 150, 150)),
                new XRect(lm, pageH - 30, contentW, 14), XStringFormats.Center);
        }

        private static void DrawSection(XGraphics gfx, string title,
            double lm, ref double y, double contentW, XColor bg, XFont font)
        {
            gfx.DrawRectangle(new XSolidBrush(bg), lm, y, contentW, 18);
            gfx.DrawString($"  {title}", font, XBrushes.Black,
                new XRect(lm, y, contentW, 18), XStringFormats.CenterLeft);
            y += 22;
        }

        private static void DrawField(XGraphics gfx, string label, string value,
            double lm, ref double y, double contentW,
            XFont fontLabel, XFont fontValue)
        {
            double labelW = 120;
            gfx.DrawString(label, fontLabel, XBrushes.Black,
                new XRect(lm + 8, y, labelW, 14), XStringFormats.CenterLeft);
            gfx.DrawString(value, fontValue, XBrushes.Black,
                new XRect(lm + 8 + labelW, y, contentW - labelW - 8, 14),
                XStringFormats.CenterLeft);
            y += 16;
        }

        // ════════════════════════════════════════════════════════════════════
        //  WORD  (DocumentFormat.OpenXml)
        // ════════════════════════════════════════════════════════════════════

        /// <summary>Создаёт .docx файл с оформленной анкетой студента.</summary>
        public static void ExportToWord(Student student, string filePath)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Create(
                filePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Регистрируем стили
                StyleDefinitionsPart stylesPart = mainPart.AddNewPart<StyleDefinitionsPart>();
                stylesPart.Styles = CreateWordStyles();

                // Заголовок
                body.AppendChild(CreateWordHeading("АНКЕТА СТУДЕНТА", "Heading1"));
                body.AppendChild(CreateWordParagraph(
                    $"Дата создания: {DateTime.Now:dd.MM.yyyy HH:mm}",
                    italic: true, color: "808080"));
                body.AppendChild(new Paragraph());

                // Личные данные
                body.AppendChild(CreateWordHeading("Личные данные", "Heading2"));
                body.AppendChild(CreateWordTable(new List<(string, string)>
                {
                    ("ФИО",           student.FullName),
                    ("Дата рождения", student.BirthDate.ToString("dd.MM.yyyy")),
                    ("Возраст",       $"{student.GetAge()} лет"),
                    ("Пол",           student.Gender),
                    ("Курс",          student.Course.ToString()),
                    ("Специальность", student.Speciality),
                }));
                body.AppendChild(new Paragraph());

                // Хобби
                body.AppendChild(CreateWordHeading("Хобби", "Heading2"));
                string hobbiesText = student.Hobbies.Count > 0
                    ? string.Join(", ", student.Hobbies)
                    : "не указаны";
                body.AppendChild(CreateWordParagraph(hobbiesText));
                body.AppendChild(new Paragraph());

                // Нижняя подпись
                body.AppendChild(CreateWordParagraph(
                    "Документ сгенерирован автоматически приложением «Анкета студента»",
                    italic: true, color: "999999", fontSize: 16));

                // Поля страницы A4
                SectionProperties sectPr = new SectionProperties();
                sectPr.AppendChild(new PageMargin
                    { Top = 720, Bottom = 720, Left = 1080, Right = 720 });
                body.AppendChild(sectPr);

                mainPart.Document.Save();
            }
        }

        // ── Word-хелперы ─────────────────────────────────────────────────────

        private static Paragraph CreateWordHeading(string text, string styleName)
        {
            Paragraph para = new Paragraph();
            ParagraphProperties pp = new ParagraphProperties();
            pp.AppendChild(new ParagraphStyleId { Val = styleName });
            para.AppendChild(pp);
            Run run = new Run();
            run.AppendChild(new Text(text));
            para.AppendChild(run);
            return para;
        }

        private static Paragraph CreateWordParagraph(
            string text, bool bold = false, bool italic = false,
            string color = null, int fontSize = 20)
        {
            Paragraph para = new Paragraph();
            Run run = new Run();
            RunProperties rp = new RunProperties();
            if (bold)        rp.AppendChild(new Bold());
            if (italic)      rp.AppendChild(new Italic());
            rp.AppendChild(new FontSize { Val = fontSize.ToString() });
            if (color != null) rp.AppendChild(new Color { Val = color });
            run.AppendChild(rp);
            run.AppendChild(new Text(text) { Space = SpaceProcessingModeValues.Preserve });
            para.AppendChild(run);
            return para;
        }

        private static Table CreateWordTable(List<(string Label, string Value)> rows)
        {
            Table table = new Table();

            TableProperties tblPr = new TableProperties();
            tblPr.AppendChild(new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct });
            tblPr.AppendChild(new TableBorders(
                new TopBorder              { Val = BorderValues.Single, Size = 4 },
                new BottomBorder           { Val = BorderValues.Single, Size = 4 },
                new LeftBorder             { Val = BorderValues.Single, Size = 4 },
                new RightBorder            { Val = BorderValues.Single, Size = 4 },
                new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                new InsideVerticalBorder   { Val = BorderValues.Single, Size = 4 }
            ));
            table.AppendChild(tblPr);

            foreach (var (label, value) in rows)
            {
                TableRow row = new TableRow();

                // Ячейка метки (голубой фон, жирный шрифт)
                TableCell cellLabel = new TableCell();
                cellLabel.AppendChild(new TableCellProperties(
                    new TableCellWidth { Width = "2000", Type = TableWidthUnitValues.Dxa },
                    new Shading { Fill = "D9E1F2", Val = ShadingPatternValues.Clear }));
                cellLabel.AppendChild(CreateWordParagraph(label, bold: true));
                row.AppendChild(cellLabel);

                // Ячейка значения
                TableCell cellValue = new TableCell();
                cellValue.AppendChild(new TableCellProperties(
                    new TableCellWidth { Width = "3000", Type = TableWidthUnitValues.Dxa }));
                cellValue.AppendChild(CreateWordParagraph(value));
                row.AppendChild(cellValue);

                table.AppendChild(row);
            }

            return table;
        }

        private static Styles CreateWordStyles()
        {
            Styles styles = new Styles();

            // Heading1
            Style h1 = new Style { Type = StyleValues.Paragraph, StyleId = "Heading1" };
            h1.AppendChild(new StyleName { Val = "Heading1" });
            StyleRunProperties h1rp = new StyleRunProperties();
            h1rp.AppendChild(new Bold());
            h1rp.AppendChild(new FontSize { Val = "28" });
            h1rp.AppendChild(new Color { Val = "3F54BA" });
            h1.AppendChild(new StyleRunProperties(h1rp.OuterXml));
            StyleParagraphProperties h1pp = new StyleParagraphProperties();
            h1pp.AppendChild(new SpacingBetweenLines { After = "120" });
            h1.AppendChild(h1pp);
            styles.AppendChild(h1);

            // Heading2
            Style h2 = new Style { Type = StyleValues.Paragraph, StyleId = "Heading2" };
            h2.AppendChild(new StyleName { Val = "Heading2" });
            StyleRunProperties h2rp = new StyleRunProperties();
            h2rp.AppendChild(new Bold());
            h2rp.AppendChild(new FontSize { Val = "22" });
            h2rp.AppendChild(new Color { Val = "2E74B5" });
            h2.AppendChild(new StyleRunProperties(h2rp.OuterXml));
            StyleParagraphProperties h2pp = new StyleParagraphProperties();
            h2pp.AppendChild(new SpacingBetweenLines { Before = "160", After = "80" });
            h2.AppendChild(h2pp);
            styles.AppendChild(h2);

            return styles;
        }
    }
}
