using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AnketaStudenta.Services;
using QRCoder;

namespace AnketaStudenta
{
    public partial class MainForm : Form
    {
        // Поля 
        private List<CheckBox> courseCheckBoxes = new List<CheckBox>();
        private CheckBox       lastChecked      = null;
        private ToolTip        toolTip;
        private string         _photoPath       = null; 


        public MainForm()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                InitializeFormProperties();
                InitializeCourseCheckBoxesList();
                SetupEventHandlers();
                SetupToolTips();
                LanguageService.LanguageChanged += (s, e) => ApplyLanguage();
                HighlightLanguageButton(isRu: true);
            }
        }

        private void InitializeFormProperties()
        {
            this.Text            = "Анкета студента";
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.MinimumSize     = new Size(600, 700);
            this.MaximizeBox     = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            dtpBirthDate.Format   = DateTimePickerFormat.Short;
            dtpBirthDate.MaxDate  = DateTime.Today;
            dtpBirthDate.MinDate  = new DateTime(1900, 1, 1);
            dtpBirthDate.Value    = new DateTime(2000, 1, 1);

            txtFullName.MaxLength       = 100;
            rbMale.Checked              = true;
            cmbSpeciality.SelectedIndex = 0;

            this.AcceptButton = btnResult;
            this.CancelButton = btnClear;
        }

        private void InitializeCourseCheckBoxesList()
        {
            courseCheckBoxes.AddRange(new CheckBox[]
            {
                chkCourse1, chkCourse2, chkCourse3, chkCourse4, chkCourse5,
                chkCourse6, chkCourse7, chkCourse8, chkCourse9, chkCourse10
            });
        }

        private void SetupEventHandlers()
        {
            foreach (var cb in courseCheckBoxes)
            {
                cb.CheckedChanged += CourseCheckBox_CheckedChanged;
                cb.CheckedChanged += (s, e) => coursesTable.BackColor = SystemColors.Control;
            }
            btnClear.Click  += BtnClear_Click;
            btnResult.Click += BtnResult_Click;
            txtFullName.TextChanged            += (s, e) => txtFullName.BackColor    = SystemColors.Window;
            cmbSpeciality.SelectedIndexChanged += (s, e) => cmbSpeciality.BackColor = SystemColors.Window;
        }

        private void SetupToolTips()
        {
            toolTip = new ToolTip { AutoPopDelay = 5000, InitialDelay = 1000, ReshowDelay = 500, ShowAlways = true };
            RefreshToolTips();
        }

        private void RefreshToolTips()
        {
            string L(string key) => LanguageService.Get(key);
            toolTip.SetToolTip(txtFullName,    L("tip_fullname"));
            toolTip.SetToolTip(dtpBirthDate,   L("tip_birthdate"));
            toolTip.SetToolTip(rbMale,         L("tip_gender_m"));
            toolTip.SetToolTip(rbFemale,       L("tip_gender_f"));
            toolTip.SetToolTip(coursesTable,   L("tip_course"));
            toolTip.SetToolTip(cmbSpeciality,  L("tip_spec"));
            toolTip.SetToolTip(chkSport,       L("tip_sport"));
            toolTip.SetToolTip(chkMusic,       L("tip_music"));
            toolTip.SetToolTip(chkProgramming, L("tip_programming"));
            toolTip.SetToolTip(chkReading,     L("tip_reading"));
            toolTip.SetToolTip(chkTravel,      L("tip_travel"));
            toolTip.SetToolTip(chkPhoto,       L("tip_photo"));
            toolTip.SetToolTip(btnResult,      L("tip_btn_result"));
            toolTip.SetToolTip(btnClear,       L("tip_btn_clear"));
            toolTip.SetToolTip(btnExportPDF,   L("tip_btn_pdf"));
            toolTip.SetToolTip(btnExportWord,  L("tip_btn_word"));
            toolTip.SetToolTip(btnLoadPhoto,   L("tip_load_photo"));
            toolTip.SetToolTip(btnGenerateQR,  L("tip_generate_qr"));
        }

        //  Многоязычный интерфейс

        private void BtnRU_Click(object sender, EventArgs e)
        {
            LanguageService.SetLanguage(false);
            HighlightLanguageButton(isRu: true);
        }

        private void BtnEN_Click(object sender, EventArgs e)
        {
            LanguageService.SetLanguage(true);
            HighlightLanguageButton(isRu: false);
        }

        private void HighlightLanguageButton(bool isRu)
        {
            btnRU.BackColor = isRu ? Color.SteelBlue : SystemColors.Control;
            btnRU.ForeColor = isRu ? Color.White     : SystemColors.ControlText;
            btnEN.BackColor = isRu ? SystemColors.Control : Color.SteelBlue;
            btnEN.ForeColor = isRu ? SystemColors.ControlText : Color.White;
        }

        private void ApplyLanguage()
        {
            string L(string key) => LanguageService.Get(key);
            this.Text           = L("app_title");
            gbPersonal.Text     = L("personal_data");
            gbHobbies.Text      = L("hobbies_section");
            gbExtra.Text        = L("extra_section");
            lblFullName.Text    = L("fullname_label");
            dataText.Text       = L("birthdate_label");
            rbText.Text         = L("gender_label");
            rbMale.Text         = L("gender_male");
            rbFemale.Text       = L("gender_female");
            courceText.Text     = L("course_label");
            chkSport.Text       = L("hobby_sport");
            chkMusic.Text       = L("hobby_music");
            chkProgramming.Text = L("hobby_programming");
            chkReading.Text     = L("hobby_reading");
            chkTravel.Text      = L("hobby_travel");
            chkPhoto.Text       = L("hobby_photo");
            btnResult.Text      = L("btn_result");
            btnClear.Text       = L("btn_clear");
            btnExportPDF.Text   = L("btn_export_pdf");
            btnExportWord.Text  = L("btn_export_word");
            btnLoadPhoto.Text   = L("btn_load_photo");
            btnGenerateQR.Text  = L("btn_generate_qr");

            int savedIdx = cmbSpeciality.SelectedIndex;
            cmbSpeciality.Items.Clear();
            cmbSpeciality.Items.Add(L("spec_choose"));
            for (int i = 1; i <= 6; i++) cmbSpeciality.Items.Add(L($"spec_{i}"));
            cmbSpeciality.SelectedIndex = savedIdx >= 0 ? savedIdx : 0;

            RefreshToolTips();
        }

        private void CourseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox current = (CheckBox)sender;
            if (current.Checked)
            {
                if (lastChecked != null && lastChecked != current) lastChecked.Checked = false;
                lastChecked = current;
            }
            else { if (lastChecked == current) lastChecked = null; }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            string L(string key) => LanguageService.Get(key);
            if (MessageBox.Show(L("dlg_clear_confirm"), L("dlg_clear_title"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                ClearAllFields();
        }

        private void BtnResult_Click(object sender, EventArgs e)
        {
            try
            {
                Student student  = CollectFormData();
                var     validate = ValidationService.ValidateStudent(student);
                if (!validate.IsValid) { ShowErrorMessage(validate.ErrorMessage, validate.ErrorField); return; }
                ShowResultMessage(ValidationService.FormatStudentInfo(student), student);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{LanguageService.Get("dlg_error")}: {ex.Message}",
                    LanguageService.Get("dlg_error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  Экспорт PDF / Word

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            Student student  = CollectFormData();
            var     validate = ValidationService.ValidateStudent(student);
            if (!validate.IsValid) { ShowErrorMessage(validate.ErrorMessage, validate.ErrorField); return; }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = LanguageService.Get("dlg_export_title") + " — PDF";
                sfd.Filter = "PDF документ (*.pdf)|*.pdf"; sfd.DefaultExt = "pdf";
                sfd.FileName = $"Анкета_{SafeName(student.FullName)}.pdf";
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try   { ExportService.ExportToPdf(student, sfd.FileName, _photoPath); OfferOpenFile(sfd.FileName); }
                catch (Exception ex) { ShowError(ex.Message); }
            }
        }

        private void BtnExportWord_Click(object sender, EventArgs e)
        {
            Student student  = CollectFormData();
            var     validate = ValidationService.ValidateStudent(student);
            if (!validate.IsValid) { ShowErrorMessage(validate.ErrorMessage, validate.ErrorField); return; }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = LanguageService.Get("dlg_export_title") + " — Word";
                sfd.Filter = "Word документ (*.docx)|*.docx"; sfd.DefaultExt = "docx";
                sfd.FileName = $"Анкета_{SafeName(student.FullName)}.docx";
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try   { ExportService.ExportToWord(student, sfd.FileName); OfferOpenFile(sfd.FileName); }
                catch (Exception ex) { ShowError(ex.Message); }
            }
        }
        //  Фото и QR

        private void BtnLoadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title  = LanguageService.Get("btn_load_photo");
                ofd.Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Все файлы (*.*)|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    pbStudentPhoto.Image?.Dispose();
                    using (var s = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        pbStudentPhoto.Image = Image.FromStream(s);
                    _photoPath        = ofd.FileName;
                    lblPhotoName.Text = Path.GetFileName(ofd.FileName);
                }
                catch (Exception ex) { ShowError(ex.Message); }
            }
        }

        private void BtnGenerateQR_Click(object sender, EventArgs e)
        {
            try
            {
                string content = string.IsNullOrWhiteSpace(txtFullName.Text.Trim())
                    ? $"Student Questionnaire\n{DateTime.Now:dd.MM.yyyy HH:mm}"
                    : ValidationService.FormatStudentInfo(CollectFormData());

                using (QRCodeGenerator gen  = new QRCodeGenerator())
                using (QRCodeData      data = gen.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q))
                using (QRCode          code = new QRCode(data))
                {
                    pbQRCode.Image?.Dispose();
                    pbQRCode.Image = code.GetGraphic(5, Color.Black, Color.White, true);
                }

                if (MessageBox.Show(LanguageService.Get("dlg_qr_ready"), LanguageService.Get("dlg_qr_title"),
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    SaveQrCode(pbQRCode.Image, txtFullName.Text.Trim());
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void ClearAllFields()
        {
            txtFullName.Text = string.Empty; txtFullName.BackColor = SystemColors.Window;
            dtpBirthDate.Value = new DateTime(2000, 1, 1);
            rbMale.Checked = true;
            foreach (var cb in courseCheckBoxes) cb.Checked = false;
            lastChecked = null; coursesTable.BackColor = SystemColors.Control;
            cmbSpeciality.SelectedIndex = 0; cmbSpeciality.BackColor = SystemColors.Window;
            chkSport.Checked = chkMusic.Checked = chkProgramming.Checked = false;
            chkReading.Checked = chkTravel.Checked = chkPhoto.Checked = false;
            pbStudentPhoto.Image?.Dispose(); pbStudentPhoto.Image = null;
            lblPhotoName.Text = string.Empty; _photoPath = null;
            pbQRCode.Image?.Dispose(); pbQRCode.Image = null;
            txtFullName.Focus();
        }

        private Student CollectFormData() => new Student
        {
            FullName   = txtFullName.Text.Trim(),
            BirthDate  = dtpBirthDate.Value,
            Gender     = rbMale.Checked ? LanguageService.Get("result_male") : LanguageService.Get("result_female"),
            Course     = GetSelectedCourse(),
            Speciality = cmbSpeciality.SelectedItem?.ToString() ?? string.Empty,
            Hobbies    = GetSelectedHobbies()
        };

        private int GetSelectedCourse()
        {
            for (int i = 0; i < courseCheckBoxes.Count; i++)
                if (courseCheckBoxes[i].Checked) return i + 1;
            return 0;
        }

        private List<string> GetSelectedHobbies()
        {
            string L(string key) => LanguageService.Get(key);
            var h = new List<string>();
            if (chkSport.Checked)       h.Add(L("hobby_sport"));
            if (chkMusic.Checked)       h.Add(L("hobby_music"));
            if (chkProgramming.Checked) h.Add(L("hobby_programming"));
            if (chkReading.Checked)     h.Add(L("hobby_reading"));
            if (chkTravel.Checked)      h.Add(L("hobby_travel"));
            if (chkPhoto.Checked)       h.Add(L("hobby_photo"));
            return h;
        }

        private void ShowErrorMessage(string message, ValidationErrorField field)
        {
            switch (field)
            {
                case ValidationErrorField.FullName:
                    txtFullName.BackColor = Color.LightPink; txtFullName.Focus(); break;
                case ValidationErrorField.Specialty:
                    cmbSpeciality.BackColor = Color.LightPink; cmbSpeciality.Focus(); break;
                case ValidationErrorField.Course:
                    coursesTable.BackColor = Color.LightPink; break;
            }
            MessageBox.Show(message, LanguageService.Get("dlg_input_error"),
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowResultMessage(string resultText, Student student)
        {
            if (MessageBox.Show(resultText + "\n\n" + LanguageService.Get("dlg_save_txt"),
                    LanguageService.Get("dlg_result_title"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                SaveToTxtFile(student, resultText);
        }

        private void SaveToTxtFile(Student student, string content)
        {
            string L(string key) => LanguageService.Get(key);
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = L("dlg_save_title"); sfd.Filter = "Text files (*.txt)|*.txt";
                sfd.DefaultExt = "txt"; sfd.FileName = $"Анкета_{SafeName(student.FullName)}.txt";
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try { File.WriteAllText(sfd.FileName, content, Encoding.UTF8);
                      MessageBox.Show(L("dlg_save_ok"), L("dlg_save_title"), MessageBoxButtons.OK, MessageBoxIcon.Information); }
                catch (Exception ex) { ShowError(ex.Message); }
            }
        }

        private void SaveQrCode(Image img, string name)
        {
            if (img == null) return;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG (*.png)|*.png"; sfd.DefaultExt = "png";
                sfd.FileName = "QR_" + (string.IsNullOrWhiteSpace(name) ? "Анкета" : SafeName(name)) + ".png";
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try { img.Save(sfd.FileName, ImageFormat.Png);
                      MessageBox.Show(LanguageService.Get("dlg_qr_saved"), LanguageService.Get("dlg_save_title"),
                          MessageBoxButtons.OK, MessageBoxIcon.Information); }
                catch (Exception ex) { ShowError(ex.Message); }
            }
        }

        private void OfferOpenFile(string path)
        {
            if (MessageBox.Show(LanguageService.Get("dlg_export_ask"), LanguageService.Get("dlg_export_title"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                try { Process.Start(new ProcessStartInfo(path) { UseShellExecute = true }); }
                catch { }
        }

        private void ShowError(string msg)
            => MessageBox.Show($"{LanguageService.Get("dlg_error")}: {msg}",
                LanguageService.Get("dlg_error"), MessageBoxButtons.OK, MessageBoxIcon.Error);

        private static string SafeName(string s)
            => string.IsNullOrWhiteSpace(s) ? "студент" : s.Replace(" ", "_");
    }
}
