using MovieRentalAppProject.Constants;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalAppProject.Models
{
    public class MovieModel
    {
        [Key]
        public int movieId { get; set; }
        [Display(Name = "Movie Name ",
        Prompt = "Please Enter Movie Name", Description = "movieName")]
        public string movieName { get; set; }

        [Display(Name = "Movie Category ", 
        Prompt = "Please Enter Movie Category", Description = "movieCategory")]
        public MovieCategory movieCategory { get; set; }

        [Display(Name = "Movie Price ", 
        Prompt = "Please Enter Movie Price", Description = "moviePrice")]
        public string rentPrice { get; set; }

        [Display(Name = "Director Name ",
       Prompt = "Please Enter Director Name ", Description = "director")]
        public string director { get; set; }

        [Display(Name = "Actor Name ",
       Prompt = "Please Enter Actor Name ", Description = "actor")]
        public string actors { get; set; }

        [Display(Name = "Upload Movie Poster: ")]
        public byte[] ImageData { get; set; }


        public ICollection<BookingModel> bookings { get; set; }

    }
}
