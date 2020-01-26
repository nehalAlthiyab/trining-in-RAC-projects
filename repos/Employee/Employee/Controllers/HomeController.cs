using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Employee.Models;
using System.Net.Http;
using Employee.Utility;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Employees> emoloyees = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SD.GetURL);

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("Employees");
                responseTask.Wait();

                //To store result of web api response.   
                HttpResponseMessage result = responseTask.Result;

                //If success received   
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Employees>>();
                    readTask.Wait();

                    emoloyees = readTask.Result;
                }
                else if(result.StatusCode == System.Net.HttpStatusCode.NotFound)
                {  
                    ViewBag.Masseage = "No employee found";
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    ViewBag.Masseage = "Server error try after some time.";
                }
            }
            return View (emoloyees);
        }

        public IActionResult PostNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostNewEmployee(Employees employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SD.PostURL);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Employees>("Employees", employee);
                postTask.Wait();


                HttpResponseMessage result = postTask.Result;

                //If success received   
                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("Index");
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    ViewBag.Masseage = "Server error try after some time.";
                }
            }
            return View(employee);

        }
        public ActionResult Edit(int id)
        {
            Employees employee = null;

            using (var client = new HttpClient())
            {
                 client.BaseAddress = new Uri(SD.GetURL);
                //HTTP GET
                var responseTask = client.GetAsync("Employees/" + id.ToString());
                responseTask.Wait();

                HttpResponseMessage result = responseTask.Result;
                //If success received   
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var readTask = result.Content.ReadAsAsync<Employees>();
                    readTask.Wait();

                    employee = readTask.Result;
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ViewBag.Masseage = "No employee found";
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    ViewBag.Masseage = "Server error try after some time.";
                }
            }

            return View(employee);
        }


        [HttpPost]

        public ActionResult Edit(Employees employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SD.PostURL);
                
                //HTTP POST
                var putTask = client.PutAsJsonAsync("Employees/" + employee.ID.ToString(), employee);
                putTask.Wait();

                HttpResponseMessage result = putTask.Result;
                //If success received   
                if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index");
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    ViewBag.Masseage = "Server error try after some time.";
                }
            }
            return View(employee);
        }
        
        public ActionResult Delete(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SD.PostURL);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Employees/" + id.ToString());
                deleteTask.Wait();

                HttpResponseMessage result = deleteTask.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ViewBag.Masseage = "No employee found";
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    ViewBag.Masseage = "Server error try after some time.";
                }
            }

            return RedirectToAction("Index");
        }
    }
}
