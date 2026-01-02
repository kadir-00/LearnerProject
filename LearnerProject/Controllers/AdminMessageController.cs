using LearnerProject.Models.Context;
using LearnerProject.Models.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminMessageController : Controller
    {
        LearnerContext context = new LearnerContext();

        public ActionResult Index()
        {
            var values = context.Messages.ToList();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ChangeIsRead(int id)
        {
            var value = context.Messages.Find(id);
            if (value.IsRead == true)
            {
                value.IsRead = false;
            }
            else
            {
                value.IsRead = true;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var value = context.Messages.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateMessage(Message message)
        {
            var value = context.Messages.Find(message.MessageId);
            value.NameSurname = message.NameSurname;
            value.Email = message.Email;
            value.Subject = message.Subject;
            value.MessageContent = message.MessageContent;
            value.IsRead = message.IsRead;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
