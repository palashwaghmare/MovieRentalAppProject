using MovieRentalAppProject.Models;

namespace MovieRentalAppProject.Services
{
    public interface IUserServices
    {
        bool AddUser(UserModel user);

        object GetUserByName(string userName);

        UserModel GetUserName(string userName);

        UserModel CheckLogin(string userName, string password);

        // string GetPassword(string password);

        //Task<UserModel> LoginAsync(string username, string password);   
    }
}