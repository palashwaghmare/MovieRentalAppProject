using Microsoft.EntityFrameworkCore;
using MovieRentalAppProject.Models;

namespace MovieRentalAppProject.AppDbContext
{
    public class MovieDbContext : DbContext
    {

        public MovieDbContext(DbContextOptions<MovieDbContext> Context) : base(Context)
        {
            
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.UserBookings)
                .WithOne(b => b.user);
                
              
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.bookings)
                .WithOne(b => b.user)
                .HasForeignKey(b => b.userId );

            modelBuilder.Entity<MovieModel>()
                .HasMany(m => m.bookings)
                .WithOne(b => b.movie)
                .HasForeignKey(b => b.movieId);
            

        }

        public DbSet<UserModel> users { get; set; }
        public DbSet<BookingModel> bookings { get; set; }

       public DbSet<MovieModel> movie { get; set; }






    }
}
