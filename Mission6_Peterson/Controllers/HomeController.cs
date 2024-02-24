using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        
        public IActionResult MovieList()
        {
            var movies = _context.Movies.Include(m => m.Category).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View("Form");
        }

        [HttpPost]
        public IActionResult Form(MovieModel response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation");
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Record = _context.Movies.Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.ToList();
            return View("Form", Record);
        }

        [HttpPost]
        public IActionResult Edit(MovieModel response) 
        {
            _context.Update(response);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Record = _context.Movies.Single(x => x.MovieId == id);
            return View(Record);
        }

        [HttpPost]
        public IActionResult Delete(MovieModel movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
