﻿// <auto-generated />
using System;
using MBSBE.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MBSBE.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240722142425_data")]
    partial class data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MBSBE.Models.Booking", b =>
                {
                    b.Property<string>("TicketId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("ShowId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("ShowId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            TicketId = "1",
                            NumberOfSeats = 3,
                            ShowId = 3,
                            UserId = 2
                        },
                        new
                        {
                            TicketId = "2",
                            NumberOfSeats = 5,
                            ShowId = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("MBSBE.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "BlockBuster",
                            Director = "Thrivikram",
                            Genre = "Thriller",
                            ImageUrl = "assets/images/movie.jpg",
                            MovieName = "Pushpa"
                        },
                        new
                        {
                            Id = 2,
                            Description = "BlockBuster",
                            Director = "Rajamouli",
                            Genre = "Thriller,suspense",
                            ImageUrl = "assets/images/bahu.jpg",
                            MovieName = "Bahubali"
                        },
                        new
                        {
                            Id = 3,
                            Description = "BlockBuster",
                            Director = "Thrivikram",
                            Genre = "Thriller",
                            ImageUrl = "assets/images/guntur.jpg",
                            MovieName = "Guntur Karam"
                        },
                        new
                        {
                            Id = 4,
                            Description = "BlockBuster",
                            Director = "A.R.Viswan",
                            Genre = "Thriller",
                            ImageUrl = "assets/images/kalki.jpg",
                            MovieName = "Kalki"
                        });
                });

            modelBuilder.Entity("MBSBE.Models.Shows", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("No_of_seats")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Screen_Number")
                        .HasColumnType("int");

                    b.Property<string>("ShowTimings")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Shows");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 1,
                            No_of_seats = 50,
                            Price = 500,
                            Screen_Number = 1,
                            ShowTimings = "Morning Show",
                            StartDate = new DateTime(2024, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 1,
                            No_of_seats = 100,
                            Price = 1000,
                            Screen_Number = 2,
                            ShowTimings = "Evening Show",
                            StartDate = new DateTime(2024, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            EndDate = new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 2,
                            No_of_seats = 75,
                            Price = 500,
                            Screen_Number = 2,
                            ShowTimings = "Afternoon Show",
                            StartDate = new DateTime(2024, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            EndDate = new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 3,
                            No_of_seats = 75,
                            Price = 500,
                            Screen_Number = 2,
                            ShowTimings = "Afternoon Show",
                            StartDate = new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            EndDate = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 4,
                            No_of_seats = 75,
                            Price = 500,
                            Screen_Number = 2,
                            ShowTimings = "Afternoon Show",
                            StartDate = new DateTime(2024, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MBSBE.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlternativeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BasePrice")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KW_Allowed")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "AP",
                            AlternativeNumber = "12345",
                            BasePrice = 0,
                            City = "Kadapa",
                            CreatedAt = new DateTime(2024, 6, 11, 13, 28, 12, 0, DateTimeKind.Unspecified),
                            Email = "admin@gmail.com",
                            KW_Allowed = 0,
                            MobileNumber = "1234567890",
                            Password = "admin1234",
                            PinCode = "12345",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2024, 7, 3, 9, 20, 12, 0, DateTimeKind.Unspecified),
                            UserName = "Admin",
                            UserType = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Address = "AP",
                            AlternativeNumber = "12345",
                            BasePrice = 0,
                            City = "Kurnool",
                            CreatedAt = new DateTime(2024, 3, 6, 13, 30, 12, 0, DateTimeKind.Unspecified),
                            Email = "sai@gmail.com",
                            KW_Allowed = 0,
                            MobileNumber = "1234567890",
                            Password = "sai1234",
                            PinCode = "54321",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2024, 6, 12, 9, 20, 12, 0, DateTimeKind.Unspecified),
                            UserName = "sai",
                            UserType = "Customer"
                        },
                        new
                        {
                            Id = 3,
                            Address = "AP",
                            AlternativeNumber = "12345",
                            BasePrice = 0,
                            City = "Guntur",
                            CreatedAt = new DateTime(2024, 1, 6, 14, 30, 12, 0, DateTimeKind.Unspecified),
                            Email = "manu@gmail.com",
                            KW_Allowed = 0,
                            MobileNumber = "1234567890",
                            Password = "manu4321",
                            PinCode = "33333",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2024, 9, 3, 9, 20, 12, 0, DateTimeKind.Unspecified),
                            UserName = "manu",
                            UserType = "Customer"
                        },
                        new
                        {
                            Id = 4,
                            Address = "AP",
                            AlternativeNumber = "12345",
                            BasePrice = 0,
                            City = "Anantpur",
                            CreatedAt = new DateTime(2024, 3, 6, 20, 40, 12, 0, DateTimeKind.Unspecified),
                            Email = "rani@gmail.com",
                            KW_Allowed = 0,
                            MobileNumber = "1234567890",
                            Password = "rani43",
                            PinCode = "55555",
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2024, 6, 3, 9, 20, 12, 0, DateTimeKind.Unspecified),
                            UserName = "Rani",
                            UserType = "Customer"
                        });
                });

            modelBuilder.Entity("MBSBE.Models.Booking", b =>
                {
                    b.HasOne("MBSBE.Models.Shows", "Show")
                        .WithMany()
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MBSBE.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MBSBE.Models.Movie", b =>
                {
                    b.HasOne("MBSBE.Models.User", null)
                        .WithMany("Movies")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MBSBE.Models.Shows", b =>
                {
                    b.HasOne("MBSBE.Models.Movie", null)
                        .WithMany("Shows")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MBSBE.Models.Movie", b =>
                {
                    b.Navigation("Shows");
                });

            modelBuilder.Entity("MBSBE.Models.User", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
