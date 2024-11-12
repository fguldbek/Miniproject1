using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core;

public class Location
{
    
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Room { get; set; }
}