using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminReviewController : Controller
    {
        LearnerContext context = new LearnerContext();

        public ActionResult Index()
        {
            var values = context.Reviews.Include("Course").Include("Student").ToList();
            return View(values);
        }

        public ActionResult DeleteReview(int id)
        {
            var value = context.Reviews.Find(id);
            context.Reviews.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddReview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddReview(Review review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateReview(int id)
        {
            var value = context.Reviews.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateReview(Review review)
        {
            var value = context.Reviews.Find(review.ReviewId);
            value.ReviewValue = review.ReviewValue;
            value.Comment = review.Comment;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
