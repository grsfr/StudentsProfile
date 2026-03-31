using System;
using System.Collections.Generic;

namespace AnketaStudenta
{
    public class Student
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int Course { get; set; }
        public string Speciality { get; set; }
        public List<string> Hobbies { get; set; }

        public Student()
        {
            Hobbies = new List<string>();
        }

        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;
            if (BirthDate.Date > today.AddYears(-age))
                age--;
            return age;
        }
    }
}