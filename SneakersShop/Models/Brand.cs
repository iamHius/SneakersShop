using System.ComponentModel.DataAnnotations;

namespace SneakersShop.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        [StringLength(100)]
        public string? BrandName { get; set; }
    }
}
