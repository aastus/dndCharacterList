using dndCharacterList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dndCharacterList.Controllers
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
            var info = new ProjectInfo(
                "Анастасія Рибчинська",
                "ІПЗс-24",
                "Онлайн-ресурс конструктор для створення персонажа DnD",
                "");
            //{
            //    Name = "Анастасія",
            //    Group = "SE-2024",
            //    
            //    ThemeDescription = "This course work explores the importance of automated testing, its types, and implementation in large-scale software projects."
            //};
            return View(info);
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