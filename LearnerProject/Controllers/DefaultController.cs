using LearnerProject.Models;
using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LearnerProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var ogrtcount= context.Teacher.Count();
            var ogrcount= context.Students.Count();
            TempData["StudentCount"] = ogrcount;
            TempData["TeacherCount"] = ogrtcount;
            return View();

        }

        public PartialViewResult DefaultBannerPartial()
        {
            var values = context.Banners.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAboutPartial()
        {
            var ogrtcount = context.Teacher.Count();
            var ogrcount = context.Students.Count();
            TempData["StudentCount"] = ogrcount;
            TempData["TeacherCount"] = ogrtcount;
            var values = context.Abouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultCoursePartial()
        {
            // take burada kac tane kurs gosterecegimizi belirlemeye yariyor 
            // OrderByDescending ile de id ye gore siraladik yani son eklenen 3 kurs gozukecek
            var values = context.Courses.Include(x=>x.Reviews).Include(x=>x.CourseVideos).OrderByDescending(x=>x.CourseId).Take(3).ToList();
            return PartialView(values);
        }

        public ActionResult CourseDetail(int id) 
        {
            var values = context.Courses.Find(id);  
            // yorumlari getirmek istiyoruz ama yorumlarda baska tablo da o yuzden o tablodan gerekli bilgiyi almak icin filtre uyguladik
            var reviewlist = context.Reviews.Where(x=>x.CourseId==id).ToList();
            ViewBag.reviwe = reviewlist;
            return View(values);
        }

        public ActionResult AllCourse()
        {
            var values = context.Courses.ToList();
            return View(values);
        }

        public PartialViewResult DefaultCategoryPartial()
        {
            var values = context.Categories.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultFAQPartial()
        {
            var values = context.FAQs.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = context.Teslimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultClassPartial()
        { 
        var values = context.ClassRooms.ToList();
            return PartialView(values);
        }
    }
}