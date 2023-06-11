using MovieRentalAppProject.Models;

namespace MovieRentalAppProject.Services
{
    public interface IUserServices
    {
        bool AddUser(UserModel user);

        object GetUserByName(string userName);

        UserModel GetUserName(string userName);

        UserModel CheckLogin(string userName, string password);

        List<MovieModel> GetMoviesBookedByUser(int id);

        UserModel GetUserProfile(int userId);
        bool UpdateUserProfile(UserModel model);

    }
}