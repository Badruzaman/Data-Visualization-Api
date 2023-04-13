using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualization.Domain.Models
{
    public class SecondaryOrderCollections
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal PartyBusinessLine_Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public decimal Product_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Qty { get; set; }
    }
}
