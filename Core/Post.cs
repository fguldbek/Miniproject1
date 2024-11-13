using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;


namespace Core;


    public class Post
    {
       
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public static string Name { get; set; }
        
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Price must be positive")]
        public static double Price { get; set; }
        
        [Required]
        public static string? Description { get; set; }
        
        public static string? ImageUrl { get; set; }
        

        public static string Status { get; set; } = "Active";
        
        
    }
