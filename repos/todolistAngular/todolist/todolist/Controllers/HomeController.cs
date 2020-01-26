using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using todolist.Models;
using DataLibrary;
using DataLibrary.TaskLogic;

namespace todolist.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "view Task page.";

            var data = TaskProcessor.LoadTask<addNewTask>();
            List<addNewTask> Task = new List<addNewTask>();

            foreach (var row in data)
            {

                Task.Add(item: new addNewTask
                {
                    Id = row.Id,
                    Work = row.Work,
                    DateFrom=row.DateFrom,
                    DateTo=row.DateTo,
                    ReturnDate=System.DateTime.Now,
                    Completed=row.Completed


                });

            }

            return View(Task);
        }
        public ActionResult add()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add(addNewTask model)
        {
            if (ModelState.IsValid)
            {
                int chack = TaskProcessor.createTack(model.Work, model.DateFrom, model.DateTo);
                if (chack == 0)
                {
                    ViewBag.Message = "this task is in the list.";
                }
                else if(chack==-1)
                {
                    ViewBag.Message = "the date to mast by after the date from.";
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
            }
            return View();

        }


        public ActionResult Edit(int id ,string work, DateTime from, DateTime to)
        {
            var modal = new addNewTask();
            modal.Work = work;
            modal.DateFrom = from;
            modal.DateTo = to;
            return View(modal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(addNewTask model)
        {
            if (ModelState.IsValid)
            {

                int chack = TaskProcessor.editTask(model.Id, model.Work, model.DateFrom, model.DateTo);
                if (chack == 0)
                {
                    ViewBag.Message = "this task is in the list.";
                }
                else if (chack == -1)
                {
                    ViewBag.Message = "the date to mast by after the date from.";
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

            public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(addNewTask model)
        {
            if (ModelState.IsValid)
            {

                TaskProcessor.deleteTask(model.Id);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Completed(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Completed(addNewTask model)
        {
            if (ModelState.IsValid)
            {

                TaskProcessor.Completed(model.Id);
                return RedirectToAction("Index");
            }
            return View();
        }

        }
}