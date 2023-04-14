﻿using DataVisualization.Domain.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataVisualization.DAL
{
    public class MongoDbContext 
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<MongoDbSetting> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
