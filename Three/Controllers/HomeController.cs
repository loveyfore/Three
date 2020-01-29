using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Three.Models;
using Three.Services;

namespace Three.Controllers
{
    //控制器要继承Controller类
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClock clock;

        public HomeController(ILogger<HomeController> logger, IClock clock)
        {
            _logger = logger;
            this.clock = clock;
        }

        public IActionResult Index()
        {
            return View();
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
