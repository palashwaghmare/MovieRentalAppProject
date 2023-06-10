using MovieRentalAppProject.Models;
using MovieRentalAppProject.Repository;

namespace MovieRentalAppProject.Services
{
    public class MovieServices : IMovieServices
    {

        readonly IMovieRepository _movieRepository;

        public MovieServices(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public bool AddMovies(MovieModel movie)
        {
            var movieExist = _movieRepository.GetMovieByName(movie.movieName);

            if (movieExist == null)
            {
                return _movieRepository.AddMovies(movie);
            }
            return false;

        }

       
        public MovieModel GetMovieById(int id)
        {
            MovieModel movie = _movieRepository.GetMovieById(id);
            return movie;
        }

        public bool UpdateMovies(MovieModel movie)
        {
            var existingMovie = _movieRepository.UpdateMovies(movie);
            if(existingMovie == null)
            {
                return false;

            }
            else
            {
                _movieRepository.UpdateMovies(movie);
                return true;
            }
        }

        public bool DeletedMovies(int id)
        {
            var deleteMovie = _movieRepository.DeletedMovie(id);
            if(deleteMovie == null)
            {
                return false;
            }
            else
            {
                _movieRepository.DeletedMovie(id);
                return true;
            }

        }

        public List<MovieModel> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }


        public List<BookingModel> GetAllBookingsForMovie(int movieId)
        {
            return _movieRepository.GetAllBookingForMovie(movieId);
        }

        public UserModel GetUserWithMovie(int userId)
        {
            return _movieRepository.GetUserWithMovie(userId);
        }
    }
}
