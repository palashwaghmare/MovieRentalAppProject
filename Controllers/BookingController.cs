using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRentalAppProject.Models;
using MovieRentalAppProject.Services;

namespace MovieRentalAppProject.Controllers
{
    
    public class BookingController : Controller
    {
        private readonly IBookingServices _bookingService;
        private readonly IMovieServices _movieService;
        public BookingController(IBookingServices bookingService , IMovieServices movieServices)
        {
            _bookingService = bookingService;
            _movieService = movieServices;
        }

        public IActionResult MovieDetails(int id)
        {
            MovieModel movie = _movieService.GetMovieById(id);
            if(movie.movieId == id)
            {
                TempData["ShowAlert"] = "Movie Already Added";
            }
           

            return View(movie);
        }

        [HttpGet]
        public IActionResult AddBookings(int id)
        {
            BookingModel booking = new BookingModel();

            booking.bookingTime = DateTime.Now;
            booking.movieId = id;
            booking.userId =(int)HttpContext.Session.GetInt32("UserId");

            return View(booking);
        }
        
        [HttpPost]
        public IActionResult AddBookings(BookingModel booking)
        {

            
                _bookingService.AddBooking(booking);
            return RedirectToAction("AllmoviesUser","User");
            


           
        }

        [HttpGet]
        public IActionResult EditBookings(int id)
        {
            BookingModel booking = _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }

           
            return View(booking);
        }

        [HttpPost]
        public IActionResult EditBookings(BookingModel booking)
        {
            if (ModelState.IsValid)
            {
                _bookingService.UpdateBooking(booking);
                return RedirectToAction("Index");
            }

           
            return View(booking);
        }

        [HttpGet]
        public IActionResult DeleteBookings(int id)
        {
            BookingModel booking = _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [HttpPost]
        public IActionResult DeleteConfirmedBooking(BookingModel model)
        {
            _bookingService.DeleteBooking(model.bookingId);
            return RedirectToAction("Allmovies");
        }


    }
}
