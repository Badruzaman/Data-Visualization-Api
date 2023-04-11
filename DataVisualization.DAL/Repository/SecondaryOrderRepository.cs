using DataVisualization.Domain.Configuration;
using DataVisualization.Domain.Abstractions;
using DataVisualization.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using AutoMapper;
using DataVisualization.Domain.DTOs;
using System.Security.Cryptography;

namespace DataVisualization.DAL.Repository
{
    public class SecondaryOrderRepository : ISecondaryOrderRepository
    {
        private readonly SqlDbContext _Context;
        private readonly IMapper _mapper;

        private readonly IMongoCollection<SecondaryOrder> secondaryOrderCollection;
        dynamic primary = null;
        public SecondaryOrderRepository(SqlDbContext Context, IOptions<MongoDbSetting> NoSqlDbSetting, IMapper mapper)
        {
            this._Context = Context;
            var mongoClient = new MongoClient(NoSqlDbSetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(NoSqlDbSetting.Value.DatabaseName);
            secondaryOrderCollection = mongoDatabase.GetCollection<SecondaryOrder>("SecondaryOrder");
            primary = mongoDatabase.GetCollection<dynamic>("DynSecondaryOrder");
            _mapper = mapper;
        }
        public async Task<bool> MigrateSqlToNoSql()
        {
            try
            {
                //Raw sql
                //string sql = "select top 100 Id,Code,OrderDate from SecondaryOrders order by Id desc";
                //var result = await _Context.Set<SecondaryOrder>().FromSqlRaw(sql).ToListAsync();

                //Raw Stored Procedure
                var result = await _Context.SecondaryOrderDto.FromSqlRaw("SprGetSecondaryOrder @param1, @param2", new SqlParameter("@param1", 1), new SqlParameter("@param2", 2)).AsNoTracking().ToListAsync();
                var groupedData = from it in result
                                  group it
                                  by new
                                  {
                                      it.Code,
                                      it.OrderDate
                                  } into g
                                  select new SecondaryOrder
                                  {
                                      Code = g.Key.Code,
                                      OrderDate = g.Key.OrderDate,
                                      SecondaryOrderDetails = g.Select(_it => new SecondaryOrderDetail
                                      {
                                          Product_Id = _it.Product_Id,
                                          Name = _it.Name,
                                          Qty = _it.Qty
                                      })
                                  };
                await secondaryOrderCollection.InsertManyAsync(groupedData);
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
                await secondaryOrderCollection.InsertOneAsync(secondaryOrder);
                return secondaryOrder;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<SecondaryOrder>> GetAll()
        {
            try
            {
                //var filter = Builders<SecondaryOrder>.Filter.Empty;
                //var projection = Builders<SecondaryOrder>.Projection.Include("SecondaryOrderDetails.Product_Id");
                //var distinctProducts = await secondaryOrderCollection.DistinctAsync<string>("SecondaryOrderDetails.Product_Id", filter, options: new DistinctOptions { Projection = projection });
                //var DetailsList = new List<SecondaryOrderDetail>();
                var result = await secondaryOrderCollection.Find(_ => true).ToListAsync();

                //var filter = Builders<SecondaryOrder>.Filter.Empty;
                //var projection = Builders<SecondaryOrder>.Projection.Include(o => o.SecondaryOrderDetails);

                // Retrieve only the nested details
                //var Details = await secondaryOrderCollection.Find(filter).Project<SecondaryOrder>(projection).ToListAsync();
                //foreach (var item in result)
                //{
                //    DetailsList.AddRange(item.SecondaryOrderDetails);
                //}
                //var grouped = (from it in Details.
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
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
