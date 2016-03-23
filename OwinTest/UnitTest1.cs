using System;
using System.Threading.Tasks;
using OwinSelfHost;
using Microsoft.Owin.Testing;
using Microsoft.Owin.Hosting;
using System.Net.Http;

namespace OwinTest
{
    // Just a simple model to make things in testing easier.
    // TODO: Consider moving this to models.  Is it really worth it?
    public class Value
    {
        public string value;
    }

    // This is a sample test class used to show how unit testing would/could/should work.
    // Each test SHOULD be able to run on its own.  In other words, you should not have to run tests in order.
    // These tests are not detailed enough, but if they were they would get, update, then re-get to verify new stuff.
    [TestClass]
    public class UnitTest1
    {
        static IDisposable server = null;
        static HttpClient httpclient = null;
             
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            // @TODO: This should be an environment variable with some default value.
            string hostAndPort = "http://localhost:12345";
            UnitTest1.server = WebApp.Start<Startup>(hostAndPort);
            UnitTest1.httpclient = new HttpClient() { BaseAddress = new Uri(hostAndPort) };
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            UnitTest1.server.Dispose();
        }
        

        [TestMethod]
        public async Task TestGetValues()
        {
            HttpResponseMessage response = await httpclient.GetAsync("/api/values");
            string[] values = await response.Content.ReadAsAsync<string[]>();
            Assert.IsNotNull(values);
            Assert.IsTrue(values.Length == 3, "Expected a length of 3 and I received " + values.Length);
        }

        [TestMethod]
        public async Task TestGetValue()
        {
            HttpResponseMessage response = await httpclient.GetAsync("/api/values/1");
            string v = await response.Content.ReadAsAsync<string>();
            Assert.IsNotNull(v);
            Assert.IsTrue(v.Length > 0);
        }

        [TestMethod]
        public async Task TestCreateValue()
        {
            // @TODO: We should get the values first.  Do the POST.  Then get the values again to verify our create worked.
            Value v = new Value() { value = "create me" };
            HttpResponseMessage response = await httpclient.PostAsJsonAsync<Value>("/api/values", v);
            string responseData = await response.Content.ReadAsStringAsync();
            Assert.IsNotNull(responseData);
        }

        [TestMethod]
        public async Task TestUpdateValue()
        {
            // @TODO: We should get the values first.  Do the PUT.  Then get the values again to verify our updated worked.
            Value v = new Value() { value = "update me" };
            HttpResponseMessage response = await httpclient.PostAsJsonAsync<Value>("/api/values/1", v);
            string responseData = await response.Content.ReadAsStringAsync();
            Assert.IsNotNull(responseData);
        }

        [TestMethod]
        public async Task TestDeleteValue()
        {
            // @TODO: We should get the values first.  Do the DELETE.  Then get the values again to verify our record got removed.
            HttpResponseMessage response = await httpclient.DeleteAsync("/api/values/1");
            string responseData = await response.Content.ReadAsStringAsync();
            Assert.IsNotNull(responseData);
        }
    }
}
