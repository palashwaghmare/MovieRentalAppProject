using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalAppProject.Models;
using MovieRentalAppProject.Services;
using Newtonsoft.Json;
using System.Text.Json;

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
                return RedirectToAction("Allmovies","Admin");

            }
            else
            {
                UserModel user = _userServices.CheckLogin(userModel.userName, userModel.userPassword);

                if (user != null)
                {
                    HttpContext.Session.SetString("UserName", user.userName);

                    HttpContext.Session.SetInt32("UserId", user.userId);


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

        [HttpGet]

        public IActionResult EditProfile()
        {
            try
            {
                int? userId = HttpContext.Session.GetInt32("UserId");
                if (!userId.HasValue)
                {
                    return RedirectToAction("LogIn", "User");
                }

                var userProfile = _userServices.GetUserProfile(userId.Value);

                if (userProfile == null)
                {
                    return NotFound();
                }

                return View(userProfile);
            }
            catch (InvalidOperationException ex)
            {
               
                return RedirectToAction("LogIn", "User");
            }
        }


        /*public IActionResult EditProfile()
        {
            
            
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            if(userId == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            var userProfile = _userServices.GetUserProfile(userId);

            if (userProfile == null)
                return NotFound();

            return View(userProfile);
        }*/

        [HttpPost]
        public IActionResult EditProfile(UserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = _userServices.UpdateUserProfile(model);

            if (result)
            {
                return RedirectToAction("AllmoviesUser");
            }
               
            else
            {
                ModelState.AddModelError("", "Failed to update profile. Please try again.");

                return View(model);
            }
            
        }

    }
}
