using Microsoft.AspNetCore.Mvc;
using MovieRentalAppProject.Models;
using MovieRentalAppProject.Services;

namespace MovieRentalAppProject.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserServices _userServices;

        private readonly IMovieServices _movieServices;

        public UserController(IUserServices userServices, IMovieServices movieServices)
        {
            _userServices = userServices;
            _movieServices = movieServices;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            bool addUser = _userServices.AddUser(user);
            if (addUser)
            {
                TempData["SuccessMessage"] = "Registration Successful. Please Login to continue";
                return RedirectToAction("LogIn");
            }
            else
            {
                TempData["ErrorMessage"] = "Registration Failed. Try Again.";
                return RedirectToAction("Register");
            }
            
        }

       [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(UserModel userModel)
       {
            if(userModel.userName == "admin" && userModel.userName == "admin")
            {
                HttpContext.Session.SetString("UserName", userModel.userName);
                return RedirectToAction("Allmovies", "Admin");

            }
            else
            {
                UserModel user = _userServices.CheckLogin(userModel.userName, userModel.userPassword);
                HttpContext.Session.SetString("UserName", user.userName);

                HttpContext.Session.SetInt32("UserId", user.userId);

                if (user != null)
                {
                    return RedirectToAction("AllmoviesUser");
                }
                else
                {
                    TempData["ErrorMessage"] = "Inavalid User Credentials";
                    return RedirectToAction("LogIn");
                }


            }



        }


        public IActionResult AllmoviesUser()
        {
            List<MovieModel> allMovies = _movieServices.GetAllMovies();
            return View(allMovies);
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LogIn","User");
        }

        public IActionResult GetMoviesBookedByUser(int id)
        {
            var movies = _userServices.GetMoviesBookedByUser(id);
            return View(movies);    
        }


    }
}
