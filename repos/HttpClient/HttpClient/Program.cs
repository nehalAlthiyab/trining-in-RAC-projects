using System;
using HttpClient.Model;

namespace HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://dummy.restapiexample.com/api/v1");
                //HTTP GET
                var responseTask = client.GetAsync("employee");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Employee[]>();
                    readTask.Wait();

                    var employees = readTask.Result;

                    foreach (var employee in employees)
                    {
                        Console.WriteLine(employee.Name);
                    }
                }
            }
            Console.ReadLine();

        }
    }
}
