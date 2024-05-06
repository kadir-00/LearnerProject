using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entitities
{
    public class Teslimonial
    {
        public int TeslimonialId { get; set; }

        public string NameSurname { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}