using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core;

public class Order
{
    public int Id { get; set; }
    
    public double  TotalAmount { get; set; }
    
    public DateTime  PurchaseDate { get; set; }
    
    public List<string>? Post { get; set;}
}