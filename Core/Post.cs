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
        

        public string? Status { get; set; } = "Active";

    }
