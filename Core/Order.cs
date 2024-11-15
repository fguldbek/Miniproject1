using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string Name { get; set; } = "";
        
        public int BuyerId { get; set; }

        public int UserId { get; set; } = 0;
        
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; } = 0;

        public int Amount { get; set; } = 1;
        
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "You need to have a description")]
        public string Description { get; set; } = "";
        
        [Required]
        public string? ImageUrl { get; set; }

        [Required]
        public string? Category { get; set; } = "Clothing";
        
        [Required]
        public string Room { get; set; } = "Room 12";

        public string Status { get; set; } = "For Sale";

    }
}