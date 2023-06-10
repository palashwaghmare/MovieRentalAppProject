﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieRentalAppProject.AppDbContext;

#nullable disable

namespace MovieRentalAppProject.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieRentalAppProject.Models.BookingModel", b =>
                {
                    b.Property<int>("bookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookingId"));

                    b.Property<DateTime>("bookingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("bookingId");

                    b.HasIndex("movieId");

                    b.HasIndex("userId");

                    b.ToTable("bookings");
                });

            modelBuilder.Entity("MovieRentalAppProject.Models.MovieModel", b =>
                {
                    b.Property<int>("movieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("movieId"));

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("actors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("movieCategory")
                        .HasColumnType("int");

                    b.Property<string>("movieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rentPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("movieId");

                    b.ToTable("movie");
                });

            modelBuilder.Entity("MovieRentalAppProject.Models.UserModel", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<string>("confirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("MovieRentalAppProject.Models.BookingModel", b =>
                {
                    b.HasOne("MovieRentalAppProject.Models.MovieModel", "movie")
                        .WithMany("bookings")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieRentalAppProject.Models.UserModel", "user")
                        .WithMany("bookings")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movie");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MovieRentalAppProject.Models.MovieModel", b =>
                {
                    b.Navigation("bookings");
                });

            modelBuilder.Entity("MovieRentalAppProject.Models.UserModel", b =>
                {
                    b.Navigation("bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
