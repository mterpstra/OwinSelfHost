using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;


// Test 01
namespace OwinSelfHost
{
    public class ValuesController : ApiController
    {
        protected static List<string> values = new List<string>(new string[]{"Value 000", "Value 001", "Value 002"});

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
        public void Post([FromBody]Dictionary<string,string> body)
        {
            Console.WriteLine("POST");
            values.Add(body["value"]);
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]Dictionary<string,string> body)
        {
            Console.WriteLine("PUT");
            values[id] = body["value"];
        }

        // DELETE api/values/5 
        public void DeleteValue(int id)
        {
            Console.WriteLine("DELETE Id: " + id);
            values.RemoveAt(id);
        }
    }
}
