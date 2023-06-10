using MovieRentalAppProject.Models;

namespace MovieRentalAppProject.Repository
{
    public interface IUserRepository
    {
        bool AddUser(UserModel user);
       // string GetPassword(string password);
        object GetUserByName(string userName);
        UserModel GetByUserName(string userName);

        //Task<UserModel> GetUserByUsernameAsync(string username);
    }
}
