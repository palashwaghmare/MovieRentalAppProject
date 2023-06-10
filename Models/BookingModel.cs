using System.ComponentModel.DataAnnotations;

namespace MovieRentalAppProject.Models
{
    public class BookingModel
    {
        

        [Key]
        public int bookingId { get; set; }

        public DateTime bookingTime { get; set; }
        
        public int userId { get; set; }
        public UserModel user { get; set; }

        public int movieId { get; set; }
        public MovieModel movie { get; set; }

    }
}
