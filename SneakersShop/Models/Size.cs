using System.ComponentModel.DataAnnotations;

namespace SneakersShop.Models
{
    public class Size
    {
        [Key]
        public int SizeId { get; set; }
        [Required]
        [StringLength(100)]
        public string? SizeName { get; set; }
    }
}
