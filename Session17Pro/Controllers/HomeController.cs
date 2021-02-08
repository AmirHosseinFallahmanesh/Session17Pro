using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Session17Pro.Infrastruture.Extetnsions;
using Session17Pro.Infrastruture.Helpers;
using Session17Pro.Models;

namespace Session17Pro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICache Cache;

        public HomeController(ICache Cache)
        {
            this.Cache = Cache;
        }
        public IActionResult Index()
        {
            ViewBag.Id = HttpContext.Session.Id;
            
            return View();
        }

        public IActionResult WTS()
        {
            //HttpContext.WriteToSession("Demo", new Random().Next(12, 20000).ToString()) ;
          //  Cache.SetString("Demo", new Random().Next(12, 20000).ToString());
            Cache.Set<string>("Demo", new Random().Next(12, 20000).ToString());
            return RedirectToAction("index");
        }
        public IActionResult RFS()
        {
            
         // string data = HttpContext.ReadFromSession<string>("Demo");
           string data = Cache.Get<string>("Demo");
            return Content(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
  
       
    }
}
