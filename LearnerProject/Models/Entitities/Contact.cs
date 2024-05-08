using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entitities
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string Add {  get; set; }

        public string OpenHours { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}