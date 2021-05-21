using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetValue<String>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(config.GetValue<String>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(config.GetValue<String>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);

        }
        public IMongoCollection<Product> Products { get; }
    }
}
