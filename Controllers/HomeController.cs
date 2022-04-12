using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calcular.Models;

namespace Calcular.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(calculator ca, string calculate)
        {
            switch(calculate)
            {
                case "Add":
                 {
                        ca.result = ca.num1 + ca.num2;
                        break;
                 }

                case "Subs":
                    {
                        ca.result = ca.num1 - ca.num2;
                        break;
                    }
                case "Multiplie":
                    {
                        ca.result = ca.num1 * ca.num2;
                        break;
                    }
                case "Division":
                    {
                        ca.result = ca.num1 / ca.num2;
                        break;
                    }
            }

            ViewBag.previus_results = ca.result;
            return View(ca);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
