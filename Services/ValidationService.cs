using System.Text;

namespace AnketaStudenta
{
    public static class ValidationService
    {
        public static (bool IsValid, string ErrorMessage) ValidateStudent(Student student)
        {
            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(student.FullName))
                return (false, "ФИО не может быть пустым");
            if (student.FullName.Length < 5)
                return (false, "ФИО должно содержать не менее 5 символов");

            // Проверка даты рождения
            if (student.GetAge() < 10)
                return (false, "Возраст должен быть не менее 10 лет");
            if (student.GetAge() > 100)
                return (false, "Проверьте дату рождения");

            // Проверка курса
            if (student.Course < 1 || student.Course > 10)
                return (false, "Выберите корректный курс");

            // Проверка специальности
            if (string.IsNullOrWhiteSpace(student.Speciality) ||
                student.Speciality == "Выберите специальность")
                return (false, "Выберите специальность");

            return (true, string.Empty);
        }

        public static string FormatStudentInfo(Student student)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("== АНКЕТА СТУДЕНТА ==");
            sb.AppendLine($"ФИО: {student.FullName}");
            sb.AppendLine($"Дата рождения: {student.BirthDate:dd.MM.yyyy}");
            sb.AppendLine($"Возраст: {student.GetAge()} лет");
            sb.AppendLine($"Пол: {student.Gender}");
            sb.AppendLine($"Курс: {student.Course}");
            sb.AppendLine($"Специальность: {student.Speciality}");

            if (student.Hobbies.Count > 0)
            {
                sb.AppendLine($"Хобби: {string.Join(", ", student.Hobbies)}");
            }
            else
            {
                sb.AppendLine("Хобби: не указаны");
            }

            return sb.ToString();
        }
    }
}