using System;
using System.Collections.Generic;

namespace AnketaStudenta.Services
{
    /// <summary>
    /// Сервис многоязычного интерфейса.
    /// Хранит словари переводов RU/EN; при смене языка
    /// вызывает событие LanguageChanged, на которое подписывается форма.
    /// </summary>
    public static class LanguageService
    {
        // ────────────────────────────────────────────────────────────────────
        // Состояние
        // ────────────────────────────────────────────────────────────────────

        /// <summary>true = английский интерфейс, false = русский (по умолчанию).</summary>
        public static bool IsEnglish { get; private set; } = false;

        /// <summary>Вызывается после смены языка — форма подписывается на него.</summary>
        public static event EventHandler LanguageChanged;

        // ────────────────────────────────────────────────────────────────────
        // Публичный API
        // ────────────────────────────────────────────────────────────────────

        /// <summary>Переключает язык и уведомляет подписчиков.</summary>
        public static void SetLanguage(bool english)
        {
            if (IsEnglish == english) return;   // Нет смысла обновлять, если язык тот же
            IsEnglish = english;
            LanguageChanged?.Invoke(null, EventArgs.Empty);
        }

        /// <summary>
        /// Возвращает строку для заданного ключа в текущем языке.
        /// Если ключ отсутствует — возвращает сам ключ (видна в UI, удобно при отладке).
        /// </summary>
        public static string Get(string key)
        {
            var dict = IsEnglish ? _en : _ru;
            return dict.TryGetValue(key, out string val) ? val : key;
        }

        // ────────────────────────────────────────────────────────────────────
        // Словари переводов
        // ────────────────────────────────────────────────────────────────────

