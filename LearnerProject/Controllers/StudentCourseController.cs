using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entitities;

namespace LearnerProject.Controllers
{
    public class StudentCourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        [HttpGet]
        public ActionResult Index()
        {
            string studentName = Session["studentName"].ToString();
            var student = context.Students.Where(x => x.UserName == studentName).Select(x => x.StudentId).FirstOrDefault();
            var values = context.CourseRegisters.Where(x => x.StudentId == student).ToList();
            return View(values);
        }

        public ActionResult MyCourseList(int id)
        {
            var values = context.CourseVideos.Where(x => x.CourseId == id).ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult SaveReview(int courseId, int reviewValue, string comment)
        {
            string studentName = Session["studentName"].ToString();
            var studentId = context.Students.Where(x => x.UserName == studentName).Select(x => x.StudentId).FirstOrDefault();

            Review review = new Review();
            review.CourseId = courseId;
            review.ReviewValue = reviewValue;
            review.Comment = comment;
            review.StudentId = studentId;

            context.Reviews.Add(review);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}