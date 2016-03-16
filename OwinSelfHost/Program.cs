using System;
using Microsoft.Owin.Hosting;
using System.IO;

namespace OwinSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {

            string owinhost = Environment.GetEnvironmentVariable("OWIN-HOST");
            if (null == owinhost)
            {
                owinhost = "http://localhost:8080/";
            }
            Console.WriteLine("OWIN-HOST: " + owinhost);

            // Start OWIN host 
            using (WebApp.Start<Startup>(owinhost))
            {
                Console.WriteLine("Web Server is running on:" + owinhost);
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }

            Console.WriteLine("And again...");
            Console.ReadLine();
        }
    }
}
