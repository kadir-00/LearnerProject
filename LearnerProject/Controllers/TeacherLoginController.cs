using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnerProject.Controllers
{
    public class TeacherLoginController : Controller
    {
        // GET: TeacherLogin

        LearnerContext context = new LearnerContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Teacher teacher)
        {
            var values = context.Teacher.FirstOrDefault(x => x.UserSurname == teacher.UserSurname && x.Password == teacher.Password);
            if (values == null) 
            {
                ModelState.AddModelError(" ","Kullanici adi ve ya sifre hatali ");
                return View();
            }
            else 
            {
                FormsAuthentication.SetAuthCookie(values.UserSurname, false);
                Session["teacherName"]=values.NameSurname;
            return RedirectToAction("Index" , "TeacherCourse");
            }
        }
    }
}