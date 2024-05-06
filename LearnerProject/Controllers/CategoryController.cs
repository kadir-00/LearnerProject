using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            // tolist'e sart ekleyecez  Where sart koymamiza yardimci oldu
            var values = context.Categories.Where(x => x.Status == true).ToList();
            return View(values);
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            category.Status = true; // status otomatik true gelmesi icin
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
            // yukarda index yerine nameof(index) yapabilirsin
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id) 
        {
        var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category) 
        {
            var value = context.Categories.Find(category.CategoryId);
            value.CategoryName=category.CategoryName;
            value.Icon=category.Icon;
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}