using CameronKeetch_Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CameronKeetch_Assignment3.Controllers
{
    public class HomeController : Controller
    {   
        private MoviesDbContext context { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MoviesDbContext con)
        {
            _logger = logger;
            context = con;
        }


        //displays the Index page.
        public IActionResult Index()
        {
            return View();
        }

        //displays MovieForm
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }


        //Displays the form where a movie can be entered, saves it to the context, and makes sure the model is valid.
        [HttpPost]
        public IActionResult MovieForm(MovieResponse movieResponse)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(movieResponse);
                context.SaveChanges();
                return View("Confirmation", movieResponse);
            }

            //if form isn't valid, it doesn't save the info
            else
            {
                return View();
            }
        }


        //returns the list of Movies in the database
        [HttpGet]
        public IActionResult MovieList()
        {
            //passes the context as so the info can be used.
            return View(context.Movies);
        }

        [HttpPost]
        public IActionResult MovieList(int MovieId)
        {
            //creating a variable to pass through the ViewBag, this will allow us to use the info on our edit page
            MovieResponse movie = context.Movies.Where(m => m.MovieId == MovieId).FirstOrDefault();
            ViewBag.Movie = movie;

            //returns the Edit View.
            return View("Edit");
        }


        //after being called on the MovieList.cshtml, passes the MovieId that is passed in the form
        [HttpPost]
        public IActionResult Delete(int MovieId)
        {
            //declaring variable to find the data in the database
            MovieResponse movie = context.Movies.Where(m => m.MovieId == MovieId).FirstOrDefault();

            //removes specific movie from the database
            context.Movies.Remove(movie);

            //saves the database
            context.SaveChanges();

            //returns the DeleteConfirmation page
            return View("DeleteConfirmation");
        }

       

        //allows editing in a form
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        //after edited the new info is saved to the context, and the EditConfirmation page is displayed.
        [HttpPost]
        public IActionResult Edit(MovieResponse mr)
        {
            MovieResponse movie = context.Movies.Where(m => m.MovieId == mr.MovieId).FirstOrDefault();
            movie.Title = mr.Title;
            movie.Category = mr.Category;
            movie.Year = mr.Year;
            movie.Director = mr.Director;
            movie.Rating = mr.Rating;
            movie.Edited = mr.Edited;
            movie.LentTo = mr.LentTo;
            movie.Note = mr.Note;
            context.SaveChanges();
            return View("EditConfirmation", movie);
        }


        //shows the MyPodcasts page
        public IActionResult MyPodcasts()
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
