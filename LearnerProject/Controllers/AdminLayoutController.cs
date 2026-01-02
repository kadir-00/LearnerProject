using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSidebar()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutNavbar()
        {
            var values = context.Messages.OrderByDescending(x => x.MessageId).Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult AdminLayoutFooter()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutJs()
        {
            return PartialView();
        }
    }
}