using Microsoft.AspNetCore.Mvc;
using RedisSample.Models;
using System.Diagnostics;

namespace RedisSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        RedisCacheService _redisCacheService;
        public HomeController(ILogger<HomeController> logger, RedisCacheService service)
        {
            _redisCacheService = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            Person person = new Person()
            {
                ID = 1,
                Name = "Sen bir redis cache'sin.",
                Surname = "Kendine gel.",
                Age = 25
            };
            _redisCacheService.Set("person1", person);
            var result = _redisCacheService.Get<Person>("person1");
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