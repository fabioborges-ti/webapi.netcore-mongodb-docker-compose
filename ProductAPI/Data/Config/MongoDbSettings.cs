using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProductAPI.Data.Seeds;
using ProductAPI.Models;

namespace ProductAPI.Data.Config
{
    public static class MongoDbSettings
    {
        public static IMongoDatabase Db { get; set; }
        
        public static IMongoCollection<Product> Products { get; set; }

        public static IConfiguration ConfigureDbSettings(this IConfiguration configuration, string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);

            Db = client.GetDatabase(databaseName);

            Products = Db.GetCollection<Product>("products");

            ProductSeed.SeedData(Products);

            return configuration;
        }
    }
}
