using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MBSBE.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "TicketId",
                keyValue: "1",
                column: "NumberOfSeats",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "TicketId",
                keyValue: "2",
                column: "NumberOfSeats",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "TicketId",
                keyValue: "1",
                column: "NumberOfSeats",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "TicketId",
                keyValue: "2",
                column: "NumberOfSeats",
                value: 50);
        }
    }
}