        private static readonly Dictionary<string, string> _ru = new Dictionary<string, string>
        {
            // Форма и секции
            ["app_title"]           = "Анкета студента",
            ["personal_data"]       = "Личные данные",
            ["hobbies_section"]     = "Хобби",
            ["extra_section"]       = "Дополнительно",
            ["lang_label"]          = "Язык / Language:",

            // Поля личных данных
            ["fullname_label"]      = "ФИО:",
            ["birthdate_label"]     = "Дата рождения:",
            ["gender_label"]        = "Пол:",
            ["gender_male"]         = "М",
            ["gender_female"]       = "Ж",
            ["course_label"]        = "Курс:",

            // Специальности
            ["spec_choose"]         = "Выберите специальность",
            ["spec_1"]              = "Информационные системы и программирование",
            ["spec_2"]              = "Компьютерные системы и комплексы",
            ["spec_3"]              = "Сетевое и системное администрирование",
            ["spec_4"]              = "Обеспечение информационной безопасности",
            ["spec_5"]              = "Веб-разработка",
            ["spec_6"]              = "Мобильная разработка",

            // Хобби
            ["hobby_sport"]         = "Спорт",
            ["hobby_music"]         = "Музыка",
            ["hobby_programming"]   = "Программирование",
            ["hobby_reading"]       = "Чтение",
            ["hobby_travel"]        = "Путешествия",
            ["hobby_photo"]         = "Фотография",

            // Кнопки
            ["btn_result"]          = "Результат",
            ["btn_clear"]           = "Очистить",
            ["btn_export_pdf"]      = "⬡ PDF",
            ["btn_export_word"]     = "⬡ Word",
            ["btn_load_photo"]      = "Загрузить фото",
            ["btn_generate_qr"]     = "Сгенерировать QR-код",

            // Диалоги
            ["dlg_clear_confirm"]   = "Вы действительно хотите очистить все поля?",
            ["dlg_clear_title"]     = "Подтверждение очистки",
            ["dlg_result_title"]    = "Результат анкетирования",
            ["dlg_save_txt"]        = "Сохранить анкету в текстовый файл?",
            ["dlg_save_ok"]         = "Анкета успешно сохранена!",
            ["dlg_save_title"]      = "Сохранение",
            ["dlg_qr_ready"]        = "QR-код успешно сгенерирован!\n\nСохранить QR-код как PNG?",
            ["dlg_qr_title"]        = "QR-код готов",
            ["dlg_qr_saved"]        = "QR-код сохранён!",
            ["dlg_export_title"]    = "Экспорт анкеты",
            ["dlg_export_ask"]      = "Анкета экспортирована!\n\nОткрыть файл?",
            ["dlg_export_ok"]       = "Экспорт выполнен успешно.",
            ["dlg_error"]           = "Ошибка",
            ["dlg_input_error"]     = "Ошибка ввода",

            // ToolTips
            ["tip_fullname"]        = "Введите фамилию, имя и отчество полностью",
            ["tip_birthdate"]       = "Выберите дату рождения",
            ["tip_gender_m"]        = "Мужской пол",
            ["tip_gender_f"]        = "Женский пол",
            ["tip_course"]          = "Выберите только один курс (1–10)",
            ["tip_spec"]            = "Выберите специальность из списка",
            ["tip_sport"]           = "Занимаюсь спортом",
            ["tip_music"]           = "Занимаюсь музыкой",
            ["tip_programming"]     = "Занимаюсь программированием",
            ["tip_reading"]         = "Люблю читать",
            ["tip_travel"]          = "Люблю путешествовать",
            ["tip_photo"]           = "Увлекаюсь фотографией",
            ["tip_btn_result"]      = "Показать результат анкеты (Enter)",
            ["tip_btn_clear"]       = "Очистить все поля (Esc)",
            ["tip_btn_pdf"]         = "Экспортировать анкету в PDF",
            ["tip_btn_word"]        = "Экспортировать анкету в Word (.docx)",
            ["tip_load_photo"]      = "Загрузить фотографию (JPG, PNG, BMP)",
            ["tip_generate_qr"]     = "Сгенерировать QR-код с данными анкеты",

            // Форматирование результата
            ["result_header"]       = "=== АНКЕТА СТУДЕНТА ===",
            ["result_fullname"]     = "ФИО",
            ["result_birthdate"]    = "Дата рождения",
            ["result_age"]          = "Возраст",
            ["result_age_unit"]     = "лет",
            ["result_gender"]       = "Пол",
            ["result_course"]       = "Курс",
            ["result_spec"]         = "Специальность",
            ["result_hobbies"]      = "Хобби",
            ["result_no_hobbies"]   = "не указаны",
            ["result_male"]         = "Мужской",
            ["result_female"]       = "Женский",

            // Ошибки валидации
            ["err_fullname_empty"]  = "ФИО не может быть пустым",
            ["err_fullname_short"]  = "ФИО должно содержать не менее 5 символов",
            ["err_age_min"]         = "Возраст должен быть не менее 10 лет",
            ["err_age_max"]         = "Проверьте дату рождения",
            ["err_course"]          = "Выберите корректный курс (1–10)",
            ["err_spec"]            = "Выберите специальность из списка",
        };

