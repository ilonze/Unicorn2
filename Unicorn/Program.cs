﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Microsoft.Owin.Hosting;

namespace Unicorn
{
    public class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9001/";
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                HttpClient client = new HttpClient();
                Console.WriteLine(baseAddress);
                Console.ReadLine();
            }
        }
    }
}