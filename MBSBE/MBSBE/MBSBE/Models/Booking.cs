using System.ComponentModel.DataAnnotations;

namespace MBSBE.Models
{
    public class Booking
    {
        [Key]
        public string TicketId { get; set; }
        public int UserId { get; set; }
        public int ShowId { get; set; }
        public int NumberOfSeats { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Shows Show { get; set; }
    }
}
