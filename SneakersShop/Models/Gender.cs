using System.ComponentModel.DataAnnotations;

namespace SneakersShop.Models
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }
        [Required]
        [StringLength(100)]
        public string? GenderName { get; set; }
    }
}
