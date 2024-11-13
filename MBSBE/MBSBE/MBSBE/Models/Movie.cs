using System.ComponentModel.DataAnnotations;

namespace MBSBE.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        //public int UserId { get; set; }
        //[ForeignKey("UserId")]
        //public User User { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public ICollection<Shows> Shows { get; set; }
    }

}
