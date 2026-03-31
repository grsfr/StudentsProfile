using System.Text;
using AnketaStudenta.Services;

namespace AnketaStudenta
{
    public enum ValidationErrorField { None, FullName, Age, Course, Specialty }
    public static class ValidationService
    {
        public static (bool IsValid, string ErrorMessage, ValidationErrorField ErrorField)
            ValidateStudent(Student student)
        {
            // ФИО
            if (string.IsNullOrWhiteSpace(student.FullName))
                return (false, LanguageService.Get("err_fullname_empty"), ValidationErrorField.FullName);

            if (student.FullName.Length < 5)
                return (false, LanguageService.Get("err_fullname_short"), ValidationErrorField.FullName);

            // Возраст
            if (student.GetAge() < 10)
                return (false, LanguageService.Get("err_age_min"), ValidationErrorField.Age);

            if (student.GetAge() > 100)
                return (false, LanguageService.Get("err_age_max"), ValidationErrorField.Age);

            // Курс
            if (student.Course < 1 || student.Course > 10)
                return (false, LanguageService.Get("err_course"), ValidationErrorField.Course);

            // Специальность
            string chooseKey = LanguageService.Get("spec_choose");
            if (string.IsNullOrWhiteSpace(student.Speciality) || student.Speciality == chooseKey
                || student.Speciality == "Выберите специальность" || student.Speciality == "Choose specialty")
                return (false, LanguageService.Get("err_spec"), ValidationErrorField.Specialty);

            return (true, string.Empty, ValidationErrorField.None);
        }
        public static string FormatStudentInfo(Student student)
        {
            StringBuilder sb = new StringBuilder();
            string L(string key) => LanguageService.Get(key);

            sb.AppendLine(L("result_header"));
            sb.AppendLine($"{L("result_fullname"),16}: {student.FullName}");
            sb.AppendLine($"{L("result_birthdate"),16}: {student.BirthDate:dd.MM.yyyy}");
            sb.AppendLine($"{L("result_age"),16}: {student.GetAge()} {L("result_age_unit")}");
            sb.AppendLine($"{L("result_gender"),16}: {student.Gender}");
            sb.AppendLine($"{L("result_course"),16}: {student.Course}");
            sb.AppendLine($"{L("result_spec"),16}: {student.Speciality}");

            if (student.Hobbies.Count > 0)
                sb.AppendLine($"{L("result_hobbies"),16}: {string.Join(", ", student.Hobbies)}");
            else
                sb.AppendLine($"{L("result_hobbies"),16}: {L("result_no_hobbies")}");

            return sb.ToString();
        }
    }
}
