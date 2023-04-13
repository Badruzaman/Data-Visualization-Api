using DataVisualization.Domain.Configuration;
using DataVisualization.Domain.Abstractions;
using DataVisualization.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Linq;
using DataVisualization.Domain.DTOs;

namespace DataVisualization.DAL.Repository
{
    public class SecondaryOrderRepository : ISecondaryOrderRepository
    {
        private readonly SqlDbContext _dbContext;
        private readonly IMongoCollection<SecondaryOrderCollections> _secondaryOrderCollections;
        public SecondaryOrderRepository(SqlDbContext dbContext, MongoDbContext mongoDbContext)
        {
            this._dbContext = dbContext;
            this._secondaryOrderCollections = mongoDbContext.GetCollection<SecondaryOrderCollections>("SecondaryOrderCollections");
        }
        public async Task<bool> MigrateSqlToNoSql()
        {
            try
            {
                //Raw sql
                //string sql = "select top 100 Id,Code,OrderDate from SecondaryOrders order by Id desc";
                //var result = await _Context.Set<SecondaryOrder>().FromSqlRaw(sql).ToListAsync();

                //Raw Stored Procedure
                var result = await _dbContext.SecondaryOrderCollections.FromSqlRaw("SprGetSecondaryOrder @param1, @param2", new SqlParameter("@param1", 1), new SqlParameter("@param2", 2)).AsNoTracking().ToListAsync();
                //var groupedData = from it in result
                //                  group it
                //                  by new
                //                  {
                //                      it.Code,
                //                      it.OrderDate
                //                  } into g
                //                  select new SecondaryOrder
                //                  {
                //                      Code = g.Key.Code,
                //                      OrderDate = g.Key.OrderDate,
                //                      SecondaryOrderDetails = g.Select(_it => new SecondaryOrderDetail
                //                      {
                //                          Product_Id = _it.Product_Id,
                //                          Name = _it.Name,
                //                          Qty = _it.Qty
                //                      })
                //                  };
                await _secondaryOrderCollections.InsertManyAsync(result);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<SecondaryOrder> Add(SecondaryOrder secondaryOrder)
        {
            try
            {
                //await SecondaryOrderCollection.InsertOneAsync(secondaryOrder);
                return secondaryOrder;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<SecondaryOrderCollections>> GetAll()
        {
            try
            {
                //var output = new List<SecondaryOrderDetailDto>();
                //var coll = _mongoDb.GetCollection<BsonDocument>("SecondaryOrder");
                //var filter = Builders<BsonDocument>.Filter.Eq("SecondaryOrderDetails.Product_Id", "46474");
                //var query = coll.Find(filter);
                //foreach (var res in query.ToList())
                //{
                //    output.Add(new SecondaryOrderDetailDto { Product_Id = res.pr});
                //}

                //var filter = Builders<SecondaryOrder>.Filter.Empty;
                //var projection = Builders<SecondaryOrder>.Projection.Include("SecondaryOrderDetails.Product_Id");
                //var distinctProducts = await secondaryOrderCollection.DistinctAsync<string>("SecondaryOrderDetails.Product_Id", filter, options: new DistinctOptions { Projection = projection });
                //var DetailsList = new List<SecondaryOrderDetail>();

                //var results = from secondary in SecondaryOrderCollection.AsQueryable() where secondary.SecondaryOrderDetails.Where(it => it.Product_Id == 46474) select new { secondary.Title, secondary.Plot };
                //                BsonDocument filter = new BsonDocument{
                //    {
                //        "SecondaryOrderDetails.Product_Id", new BsonDocument{
                //            { "$gt", 1980 },
                //            { "$lt", 1990 }
                //        }
                //    }
                //};
                //                //var filter = Builders<BsonDocument>.Filter.Eq("SecondaryOrderDetails.Product_Id", "46474");
                //                var documents = await SecondaryOrderCollection.Find(filter).ToListAsync();

                //while (cursor.hasNext())
                //{
                //    var print = (cursor.next());
                //}
                //var filter = Builders<SecondaryOrder>.Filter.Empty;
                // var projection = Builders<SecondaryOrder>.Projection.Include(o => o.SecondaryOrderDetails);

                // Retrieve only the nested details
                //var Details = await secondaryOrderCollection.Find(filter).Project<SecondaryOrder>(projection).ToListAsync();
                //foreach (var item in result)
                //{
                //    DetailsList.AddRange(item.SecondaryOrderDetails);
                //}
                //var grouped = (from it in Details
                //               group it by new
                //               {
                //                   it.Product_Id,
                //                   it.Name
                //               }
                //              into g
                //               select new SecondaryOrderDetail
                //               {
                //                   Product_Id = g.Key.Product_Id,
                //                   Name = g.Key.Name,
                //                   Qty = g.Sum(x => x.Qty)
                //               }).ToList();
                //return grouped;

                var result = await _secondaryOrderCollections.Find(_ => true).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
