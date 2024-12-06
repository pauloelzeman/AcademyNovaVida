using System.Diagnostics;
using AcademyNovaVida.Data;
using AcademyNovaVida.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademyNovaVida.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _logger;

        public HomeController(ApplicationContext logger)
        {
            _logger = logger;
        }

        public async Task <IActionResult> Index()
        {
            return View(await _logger.Professor.ToListAsync());
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
