using MovieRentalAppProject.Models;

namespace MovieRentalAppProject.Services
{
    public interface IMovieServices
    {
        bool AddMovies(MovieModel movie);
        MovieModel GetMovieById(int id);

        bool UpdateMovies(MovieModel movie);

        bool DeletedMovies(int id);
        List<MovieModel> GetAllMovies();

        List<BookingModel> GetAllBookingsForMovie(int movieId);

        UserModel  GetUserWithMovie(int userId);


        bool DeleteBookingForUser(int userId, int bookingId);




    }
}
