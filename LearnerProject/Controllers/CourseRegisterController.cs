using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CourseRegisterController : Controller
    {
        
       LearnerContext context = new LearnerContext();

        [HttpGet]
        public ActionResult Index()
        {
            // dropdown icin list yaptik 

            var courselist = context.Courses.ToList();

            List<SelectListItem> courses = (from x in courselist select new SelectListItem 
            {
            Text=x.CourseName,
            Value=x.CourseId.ToString()

            }).ToList();

            ViewBag.courses = courses;
            return View();
        }

        [HttpPost]
        public ActionResult Index(CourseRegister courseregister)
        {
            var student = Session["studentName"].ToString();
            courseregister.StudentId = context.Students.Where(x=>x.NameSurname==student).Select(x=>x.StudentId).FirstOrDefault();
            context.CourseRegisters.Add(courseregister);
            context.SaveChanges();
            return RedirectToAction("Index","StudentCourse");
        }
    }
} 