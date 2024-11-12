using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core;

public class Room
{
    
    public string Int { get; set; }
    
    public string Name { get; set; }
    
    public string Location { get; set; }
    
}