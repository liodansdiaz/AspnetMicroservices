using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabasesSetting:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabasesSetting:ConnectionString"));
            Product = database.GetCollection<Product>(configuration.GetValue<string>("DatabasesSetting:CollectionName);
        }

        public IMongoCollection<Product> Product { get; }
    }
}
