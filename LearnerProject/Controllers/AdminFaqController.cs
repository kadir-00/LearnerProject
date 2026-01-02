using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminFaqController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: FAQ
        public ActionResult Index()
        {
            var values = context.FAQs.ToList();
            return View(values);
        }

        public ActionResult ChangeStatus(int id)
        {
            var value = context.FAQs.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // ekleme islemi 
        [HttpGet]
        public ActionResult AddFAQ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFAQ(FAQ FAQ)
        {
            FAQ.Status = true;
            context.FAQs.Add(FAQ);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        // ekleme islemi bitti
        public ActionResult DeleteFAQ(int id)
        {
            var value = context.FAQs.Find(id);
            context.FAQs.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        // silme islemi 

        // guncelleme islemi 
        [HttpGet]
        public ActionResult UpdateFAQ(int id)
        {
            var value = context.FAQs.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFAQ(FAQ FAQ)
        {
            var value = context.FAQs.Find(FAQ.FAQId);
            value.Question = FAQ.Question;
            value.Answer = FAQ.Answer;
            value.ImageUrl = FAQ.ImageUrl;
            value.Status = true;

            context.SaveChanges();
            return RedirectToAction("Index");

        }
        // guncelleme islemi bitti

    }
}