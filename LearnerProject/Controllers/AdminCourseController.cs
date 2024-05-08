using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminCourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: Course
        public ActionResult Index()
        {
            var value = context.Courses.ToList();
            return View(value);
        }

        // silmeyi yapalim 
        public ActionResult DeleteCourse(int id)  
        {
            var value = context.Courses.Find(id);
            context.Courses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        
        }
        // silme islemi bitti 

        // eklemeyi yapalim 
        [HttpGet]
        public ActionResult AddCourse() 
        { // kategorileri viewbag'e tasimak istedigmiz icin bunu get'te yapiyoruz 
            //  Where'i neden kullandik cunku course ekleme sayfasinda dropdown da status'u false olanda gozukuyordu
            List<SelectListItem> category = (from x in context.Categories.Where(x=>x.Status==true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.Category = category;
        return View();
        }


        [HttpPost]
        public ActionResult AddCourse(Course courses) 
        {
        context.Courses.Add(courses);
            context.SaveChanges();
            return RedirectToAction("Index");


        }
        // ekleme bitti 

        // guncellem kismini yapalim 

        [HttpGet]
        public ActionResult UpdateCourse(int id) 
        {
            List<SelectListItem> category = (from x in context.Categories.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.Category = category;

            var value = context.Courses.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var value = context.Courses.Find(course.CourseId);
            value.CourseName = course.CourseName;
            value.CategoryId = course.CategoryId;
            value.ImageUrl = course.ImageUrl;
            value.Price = course.Price;
            value.Description = course.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}