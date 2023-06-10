
using Microsoft.EntityFrameworkCore;
using MovieRentalAppProject.AppDbContext;
using MovieRentalAppProject.Models;

namespace MovieRentalAppProject.Repository
{
    public class UserRepository : IUserRepository
    {
        MovieDbContext _movieDbContext;

        public UserRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }


        public bool AddUser(UserModel user)
        {
            _movieDbContext.users.Add(user);
            return _movieDbContext.SaveChanges() == 1 ? true : false; 
        }

        /*public string GetPassword(string password)
        {
            return _movieDbContext.users.Where(p => p.userPassword == password).ToString();
        }*/

        public UserModel GetByUserName(string username)
        {
            return _movieDbContext.users.FirstOrDefault(u => u.userName.Equals(username));
        }

        object IUserRepository.GetUserByName(string userName)
        {
            return _movieDbContext.users.Where(p => p.userName == userName).FirstOrDefault();
        }

        

        /*public async Task<UserModel> GetUserByUsernameAsync(string username)
        {
            return await _movieDbContext.users.FirstOrDefaultAsync(u => u.userName == username);
        }*/
    }
}
