using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpClientDemo.Models;

namespace HttpClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://dummy.restapiexample.com/api/v1");
                //HTTP GET
                var responseTask = client.GetAsync("employees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<Employee[]> readTask = result.Content.ReadAsAsync<Employee[]>();
                    readTask.Wait();

                    var employees = readTask.Result;

                    foreach (var employee in employees)
                    {
                        Console.WriteLine(employee.employee_name);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
