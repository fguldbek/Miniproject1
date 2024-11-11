using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

public class User
{
    public ObjectId Id { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
    public string Name { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Adress must be between 2 and 50 characters.")]
    public string Adress { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Email must be between 2 and 50 characters.")]
    public string Email { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Username must be between 2 and 50 characters.")]
    public string Username { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 7, ErrorMessage = "Password must be between 2 and 50 characters.")]
    public string Password { get; set; }
    
    public List<string>? Order { get; set;}

}