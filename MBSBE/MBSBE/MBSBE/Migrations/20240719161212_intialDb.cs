using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MBSBE.Migrations
{
    public partial class intialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShowTimings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    No_of_seats = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Screen_Number = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternativeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KW_Allowed = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    TicketId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Bookings_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Genre", "MovieName", "UserId" },
                values: new object[,]
                {
                    { 1, "BlockBuster", "Thrivikram", "Thriller", "Pushpa", null },
                    { 2, "BlockBuster", "Rajamouli", "Thriller,supense", "Bahubali", null },
                    { 3, "BlockBuster", "Thrivikram", "Thriller", "Guntur Karam", null },
                    { 4, "BlockBuster", "A.R.Viswan", "Thriller", "Kalki", null }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "EndDate", "MovieId", "No_of_seats", "Price", "Screen_Number", "ShowTimings", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 19, 21, 42, 12, 738, DateTimeKind.Local).AddTicks(5789), 1, 50, 500, 1, "Morning Show", new DateTime(2024, 7, 19, 21, 42, 12, 738, DateTimeKind.Local).AddTicks(5780) },
                    { 2, new DateTime(2024, 7, 19, 21, 42, 12, 738, DateTimeKind.Local).AddTicks(5791), 1, 100, 1000, 2, "Evening Show", new DateTime(2024, 7, 19, 21, 42, 12, 738, DateTimeKind.Local).AddTicks(5791) },
                    { 3, new DateTime(2024, 7, 19, 21, 42, 12, 738, DateTimeKind.Local).AddTicks(5792), 2, 75, 500, 2, "Afternoon Show", new DateTime(2024, 7, 19, 21, 42, 12, 738, DateTimeKind.Local).AddTicks(5792) },
                    { 4, new DateTime(2024, 7, 19, 21, 42, 12, 738, DateTimeKind.Local).AddTicks(5794), 3, 75, 500, 2, "Afternoon Show", new DateTime(2024, 7, 19, 21, 42, 12, 738, DateTimeKind.Local).AddTicks(5793) },
                    { 5, new DateTime(2024, 7, 19, 21, 42, 12, 738, DateTimeKind.Local).AddTicks(5795), 4, 75, 500, 2, "Afternoon Show", new DateTime(2024, 7, 19, 21, 42, 12, 738, DateTimeKind.Local).AddTicks(5794) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "AlternativeNumber", "BasePrice", "City", "CreatedAt", "Email", "KW_Allowed", "MobileNumber", "Password", "PinCode", "RefreshToken", "RefreshTokenExpiryTime", "Token", "UpdatedAt", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, "AP", "12345", 0, "Kadapa", new DateTime(2024, 6, 11, 13, 28, 12, 0, DateTimeKind.Unspecified), "admin@gmail.com", 0, "1234567890", "admin1234", "12345", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 7, 3, 9, 20, 12, 0, DateTimeKind.Unspecified), "Admin", 1 },
                    { 2, "AP", "12345", 0, "Kurnool", new DateTime(2024, 3, 6, 13, 30, 12, 0, DateTimeKind.Unspecified), "sai@gmail.com", 0, "1234567890", "sai1234", "54321", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 6, 12, 9, 20, 12, 0, DateTimeKind.Unspecified), "sai", 2 },
                    { 3, "AP", "12345", 0, "Guntur", new DateTime(2024, 1, 6, 14, 30, 12, 0, DateTimeKind.Unspecified), "manu@gmail.com", 0, "1234567890", "manu4321", "33333", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 9, 3, 9, 20, 12, 0, DateTimeKind.Unspecified), "manu", 2 },
                    { 4, "AP", "12345", 0, "Anantpur", new DateTime(2024, 3, 6, 20, 40, 12, 0, DateTimeKind.Unspecified), "rani@gmail.com", 0, "1234567890", "rani43", "55555", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 6, 3, 9, 20, 12, 0, DateTimeKind.Unspecified), "Rani", 2 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "TicketId", "NumberOfSeats", "ShowId", "UserId" },
                values: new object[] { "1", 2, 3, 2 });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "TicketId", "NumberOfSeats", "ShowId", "UserId" },
                values: new object[] { "2", 5, 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShowId",
                table: "Bookings",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UserId",
                table: "Movies",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
