using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabasesSetting:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabasesSetting:DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabasesSetting:CollectionName"));

            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
