using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using list.Models;
using DataLibrary;
using DataLibrary.TaskLogic;

namespace list.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult addNewTask()
        {
            ViewBag.Message = "add new task page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addNewTask(addNewTask model)
        {
            if (ModelState.IsValid)
            {
                TaskProcessor.CreateTack(model.Work);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}