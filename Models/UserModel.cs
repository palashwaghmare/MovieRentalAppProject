using System.ComponentModel.DataAnnotations;

namespace MovieRentalAppProject.Models
{
    public class UserModel
    {
        [Key]
        [Required]
        public int userId { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string userPassword { get; set; }
        [Required]
        [Compare("userPassword")]
        public string confirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string userEmail { get; set; }
        [Required]
        public string userLocation { get; set; }
        [Required]
        public string gender { get; set; }

       public ICollection<BookingModel> bookings { get; set; }


    }
}
