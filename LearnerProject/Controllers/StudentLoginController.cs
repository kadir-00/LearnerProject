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
    public class StudentLoginController : Controller
    {
        // GET: StudentLogin
        LearnerContext context = new LearnerContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student students)
        {
            var values = context.Students.FirstOrDefault(x => x.UserName == students.UserName && x.Password == students.Password);
            if (values == null)
            {
                ModelState.AddModelError("","Kullanici adi ve ya sifre hatali ");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false); // Cookie olusturduk 
                Session["studentName"] = values.NameSurname;
                Session["studentId"]= values.StudentId;
                return RedirectToAction("Index", "CourseRegister");
            }
        }
    }
}