using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LearnerProject.Models.Entitities;

namespace LearnerProject.Models.Context
{
    public class LearnerContext : DbContext
    {
        public LearnerContext() : base("LearnerContext")
        {
            Database.SetInitializer<LearnerContext>(null);
        }
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
        public DbSet<CourseVideo> CourseVideos { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}