using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminTestimonialController : Controller
    {
        LearnerContext context = new LearnerContext();

        public ActionResult Index()
        {
            var values = context.Teslimonials.ToList();
            return View(values);
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Teslimonials.Find(id);
            context.Teslimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(Teslimonial testimonial)
        {
            context.Teslimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Teslimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Teslimonial testimonial)
        {
            var value = context.Teslimonials.Find(testimonial.TeslimonialId);
            value.NameSurname = testimonial.NameSurname;
            value.Title = testimonial.Title;
            value.ImageUrl = testimonial.ImageUrl;
            value.Description = testimonial.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
