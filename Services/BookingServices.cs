using MovieRentalAppProject.Models;
using MovieRentalAppProject.Repository;

namespace MovieRentalAppProject.Services
{
    public class BookingServices : IBookingServices
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingServices(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
            
        }

        public List<BookingModel> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings();
        }

        public void AddBooking(BookingModel booking)
        {
            _bookingRepository.AddBooking(booking);
        }

        public BookingModel GetBookingById(int bookingId)
        {
            return _bookingRepository.GetBookingById(bookingId);
        }

        public void UpdateBooking(BookingModel booking)
        {
            _bookingRepository.UpdateBooking(booking);
        }

        public void DeleteBooking(int bookingId)
        {
            _bookingRepository.DeleteBooking(bookingId);
        }
    }
}
