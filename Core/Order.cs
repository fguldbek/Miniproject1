using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        
        public int BuyerId { get; set; }
        
        public int UserId { get; set; }

        public decimal Price { get; set; } = 0;

        public int Amount { get; set; } = 1;

        public string Description { get; set; } = "";
        
        public string? ImageUrl { get; set; }

        public string? Category { get; set; } = "Clothing";

        public string Room { get; set; } = "Room 12";
        
        public bool Status { get; set; } = true; 

    }
}