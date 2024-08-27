using System.ComponentModel.DataAnnotations;

namespace SneakersShop.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }
        [Required]
        [StringLength(100)]
        public string? ColorName { get; set; }
    }
}
