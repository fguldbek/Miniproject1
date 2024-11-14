using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core;
public class User
{
    public int UserId { get; set; }
    
    public int BuyerId { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Username must be between 2 and 50 characters.")]
    public string Username { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 7, ErrorMessage = "Password must be between 2 and 50 characters.")]
    public string Password { get; set; }
    
    public string Role { get; set; }
}