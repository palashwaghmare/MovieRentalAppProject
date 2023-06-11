using MovieRentalAppProject.Models;
using MovieRentalAppProject.Repository;
using NuGet.Protocol.Core.Types;

namespace MovieRentalAppProject.Services
{
    public class UserServices : IUserServices
    {

        readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(UserModel user)
        {
            var userExists = _userRepository.GetUserByName(user.userName);
            if (userExists == null)
            {
                return _userRepository.AddUser(user);
            }
            return false;

        }

        public object GetUserByName(string userName)
        {
            return _userRepository.GetUserByName(userName);
        }

        public UserModel GetUserName(string userName)
        {
            return _userRepository.GetByUserName(userName);

        }

       public UserModel CheckLogin(string userName, string password) { 
            UserModel user = GetUserName(userName);

            if (user != null)
            {
                if(user.userPassword.Equals(password)) { 
                    return user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        
        }


        public List<MovieModel> GetMoviesBookedByUser(int id)
        {
            return _userRepository.GetMoviesBookedByUser(id);
        }




        public UserModel GetUserProfile(int userId)
        {
            return _userRepository.GetUserProfile(userId);
        }

        public bool UpdateUserProfile(UserModel model)
        {
            return _userRepository.UpdateUserProfile(model);
        }


        /*public string GetPassword(string password)
        {

            return _userRepository.GetPassword(password);

        }

        public string GetUserName(string username)
        {
            return _userRepository.GetUserName(username);
        }*/

        /* public async Task<UserModel> LoginAsync (string username, string password)
         {
             var user = await _userRepository.GetUserByUsernameAsync(username);

             if(user == null)
             {
                 return null;
             }

             bool isPasswordValid = VerifyPassword(password, user.userPassword);

             if(!isPasswordValid)
             {
                 return null;
             }

             return user;

         }
 */
        /* private bool VerifyPassword(string password , string upass)
         {
             if (password.Equals(upass))
             {
                 return true;
             }else
             {
                 return false;
             }
         }*/








    }
}
