using MovieRentalAppProject.Models;

namespace MovieRentalAppProject.Services
{
    public interface IBookingServices
    {
        List<BookingModel> GetAllBookings();
        void AddBooking(BookingModel booking);
        BookingModel GetBookingById(int bookingId);
        void UpdateBooking(BookingModel booking);
        void DeleteBooking(int bookingId);
    }
}
