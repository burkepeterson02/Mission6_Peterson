using Microsoft.AspNetCore.Mvc;
using Mission6_Peterson.Models;
using System.Diagnostics;

namespace Mission6_Peterson.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Form()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Form(MovieModel response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("Confirmation");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
