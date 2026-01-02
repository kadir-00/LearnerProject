using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminStudentController : Controller
    {
        LearnerContext context = new LearnerContext();

        public ActionResult Index()
        {
            var values = context.Students.ToList();
            return View(values);
        }

        public ActionResult DeleteStudent(int id)
        {
            var value = context.Students.Find(id);
            context.Students.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var value = context.Students.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            var value = context.Students.Find(student.StudentId);
            value.NameSurname = student.NameSurname;
            value.UserName = student.UserName;
            value.Password = student.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
