using System;
using Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ServerAPI1.Repositories
{
    public class OrderRepository : IOrderRepository

	{
        private IMongoClient client;
        private IMongoCollection<Order> collection;

        public OrderRepository()
		{
            var password = ""; //add
            var mongoUri = $"mongodb+srv://fguldbaek:EmX759ivZyR6VZgD@cluster0.ravrm.mongodb.net/";
            
            client = new MongoClient(mongoUri);
                
            // Provide the name of the database and collection you want to use.
            // If they don't already exist, the driver and Atlas will create them
            // automatically when you first write data.
            var dbName = "Miniprojekt";
            var collectionName = "Orders";

            collection = client.GetDatabase(dbName)
               .GetCollection<Order>(collectionName);

        }

        public void AddItem(Order item)
        {
            var max = 0;
            if (collection.Count(Builders<Order>.Filter.Empty) > 0)
            {
                max = collection.Find(Builders<Order>.Filter.Empty).SortByDescending(r => r.Id).Limit(1).ToList()[0].Id;
            }
            item.Id = max + 1;
            collection.InsertOne(item);
           
        }
        
        public void DeleteById(int id){
            var deleteResult = collection
                .DeleteOne(Builders<Order>.Filter.Where(r => r.Id == id));
        }

        
        public Order[] GetAll()
        {
           return collection.Find(Builders<Order>.Filter.Empty).ToList().ToArray();
        }
        

        

        //Finder alle ordre, hvor Buyer Id matcher aka købs historik 
        public Order[] GetAllByUserId(int buyerId)
        {
            var filter = Builders<Order>.Filter.Eq(order => User.BuyerId, buyerId);
            return collection.Find(filter).ToList().ToArray();
        }

        public void UpdateItem(Order item)
        {
            var updateDef = Builders<Order>.Update
                .Set(x => x.Amount, item.Amount);
            
            collection.UpdateOne(x => x.Id == item.Id, updateDef);
        }
    }
}

