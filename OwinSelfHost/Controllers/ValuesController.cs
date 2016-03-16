using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;


namespace OwinSelfHost
{
    public class ValuesController : ApiController
    {
        protected static List<string> values = new List<string>(new string[]{"value 00", "value 01", "value 02"});

        // GET api/values 
        public IEnumerable<string> GetAllValues()
        {
            Console.WriteLine("GET All Values");
            return values.ToArray();
        }

        // GET api/values/5 
        public string GetValueById(int id)
        {
            Console.WriteLine("GET Single Value: "+ id);
            return values[id];
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
            Console.WriteLine("POST Body: " + value);
            Dictionary<string, string> json = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
            values.Add(json["value"]);
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
            Console.WriteLine("PUT Body: " + value);
            Dictionary<string, string> json = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
            values[id] = json["value"];
        }

        // DELETE api/values/5 
        public void DeleteValue(int id)
        {
            Console.WriteLine("DELETE Id: " + id);
            values.RemoveAt(id);
        }
    }
}
