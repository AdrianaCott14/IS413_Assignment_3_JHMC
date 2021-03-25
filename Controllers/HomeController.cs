using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movies.Models;
using movies.Models.ViewModels;
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

        //set up context
        private MoviesDBContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, MoviesDBContext con)
        {
            _logger = logger;
            context = con; //sets the context
            
        }

        public IActionResult Index()
        {
            //returns the homepage view
            return View();
        }
        
        [HttpGet]
        public IActionResult movieApp()
        {
            //shows the movie form view
            return View();
        }

        [HttpPost]
        public IActionResult movieApp(MovieFormViewModel m) //passes in the data from the form
        {
            context.Movies.Add(m.Movie);
            context.SaveChanges();
            return RedirectToAction("moviesList"); //redirects them to the confirmation page
        }

        //http post for deleting
        [HttpPost]
        public IActionResult removeMovie(int movieID)
        {
            AppResponse mov = context.Movies.Find(movieID);
            context.Movies.Remove(mov);
            context.SaveChanges();
            return RedirectToAction("moviesList");       
        }

        //post method for navigating to the edit form
        [HttpPost]
        public IActionResult editMovieForm(int movieID)
        {
            AppResponse mov = context.Movies.Find(movieID);
            return View(mov);
        }

        //post method for editing the movie
        [HttpPost]
        public IActionResult editMovie(AppResponse mov)
        {
            AppResponse OldMov = context.Movies.Find(mov.MovieID);
            context.Movies.Remove(OldMov);
            context.Movies.Add(mov);
            context.SaveChanges();
            return RedirectToAction("moviesList");
        }

        public IActionResult podcasts()
        {
            return View();
        }

        //passes in movie data
        public IActionResult moviesList()
        {
            return View(context.Movies);
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
