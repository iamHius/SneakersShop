using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SneakersShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(100)]
        public string? Description { get; set; }
        [Required]
        [Column(TypeName= "decimal(8,3)")]
        public decimal ProductPirce { get; set; }
        public bool BestSeller { get; set; }

        [ForeignKey("Category")]
        public int CategoryId {  get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [ForeignKey("Color")]
        public int ColorId { get; set; }

        [ForeignKey("Gender")]
        public int GenderId { get; set; }

        [ForeignKey("Size")]
        public int SizeId { get; set; }

        public Category? Category { get; set; }
        public Brand? Brand { get; set; }
        public Color? Color { get; set; }
        public Gender? Gender { get; set; }
        public Size? Size { get; set; }


    }
}
