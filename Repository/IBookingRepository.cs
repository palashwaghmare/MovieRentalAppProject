using MovieRentalAppProject.Models;

namespace MovieRentalAppProject.Repository
{
    public interface IBookingRepository
    {

        List<BookingModel> GetAllBookings();
        void AddBooking(BookingModel booking);
        BookingModel GetBookingById(int bookingId);
        void UpdateBooking(BookingModel booking);
        void DeleteBooking(int bookingId);


    }
}
