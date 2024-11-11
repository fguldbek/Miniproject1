using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;


namespace BlazorApp1.Model;


public class Post
{
    public class Product
    {
        public ObjectId Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string Name { get; set; }
        
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Price must be positive")]
        public double Price { get; set; }
        
        [Required]
        public string? Description { get; set; }
        
        public string? ImageUrl { get; set; }
        
        [Required]
        public List<string>? Category { get; set;}

        [Required]
        public Array Status { get; set; }

    }
}