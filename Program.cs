using Microsoft.AspNetCore.Authorization;
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
            builder.Services.AddAuthentication("Cookie").AddCookie("Cookie", config =>
            {
                config.Cookie.Name = "MovieRentalAppProject.Cookie";
                config.Cookie.HttpOnly = true;
                config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                config.LoginPath = "/User/Login";
            });

            builder.Services.AddAuthorization(config =>
            {
                config.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });
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
               pattern: "{controller=User}/{action=Index}/{id?}");
            app.Run();
        }
    }
}