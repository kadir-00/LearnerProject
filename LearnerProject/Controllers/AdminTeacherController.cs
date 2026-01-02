using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminTeacherController : Controller
    {
        LearnerContext context = new LearnerContext();

        public ActionResult Index()
        {
            var values = context.Teacher.ToList();
            return View(values);
        }

        public ActionResult DeleteTeacher(int id)
        {
            var value = context.Teacher.Find(id);
            context.Teacher.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeacher(Teacher teacher)
        {
            context.Teacher.Add(teacher);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTeacher(int id)
        {
            var value = context.Teacher.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTeacher(Teacher teacher)
        {
            var value = context.Teacher.Find(teacher.TeacherId);
            value.NameSurname = teacher.NameSurname;
            value.UserSurname = teacher.UserSurname;
            value.Password = teacher.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
