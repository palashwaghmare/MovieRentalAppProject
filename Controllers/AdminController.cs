using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MovieRentalAppProject.Models;
using MovieRentalAppProject.Services;

namespace MovieRentalAppProject.Controllers
{
    public class AdminController : Controller
    {

        private readonly IMovieServices _movieServices;
        private readonly IBookingServices _bookingsServices;

        public AdminController(IMovieServices movieServices , IBookingServices bookingServices)
        {
            
            _movieServices = movieServices;
            _bookingsServices = bookingServices;
            

        }

        public IActionResult GetAllBookings()
        {
            List<BookingModel> bookings = _bookingsServices.GetAllBookings();
            return View(bookings);
        }
        public IActionResult Allmovies()
        {
            List<MovieModel> allMovies = _movieServices.GetAllMovies();
            return View(allMovies);
        }


        [HttpGet]
        public IActionResult AddMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovies(MovieModel movie ,IFormFile imageFile)
        {
            if(imageFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    movie.ImageData = memoryStream.ToArray();
                }
            }

            bool addMovies = _movieServices.AddMovies(movie);
            return RedirectToAction("Allmovies");
            
        }
       

        


        [HttpGet]
        public IActionResult UpdateMovies(int id)
        {
            MovieModel movie = _movieServices.GetMovieById(id);
            if(movie == null )
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public IActionResult UpdateMovies(MovieModel movie , IFormFile imageFile)
        {
            
            if (movie != null && imageFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    movie.ImageData = memoryStream.ToArray();
                }
                bool updateMovie = _movieServices.UpdateMovies(movie);
                return RedirectToAction("Allmovies");
            }
            else
            {
                ModelState.AddModelError("", "Movie Not Found");
            }

            return View(movie);
        }

        [HttpGet]
       /* public IActionResult GetMoviesByCategory(int categoryId)
        {
            return View();
        }*/

        [HttpGet]
        public IActionResult DeleteMovies(int id)
        {
            MovieModel movie = _movieServices.GetMovieById(id);
            if(movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }


        [HttpPost]
        public IActionResult DeletedMovies(int id)
        {
            bool deletedMovie = _movieServices.DeletedMovies(id);
            if (deletedMovie)
            {
                return RedirectToAction("Allmovies");
            }
            else
            {
                return NotFound();
            }

            
        }


        [HttpGet]
        public IActionResult Bookings(int id)
        { 
            List<BookingModel> bookings = _movieServices.GetAllBookingsForMovie(id);
            return View(bookings);
        }

        [HttpGet]
        public IActionResult GetUserBookingsDetails(int id )
        {
            UserModel user = _movieServices.GetUserWithMovie(id);
           // MovieModel movie = _movieServices.GetMovieById();


                return View(user);
        }

        [HttpDelete]
        public IActionResult DeleteBookingForUser(int uid, int bid)
        {
            bool delete = _movieServices.DeleteBookingForUser(uid, bid);

            if (delete)
            {
                return RedirectToAction("GetAllBookings");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult DeleteBookings(int id)
        {
            BookingModel booking = _bookingsServices.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [HttpPost]
        public IActionResult DeleteConfirmedBooking(BookingModel model)
        {
            _bookingsServices.DeleteBooking(model.bookingId);
            return RedirectToAction("Allmovies");
        }




    }
}
