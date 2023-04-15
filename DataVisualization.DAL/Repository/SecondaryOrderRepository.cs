
using DataVisualization.Domain.Abstractions;
using DataVisualization.Domain.Models;
using MongoDB.Driver.Linq;
using MongoDB.Driver;



namespace DataVisualization.DAL.Repository
{
    public class SecondaryOrderRepository : ISecondaryOrderRepository
    {
        private readonly SqlDbContext _dbContext;
        private readonly IMongoCollection<SecondaryOrderCollections> _secondaryOrderCollections;
        private readonly IMongoCollection<SecondaryOrder> _secondaryOrder;
        public SecondaryOrderRepository(SqlDbContext dbContext, MongoDbContext mongoDbContext)
        {
            this._dbContext = dbContext;
            this._secondaryOrderCollections = mongoDbContext.GetCollection<SecondaryOrderCollections>("SecondaryOrderCollections");
            this._secondaryOrder = mongoDbContext.GetCollection<SecondaryOrder>("SecondaryOrder");
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

                //var result1 = await _secondaryOrderCollections.Find(_ => true).ToListAsync();
                var result = await (from order in _secondaryOrderCollections.AsQueryable<SecondaryOrderCollections>()
                             where order.Product_Id == 46474
                             select order).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<SecondaryOrder>> GetAllv1()
        {
            try
            {
                var query = from order in _secondaryOrder.AsQueryable<SecondaryOrder>()
                            where order.SecondaryOrderDetails.Any(_it => _it.Product_Id == 46474)
                            select order;
                var result = query.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
