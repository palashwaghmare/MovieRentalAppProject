using MovieRentalAppProject.Models;

namespace MovieRentalAppProject.Repository
{
    public interface IMovieRepository
    {
        bool AddMovies(MovieModel movie);
        object DeletedMovie(int id);
        List<MovieModel> GetAllMovies();
        MovieModel GetMovieById(int id);
        object GetMovieByName(string movieName);
        bool UpdateMovies(MovieModel movie);

        List<BookingModel> GetAllBookingForMovie(int movieId);

        UserModel GetUserWithMovie(int userId);

        bool DeleteBookingForUser(int userId, int bookingId);
    }
}
