using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoListDataAccess;

namespace DoingList.Controllers
{
    public class DoListController : ApiController
    {
        public IEnumerable<dolist> Get()
        {
            using (dbEntities entities = new dbEntities())
            {
                return entities.dolists.ToList();
            }
        }
        public dolist Get(int id)
        {
            using (dbEntities entities = new dbEntities())
            {
                var list = entities.dolists.FirstOrDefault(e => e.Id == id);
                if (list == null)
                {
                    return null;
                }
                return list;
            }
        }
        public void Post([FromBody]dolist employee)
        {
            using (dbEntities entities = new dbEntities())
            {
                entities.dolists.Add(employee);
                entities.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (dbEntities entities = new dbEntities())
            {
                var employee = entities.dolists.FirstOrDefault(e => e.Id == id);
                entities.dolists.Remove(employee);
                entities.SaveChanges();

            }
        }

        public void Put(int id, [FromBody] dolist list)
        {
            using (dbEntities entities = new dbEntities())
            {
                var _list = entities.dolists.FirstOrDefault(e => e.Id == id);
                _list.Work = list.Work;
                _list.DateFrom = list.DateFrom;
                _list.DateTo = list.DateTo;
                
                entities.SaveChanges();
            }
        }
    }
}
