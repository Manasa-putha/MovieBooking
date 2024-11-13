using System.ComponentModel.DataAnnotations;

namespace MBSBE.Models
{
    public class Shows
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ShowTimings { get; set; } = string.Empty;
        public int No_of_seats { get; set; }
        public int Price { get; set; }
        public int Screen_Number { get; set; }
        public int MovieId { get; set; }
        //public Movie? Movie { get; set; }
    }
}
