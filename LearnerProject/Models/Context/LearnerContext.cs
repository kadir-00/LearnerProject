using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LearnerProject.Models.Entitities;

namespace LearnerProject.Models.Context
{
    public class LearnerContext :DbContext
    {
        // pluralize
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseRegister> CourseRegisters { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teslimonial> Teslimonials { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
    }
}