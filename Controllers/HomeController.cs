using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movies.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace movies.Controllers
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
        
        [HttpGet]
        public IActionResult movieApp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult movieApp(AppResponse formResponse)
        {
            tempStorage.AddApplication(formResponse);
            return View("confirmation", formResponse);
        }

        public IActionResult podcasts()
        {
            return View();
        }

        public IActionResult moviesList()
        {
            return View(tempStorage.Applications);
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
