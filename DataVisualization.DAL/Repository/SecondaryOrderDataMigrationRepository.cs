using DataVisualization.Domain.Abstractions;
using DataVisualization.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualization.DAL.Repository
{
    public class SecondaryOrderDataMigrationRepository : ISecondaryOrderDataMigrationRepository
    {
        private readonly SqlDbContext _sqlDbContext;
        private readonly IMongoCollection<SecondaryOrderCollections> _secondaryOrderCollections;
        private readonly IMongoCollection<SecondaryOrder> _secondaryOrder;
        public SecondaryOrderDataMigrationRepository(SqlDbContext sqlDbContext, MongoDbContext mongoDbContext)
        {
            this._sqlDbContext = sqlDbContext;
            this._secondaryOrderCollections = mongoDbContext.GetCollection<SecondaryOrderCollections>("SecondaryOrderCollections");
            this._secondaryOrder = mongoDbContext.GetCollection<SecondaryOrder>("SecondaryOrder");
        }
        public async Task<bool> MigrateSqlToNoSql()
        {
            try
            {
                //Raw sql
                //string sql = "select top 100 Id,Code,OrderDate from SecondaryOrders order by Id desc";
                //var result = await _Context.Set<SecondaryOrder>().FromSqlRaw(sql).ToListAsync();

                //Raw Stored Procedure
                var result = await _sqlDbContext.SecondaryOrderCollections.FromSqlRaw("SprGetSecondaryOrder @param1, @param2", new SqlParameter("@param1", 1), new SqlParameter("@param2", 2)).AsNoTracking().ToListAsync();
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
                //await _secondaryOrderCollections.InsertManyAsync(result);
                await _secondaryOrder.InsertManyAsync(groupedData);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
