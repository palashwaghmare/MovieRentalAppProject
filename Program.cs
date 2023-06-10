using Microsoft.EntityFrameworkCore;
using MovieRentalAppProject.AppDbContext;
using MovieRentalAppProject.Repository;
using MovieRentalAppProject.Services;

namespace MovieRentalAppProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            string con = builder.Configuration.GetConnectionString("localConnectionString");
            builder.Services.AddDbContext<MovieDbContext>(p=>p.UseSqlServer(con));
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IMovieServices, MovieServices>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IBookingServices, BookingServices>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
               //pattern: "{controller=AdminController}/{action=Allmovies}/{id?}");
               pattern: "{controller=UserController}/{action=Register}/{id?}");
            app.Run();
        }
    }
}