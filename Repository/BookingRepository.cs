using MovieRentalAppProject.AppDbContext;
using MovieRentalAppProject.Models;

namespace MovieRentalAppProject.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MovieDbContext _dbContext;

        public BookingRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookingModel> GetAllBookings()
        {
            return _dbContext.bookings.ToList();
        }

        public void AddBooking(BookingModel booking)
        {
            _dbContext.bookings.Add(booking);
            _dbContext.SaveChanges();
        }

        public BookingModel GetBookingById(int bookingId)
        {
            return _dbContext.bookings.FirstOrDefault(b => b.bookingId == bookingId);
        }

        public void UpdateBooking(BookingModel booking)
        {
            _dbContext.bookings.Update(booking);
            _dbContext.SaveChanges();
        }

        public void DeleteBooking(int bookingId)
        {
            var booking = GetBookingById(bookingId);
            if (booking != null)
            {
                _dbContext.bookings.Remove(booking);
                _dbContext.SaveChanges();
            }
        }
    }
}
