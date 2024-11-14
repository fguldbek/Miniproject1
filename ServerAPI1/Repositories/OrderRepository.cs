using System;
using Core;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ServerAPI1.Repositories
{
    public class OrderRepository : IOrderRepository

	{
        private readonly IMongoClient client;
        private readonly ILogger<OrderRepository> _logger;
        private IMongoCollection<Order> collection;

        public OrderRepository(ILogger<OrderRepository> logger)
		{
            _logger = logger;
            var password = ""; //add
            _logger.LogInformation("Initializing MongoDB client.");
            var mongoUri = $"mongodb+srv://fguldbaek:EmX759ivZyR6VZgD@cluster0.ravrm.mongodb.net/";
            _logger.LogInformation("MongoDB URI: {MongoUri}", mongoUri);

            try
            {
                client = new MongoClient(mongoUri);
                _logger.LogInformation("MongoDB client initialized successfully.");

                var dbName = "Miniprojekt";
                var collectionName = "Orders";

                _logger.LogInformation("Connecting to database: {DatabaseName}, Collection: {CollectionName}", dbName, collectionName);
                collection = client.GetDatabase(dbName)
                   .GetCollection<Order>(collectionName);
                _logger.LogInformation("Connected to MongoDB collection successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing MongoDB client or connecting to the collection.");
                throw;
            }

        }

        public void AddItem(Order item)
        {
            try
            {
                var max = 0;
                if (collection.Count(Builders<Order>.Filter.Empty) > 0)
                {
                    max = collection.Find(Builders<Order>.Filter.Empty).SortByDescending(r => r.Id).Limit(1).ToList()[0].Id;
                }
                item.Id = max + 1;
                collection.InsertOne(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding an item.");
                throw;
            }
           
        }
        
        public void DeleteById(int id){
            try
            {
                var deleteResult = collection
                    .DeleteOne(Builders<Order>.Filter.Where(r => r.Id == id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting an item with ID {Id}.", id);
                throw;
            }
        }

        
        public Order[] GetAll()
        {
            try
            {
                _logger.LogInformation("Attempting to retrieve all orders from the database.");
                var orders = collection.Find(Builders<Order>.Filter.Empty).ToList().ToArray();
                _logger.LogInformation("Successfully retrieved {Count} orders from the database.", orders.Length);
                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all orders.");
                throw;
            }
        }
        

        

        //Finder alle ordre, hvor Buyer Id matcher aka købs historik 
        public Order[] GetAllByUserId(int buyerId)
        {
            try
            {
                // Using MongoDB dot notation to access the nested 'User.BuyerId' field in the filter
                var filter = Builders<Order>.Filter.Eq("User.BuyerId", buyerId);
                return collection.Find(filter).ToList().ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving orders for user ID {BuyerId}.", buyerId);
                throw;
            }
        }

        public void UpdateItem(Order item)
        {
            try
            {
                var updateDef = Builders<Order>.Update
                    .Set(x => x.Amount, item.Amount);
                
                collection.UpdateOne(x => x.Id == item.Id, updateDef);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating an item with ID {Id}.", item.Id);
                throw;
            }
        }
    }
}

