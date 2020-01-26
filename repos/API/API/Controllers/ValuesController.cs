using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public  class ValuesController : ApiController
    {
       static List<string> Strings = new List<string>
        {
              "value0","value1", "value2"
        };


        // GET api/values
        public IEnumerable<string> Get()
        {
            return Strings;
        }


        // GET api/values/5
        public string Get(int id)
        {
            return Strings[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            Strings.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Strings[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Strings.RemoveAt(id);
        }
    }
}
