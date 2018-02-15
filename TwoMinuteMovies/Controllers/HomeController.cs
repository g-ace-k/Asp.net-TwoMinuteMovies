using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwoMinuteMovies.Models;

namespace TwoMinuteMovies.Controllers
{
    public class HomeController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: Movies
        public ActionResult Index(string searchString)
        {
            var movies = from m in db.Movies
                         select m;

            // Search by Title or Genre
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString) || s.Genre.Equals(searchString)).OrderBy(s => s.Genre);
            }

            return View(movies);
        }

    }
}