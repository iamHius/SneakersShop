using System.ComponentModel.DataAnnotations;

namespace SneakersShop.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string? CategoryName { get; set; }
        [Required]
        [StringLength(200)]
        public string? CategoryPhoto { get; set; }

        public int? CategoryOrder { get; set; }

    }
}
