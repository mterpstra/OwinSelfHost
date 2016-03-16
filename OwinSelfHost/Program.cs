using System;
using Microsoft.Owin.Hosting;
using System.IO;
using System.Threading;

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
		string readVal = Console.ReadLine();
		while (string.IsNullOrEmpty(readVal))
		{
			Thread.Sleep(5000);
			readVal = Console.ReadLine();
		}
            }
        }
    }
}
