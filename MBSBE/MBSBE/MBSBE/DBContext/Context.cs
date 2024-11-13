

using MBSBE.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MBSBE.DBContext
{
    public class Context:DbContext
    {
        public DbSet<User> Users{ get; set;}
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Shows> Shows { get; set;}
        public DbSet<Booking> Bookings { get; set; }
        public Context(DbContextOptions<Context> options):base(options) {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Movie>()
            // .HasOne(m => m.User)
            // .WithMany(u => u.Movies)
            // .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    MobileNumber = "1234567890",
                    UserType = UserType.Admin,
                    Password = "admin1234",
                    CreatedAt = new DateTime(2024, 06, 11, 13, 28, 12),
                    UpdatedAt = new DateTime(2024, 07, 03, 09, 20, 12),
                    PinCode = "12345",
                    City = "Kadapa",
                    Address = "AP",
                    AlternativeNumber = "12345",


                },
         new User()
         {
             Id = 2,
             UserName = "sai",
             Email = "sai@gmail.com",
             MobileNumber = "1234567890",
             Password = "sai1234",
             UserType = UserType.Customer,
             CreatedAt = new DateTime(2024, 03, 06, 13, 30, 12),
             UpdatedAt = new DateTime(2024, 06, 12, 09, 20, 12),
             PinCode = "54321",
             City = "Kurnool",
             Address = "AP",
             AlternativeNumber = "12345",

         },
         new User()
         {
             Id = 3,
             UserName = "manu",
             Email = "manu@gmail.com",
             MobileNumber = "1234567890",
             UserType = UserType.Customer,
             Password = "manu4321",
             CreatedAt = new DateTime(2024, 01, 06, 14, 30, 12),
             UpdatedAt = new DateTime(2024, 09, 03, 09, 20, 12),
             PinCode = "33333",
             City = "Guntur",
             Address = "AP",
             AlternativeNumber = "12345",


         },
           new User()
           {
               Id = 4,
               UserName = "Rani",
               Email = "rani@gmail.com",
               MobileNumber = "1234567890",
               UserType = UserType.Customer,
               Password = "rani43",
               CreatedAt = new DateTime(2024, 03, 06, 20, 40, 12),
               UpdatedAt = new DateTime(2024, 06, 03, 09, 20, 12),
               PinCode = "55555",
               City = "Anantpur",
               Address = "AP",
               AlternativeNumber = "12345",

           });

            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = 1,
                    MovieName = "Pushpa",
                    Director = "Thrivikram",
                    Description = "BlockBuster",
                    Genre = "Thriller",
                    ImageUrl = "assets/images/movie.jpg"
                    //UserId=1,

                },
                new Movie()
                {
                    Id = 2,
                    MovieName = "Bahubali",
                    Director = "Rajamouli",
                    Description = "BlockBuster",
                    Genre = "Thriller,suspense",
                    ImageUrl = "assets/images/bahu.jpg"
                    //UserId=1,

                },
                  new Movie()
                  {
                      Id = 3,
                      MovieName = "Guntur Karam",
                      Director = "Thrivikram",
                      Description = "BlockBuster",
                      Genre = "Thriller",
                      ImageUrl = "assets/images/guntur.jpg"
                      //UserId=1,

                  },
                    new Movie()
                    {
                        Id = 4,
                        MovieName = "Kalki",
                        Director = "A.R.Viswan",
                        Description = "BlockBuster",
                        Genre = "Thriller",
                        ImageUrl = "assets/images/kalki.jpg"
                        //UserId=1,

                    });
            modelBuilder.Entity<Shows>().HasData(
                new Shows()
                {
                    Id = 1,
                   // StartDate = DateTime.Now,
                    StartDate = new DateTime(2024, 07, 19),
                    EndDate = new DateTime(2024, 08, 10),
                    //EndDate = DateTime.Now,
                    MovieId = 1,
                    No_of_seats = 50,
                    Price = 500,
                    Screen_Number = 1,
                    ShowTimings = "Morning Show",
                },
                 new Shows()
                 {
                     Id = 2,
                     //StartDate = DateTime.Now,
                     //EndDate = DateTime.Now,
                     StartDate = new DateTime(2024, 07, 19),
                     EndDate = new DateTime(2024, 08, 01),
                     MovieId = 1,
                     No_of_seats = 100,
                     Price = 1000,
                     Screen_Number = 2,
                     ShowTimings = "Evening Show",
                 },
                  new Shows()
                  {
                      Id = 3,
                      //StartDate = DateTime.Now,
                      //EndDate = DateTime.Now,
                      StartDate = new DateTime(2024, 07, 18),
                      EndDate = new DateTime(2024, 09, 10),
                      MovieId = 2,
                      No_of_seats = 75,
                      Price = 500,
                      Screen_Number = 2,
                      ShowTimings = "Afternoon Show",
                  },
                   new Shows()
                   {
                       Id = 4,
                       //StartDate = DateTime.Now,
                       //EndDate = DateTime.Now,
                       StartDate = new DateTime(2024, 07, 12),
                       EndDate = new DateTime(2024, 09, 20),
                       MovieId = 3,
                       No_of_seats = 75,
                       Price = 500,
                       Screen_Number = 2,
                       ShowTimings = "Afternoon Show",
                   },
                      new Shows()
                      {
                          Id = 5,
                          //StartDate = DateTime.Now,
                          //EndDate = DateTime.Now,
                          StartDate = new DateTime(2024, 05, 19),
                          EndDate = new DateTime(2024, 10, 20),
                          MovieId = 4,
                          No_of_seats = 75,
                          Price = 500,
                          Screen_Number = 2,
                          ShowTimings = "Afternoon Show",
                      });

            modelBuilder.Entity<Booking>().HasData(
             new Booking()
             {
                 TicketId="1",
                  UserId = 2,
                  NumberOfSeats = 3,
                  ShowId = 3,
             },
                new Booking()
                {
                    TicketId="2",
                    UserId = 3,
                    NumberOfSeats = 5,
                    ShowId = 3,
                });
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<ScreenType>().HaveConversion<string>();
            configurationBuilder.Properties<UserType>().HaveConversion<string>();
        }
    }
}
