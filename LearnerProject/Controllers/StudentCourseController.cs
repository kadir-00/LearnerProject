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
        public ActionResult Index(int page = 1)
        {
            string studentName = Session["studentName"].ToString();
            var student = context.Students.Where(x => x.UserName == studentName).Select(x => x.StudentId).FirstOrDefault();

            var values = context.CourseRegisters.Where(x => x.StudentId == student).ToList();

            // Pagination Logic
            int pageSize = 3;
            int totalItems = values.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var pagedValues = values.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            // Get Reviewed Courses
            var reviewedCourses = context.Reviews.Where(x => x.StudentId == student).Select(x => x.CourseId).ToList();
            ViewBag.ReviewedCourses = reviewedCourses;

            return View(pagedValues);
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

            // Check if already reviewed
            var existingReview = context.Reviews.FirstOrDefault(x => x.StudentId == studentId && x.CourseId == courseId);
            if (existingReview != null)
            {
                return RedirectToAction("Index");
            }

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