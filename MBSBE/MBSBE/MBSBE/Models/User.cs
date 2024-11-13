using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBSBE.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string AlternativeNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int KW_Allowed { get; set; }
        public int BasePrice { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string PinCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public UserType UserType { get; set; } = UserType.None;
        public string City { get; set; } = string.Empty;
        // Navigation property
        public ICollection<Movie>? Movies { get; set; }
    }
}
