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
            return View();
        }

        public PartialViewResult DefaultCoursePartial()
        {
           

            // take burada kac tane kurs gosterecegimizi belirlemeye yariyor 
            // OrderByDescending ile de id ye gore siraladik yani son eklenen 3 kurs gozukecek
            var values = context.Courses.Include(x=>x.Reviews).OrderByDescending(x=>x.CourseId).Take(3).ToList();

           

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
    }
}