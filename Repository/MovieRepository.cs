using Microsoft.EntityFrameworkCore;
using MovieRentalAppProject.AppDbContext;
using MovieRentalAppProject.Models;

namespace MovieRentalAppProject.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieDbContext _movieDbcontext;

        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbcontext = movieDbContext;
            
        }


        public bool AddMovies(MovieModel movie)
        {
            _movieDbcontext.movie.Add(movie);
            return _movieDbcontext.SaveChanges() == 1 ? true : false;
        }

        public object GetMovieByName(string movieName)
        {
            return _movieDbcontext.movie.Where(m => m.movieName == movieName).FirstOrDefault();
        }

        public bool UpdateMovies(MovieModel movie)
        {
            MovieModel existingMovie = GetMovieById(movie.movieId);
            if(existingMovie == null) 
            {
                return false;

            }
            existingMovie.movieName = movie.movieName;
            existingMovie.rentPrice = movie.rentPrice;
            existingMovie.movieCategory = movie.movieCategory;
            existingMovie.actors = movie.actors;
            existingMovie.director = movie.director;
            existingMovie.ImageData = movie.ImageData;
           
            _movieDbcontext.movie.Update(existingMovie);
            return _movieDbcontext.SaveChanges() == 1;
        }


        public MovieModel GetMovieById(int id)
        {
            return _movieDbcontext.movie.FirstOrDefault(m => m.movieId == id);
        }

        public object DeletedMovie(int id)
        {
            MovieModel movie = GetMovieById(id);
            if(movie == null)
            {
                return false;
            }

            _movieDbcontext.movie.Remove(movie);
            return _movieDbcontext.SaveChanges() == 1;


        }

        public List<MovieModel> GetAllMovies()
        {
            return _movieDbcontext.movie.ToList();
        }

        public List<BookingModel> GetAllBookingForMovie(int movieId)
        {
            return _movieDbcontext.bookings.Where( b=> b.movieId == movieId).Select(b=> new BookingModel
            {
                bookingId = b.bookingId,
                movieId = b.movieId,
                userId = b.userId,
                bookingTime = b.bookingTime
            
            }).ToList();
        }

        public UserModel GetUserWithMovie(int userId)
        {
            return _movieDbcontext.users.Include(u => u.bookings).FirstOrDefault(u => u.userId == userId);
        }


        public bool DeleteBookingForUser(int userId, int bookingId)
        {
            BookingModel booking = _movieDbcontext.bookings.FirstOrDefault( b => b.bookingId == bookingId && b.userId == userId);

            if(booking != null)
            {
                _movieDbcontext.bookings.Remove(booking);
                _movieDbcontext.SaveChanges();
                return true;
            }

            return false;
        }



    }
}
