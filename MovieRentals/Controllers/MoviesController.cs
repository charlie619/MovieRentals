using MovieRentals.Models;
using MovieRentals.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentals.Controllers
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class MoviesController : Controller
    {
        
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
            //var movies = _context.Movies.Include(x => x.GenreType).ToList();
            return View();
        }      

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            
            return View(viewModel);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(x => x.GenreType).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        
        public ActionResult NewMovie()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewModel = new NewMovieViewModel
            {
                GenreTypes = genreTypes
            };
            return View(viewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewMovieViewModel(movie)
            {               
               GenreTypes = _context.GenreTypes.ToList()
            };
            return View("NewMovie", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {       
                                
                    GenreTypes = _context.GenreTypes.ToList()
                };
                return View("NewMovie", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.NoAvailable = movie.NoInStock;
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == movie.Id);
                //TryUpdateModel(customerInDb);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreTypeId = movie.GenreTypeId;
                //movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NoInStock = movie.NoInStock;
            }

                _context.SaveChanges();            
            
            return RedirectToAction("Index", "Movies");
        }
    }
}