        private static readonly Dictionary<string, string> _en = new Dictionary<string, string>
        {
            // Form and sections
            ["app_title"]           = "Student Questionnaire",
            ["personal_data"]       = "Personal Details",
            ["hobbies_section"]     = "Hobbies",
            ["extra_section"]       = "Additional",
            ["lang_label"]          = "Язык / Language:",

            // Personal fields
            ["fullname_label"]      = "Full Name:",
            ["birthdate_label"]     = "Date of Birth:",
            ["gender_label"]        = "Gender:",
            ["gender_male"]         = "M",
            ["gender_female"]       = "F",
            ["course_label"]        = "Year:",

            // Specialties
            ["spec_choose"]         = "Choose specialty",
            ["spec_1"]              = "Information Systems & Programming",
            ["spec_2"]              = "Computer Systems & Complexes",
            ["spec_3"]              = "Network & System Administration",
            ["spec_4"]              = "Information Security",
            ["spec_5"]              = "Web Development",
            ["spec_6"]              = "Mobile Development",

            // Hobbies
            ["hobby_sport"]         = "Sports",
            ["hobby_music"]         = "Music",
            ["hobby_programming"]   = "Programming",
            ["hobby_reading"]       = "Reading",
            ["hobby_travel"]        = "Travel",
            ["hobby_photo"]         = "Photography",

            // Buttons
            ["btn_result"]          = "Submit",
            ["btn_clear"]           = "Clear",
            ["btn_export_pdf"]      = "⬡ PDF",
            ["btn_export_word"]     = "⬡ Word",
            ["btn_load_photo"]      = "Load Photo",
            ["btn_generate_qr"]     = "Generate QR Code",

            // Dialogs
            ["dlg_clear_confirm"]   = "Are you sure you want to clear all fields?",
            ["dlg_clear_title"]     = "Confirm Clear",
            ["dlg_result_title"]    = "Questionnaire Result",
            ["dlg_save_txt"]        = "Save questionnaire to a text file?",
            ["dlg_save_ok"]         = "Questionnaire saved successfully!",
            ["dlg_save_title"]      = "Save",
            ["dlg_qr_ready"]        = "QR code generated successfully!\n\nSave QR code as PNG?",
            ["dlg_qr_title"]        = "QR Code Ready",
            ["dlg_qr_saved"]        = "QR code saved!",
            ["dlg_export_title"]    = "Export Questionnaire",
            ["dlg_export_ask"]      = "Questionnaire exported!\n\nOpen the file?",
            ["dlg_export_ok"]       = "Export completed successfully.",
            ["dlg_error"]           = "Error",
            ["dlg_input_error"]     = "Input Error",

            // ToolTips
            ["tip_fullname"]        = "Enter your full name (Last First Middle)",
            ["tip_birthdate"]       = "Select your date of birth",
            ["tip_gender_m"]        = "Male",
            ["tip_gender_f"]        = "Female",
            ["tip_course"]          = "Select your current year (1–10)",
            ["tip_spec"]            = "Choose a specialty from the list",
            ["tip_sport"]           = "I play sports",
            ["tip_music"]           = "I play music",
            ["tip_programming"]     = "I code for fun",
            ["tip_reading"]         = "I enjoy reading",
            ["tip_travel"]          = "I love to travel",
            ["tip_photo"]           = "I enjoy photography",
            ["tip_btn_result"]      = "Show questionnaire result (Enter)",
            ["tip_btn_clear"]       = "Clear all fields (Esc)",
            ["tip_btn_pdf"]         = "Export questionnaire to PDF",
            ["tip_btn_word"]        = "Export questionnaire to Word (.docx)",
            ["tip_load_photo"]      = "Load a student photo (JPG, PNG, BMP)",
            ["tip_generate_qr"]     = "Generate a QR code with questionnaire data",

            // Result formatting
            ["result_header"]       = "=== STUDENT QUESTIONNAIRE ===",
            ["result_fullname"]     = "Full Name",
            ["result_birthdate"]    = "Date of Birth",
            ["result_age"]          = "Age",
            ["result_age_unit"]     = "years old",
            ["result_gender"]       = "Gender",
            ["result_course"]       = "Year",
            ["result_spec"]         = "Specialty",
            ["result_hobbies"]      = "Hobbies",
            ["result_no_hobbies"]   = "none specified",
            ["result_male"]         = "Male",
            ["result_female"]       = "Female",

            // Validation errors
            ["err_fullname_empty"]  = "Full name cannot be empty",
            ["err_fullname_short"]  = "Full name must be at least 5 characters",
            ["err_age_min"]         = "Age must be at least 10 years",
            ["err_age_max"]         = "Please check the date of birth",
            ["err_course"]          = "Please select a valid year (1–10)",
            ["err_spec"]            = "Please choose a specialty from the list",
        };
    }
}
