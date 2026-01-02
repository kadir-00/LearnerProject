using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminBannerController : Controller
    {
        LearnerContext context = new LearnerContext();

        public ActionResult Index()
        {
            var values = context.Banners.ToList();
            return View(values);
        }

        public ActionResult DeleteBanner(int id)
        {
            var value = context.Banners.Find(id);
            context.Banners.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddBanner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBanner(Banner banner, HttpPostedFileBase imageUrl)
        {
            if (imageUrl != null)
            {
                string fileName = System.IO.Path.GetFileName(imageUrl.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Templates/learner-1.0.0/images/"), fileName);
                imageUrl.SaveAs(path);
                banner.ImageUrl = "/Templates/learner-1.0.0/images/" + fileName;
            }
            context.Banners.Add(banner);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var value = context.Banners.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateBanner(Banner banner, HttpPostedFileBase imageUrl)
        {
            var value = context.Banners.Find(banner.BannerId);
            value.Title = banner.Title;
            if (imageUrl != null)
            {
                string fileName = System.IO.Path.GetFileName(imageUrl.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Templates/learner-1.0.0/images/"), fileName);
                imageUrl.SaveAs(path);
                value.ImageUrl = "/Templates/learner-1.0.0/images/" + fileName;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
