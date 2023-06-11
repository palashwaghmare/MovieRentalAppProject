
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

        

        public List<MovieModel> GetMoviesBookedByUser(int id)
        {
            return _movieDbContext.bookings.Where(b => b.userId == id).Select(b=> b.movie).ToList();
        }

        public UserModel GetUserProfile(int uId)
        {
            // Retrieve user profile from the database based on the userId
            var userProfile = _movieDbContext.users
                .Where(u => u.userId == uId)
                .Select(u => new UserModel
                {
                    userId = u.userId,
                    firstName = u.firstName,
                    lastName = u.lastName,
                    userEmail = u.userEmail,
                    userLocation = u.userLocation,
                    userPassword = u.userPassword,
                    confirmPassword = u.confirmPassword
                    
                    
                })
                .FirstOrDefault();

            return userProfile;
        }

        public bool UpdateUserProfile(UserModel model)
        {
            // Retrieve the user profile from the database
            var userProfile = _movieDbContext.users.FirstOrDefault(u => u.userId == model.userId);

            if (userProfile == null)
                return false;

            // Update the user profile with the new data
            userProfile.firstName = model.firstName;
            userProfile.lastName = model.lastName;
            userProfile.userEmail = model.userEmail;
           userProfile.userLocation= model.userLocation;
            userProfile.userPassword = model.userPassword;
            userProfile.confirmPassword = model.confirmPassword;

            _movieDbContext.SaveChanges();

            return true;
        }




        /*public async Task<UserModel> GetUserByUsernameAsync(string username)
        {
            return await _movieDbContext.users.FirstOrDefaultAsync(u => u.userName == username);
        }*/
    }
}
