using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class TeacherCourseController : Controller
    {
        // GET: TeacherCourse
        // Giris yapan kisinin kurslarini listeliyecegiz 

        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            // giris yapan kisinin adini soyadini session ile name degiskenine aldik
            string name = Session["teacherName"].ToString();
            // sartli sorgulama yapacagiz
            var values = context.Courses.Where(x=>x.Teacher.NameSurname==name).ToList();
            return View(values);
        }

        // silme islemini yapalim
        public ActionResult DeleteCourse(int id) 
        {
            var values = context.Courses.Find(id);
            context.Courses.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        // silme islemi bitti 

        // ekleme islemini yapalim 
        [HttpGet]
        public ActionResult AddCourse()
        {
            List<SelectListItem> category = (from x in context.Categories.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            // Biz egitmen sectirmek istemiyoruz cunku egitmen bu sayfaya giris yapan kisi zaten kendi kendine secmesine gerek yok 
            // onun icin session ve sartli sorgu kullanicaz

            // ve boylelikle teacherid'ye de atama yapmis olduk giris yapan kisinin adini soyadini aldik ve onu sartli sorgulama ile 
            // ID'sini almis olduk , ID'yi de parametreden gelen ID'ye esitlemis olduk

            string name = Session["teacherName"].ToString();
            course.TeacherId = context.Teacher.Where(x => x.NameSurname == name).Select(x => x.TeacherId).FirstOrDefault();

            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCourse(int id) 
        {
            List<SelectListItem> category = (from x in context.Categories.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.Category = category;


            var value = context.Courses.Find(id);

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var value = context.Courses.Find(course.CourseId);

            string name = Session["teacherName"].ToString();
            value.TeacherId = context.Teacher.Where(x => x.NameSurname == name).Select(x => x.TeacherId).FirstOrDefault();

            value.CourseName = course.CourseName;
            value.CategoryId= course.CategoryId;
            value.Price = course.Price;
            value.Description = course.Description;
            value.ImageUrl = course.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}