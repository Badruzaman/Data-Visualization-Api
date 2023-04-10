﻿
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace DataVisualization.Domain.Models
{

    public class SecondaryOrder
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Code { get; set; }
        public DateTime OrderDate { get; set; }
        public List<SecondaryOrderDetail> SecondaryOrderDetails { get; set; }
    }

    public class SecondaryOrderDetail
    {
        public decimal Product_Id { get; set; }
        public string? Name { get; set; }
        public decimal Qty { get; set; }
    }
    
}
