using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entitities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string NameSurname { get; set; }
        public string UserSurname { get; set; }
        public string Password { get; set; }

        public List<Course> Courses { get; set; }
    }
}