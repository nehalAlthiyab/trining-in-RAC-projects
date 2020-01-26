using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EmployeeDataAccess;

namespace EmployeeSarvise.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var employees
                        = entities.Employees.ToList();
                    if (employees != null && entities.Employees.ToList().Count > 0)
                        return Ok(employees);
                    return NotFound();
                }
            }
            catch
            {
                return InternalServerError();
            }

        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {

                    var employee = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (employee == null)
                    {
                        return NotFound();
                    }
                    return Ok(employee);
                }

            
            }
            catch
            {
                return InternalServerError();
            }
        }


        [HttpPost]
        public IHttpActionResult Post([FromBody]Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    entities.Employees.Add(employee);
                    entities.SaveChanges();
                    return StatusCode(System.Net.HttpStatusCode.Created);
                }
            }
            catch
            {
                return InternalServerError();
            }
            
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var employee = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (employee == null)
                        return NotFound();
                    entities.Employees.Remove(employee);
                    entities.SaveChanges();
                    return StatusCode(System.Net.HttpStatusCode.NoContent);
                }
            }
            catch
            {
                return InternalServerError();
            }

        }
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var _employee = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (employee == null)
                        return NotFound();
                    _employee.FirstName = employee.FirstName;
                    _employee.LastName = employee.LastName;
                    _employee.Gender = employee.Gender;
                    _employee.Salary = employee.Salary;

                    entities.SaveChanges();

                    return StatusCode(System.Net.HttpStatusCode.NoContent);
                }
            }
            catch
            {
                return InternalServerError();
            }

        }
    }
}
