using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminClassController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: AdminClass
        public ActionResult Index()
        {
            var value = context.ClassRooms.ToList();
            return View(value);
        }

        public ActionResult DeleteClass(int id)
        {
            var value = context.ClassRooms.Find(id);
            context.ClassRooms.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult AddClass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClass(ClassRoom classRoom)
        {
            context.ClassRooms.Add(classRoom);
            context.SaveChanges();
            return RedirectToAction("Index");
            // yukarda index yerine nameof(index) yapabilirsin
        }

        [HttpGet]
        public ActionResult UpdateClass(int id)
        {
            var value = context.ClassRooms.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateClass(ClassRoom classRoom)
        {
            var value = context.ClassRooms.Find(classRoom.ClassRoomId);
            value.Name = classRoom.Name;
            value.Icon = classRoom.Icon;
            value.Description = classRoom.Description;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}