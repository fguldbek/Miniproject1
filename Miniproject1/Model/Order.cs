using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Model;

public class Order
{
    public ObjectId  Id { get; set; }
    
    public double  TotalAmount { get; set; }
    
    public DateTime  PurchaseDate { get; set; }
    
    public List<string>? Post { get; set;}
}