using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentCourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            // id islemi session'dan gelen id degere esit olan degerleri listele 
            var values = context.CourseRegisters.Where(x => x.StudentId == (int)Session["studentId"]).ToList();
            return View(values);
        }
    }
}