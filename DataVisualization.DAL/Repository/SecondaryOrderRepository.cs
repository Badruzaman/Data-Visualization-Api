
using DataVisualization.Domain.Abstractions;
using DataVisualization.Domain.Models;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using DataVisualization.Domain.DTOs;

namespace DataVisualization.DAL.Repository
{
    public class SecondaryOrderRepository : ISecondaryOrderRepository
    {

        private readonly IMongoCollection<SecondaryOrderCollections> _secondaryOrderCollections;
        private readonly IMongoCollection<SecondaryOrder> _secondaryOrder;
        public SecondaryOrderRepository(MongoDbContext mongoDbContext)
        {
            this._secondaryOrderCollections = mongoDbContext.GetCollection<SecondaryOrderCollections>("SecondaryOrderCollections");
            this._secondaryOrder = mongoDbContext.GetCollection<SecondaryOrder>("SecondaryOrder");
        }
        public async Task<SecondaryOrderCollections> Add(SecondaryOrderCollections secondaryOrderCollection)
        {
            try
            {
                await _secondaryOrderCollections.InsertOneAsync(secondaryOrderCollection);
                return secondaryOrderCollection;
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
                //var result1 = await _secondaryOrderCollections.Find(_ => true).ToListAsync();
                var result = await (from order in _secondaryOrderCollections.AsQueryable<SecondaryOrderCollections>()
                                        //where order.Product_Id == 46474
                                    select order).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SecondaryOrderDetail>> GetAllv1()
        {
            try
            {
                //SecondaryOrderDto secondaryOrderDto = new SecondaryOrderDto();
                //var filter = Builders<SecondaryOrder>.Filter.ElemMatch(
                //  x => x.SecondaryOrderDetails,
                //  Builders<SecondaryOrderDetail>.Filter.Eq(y => y.Product_Id, 46474));

                //var projection = Builders<SecondaryOrder>.Projection.Include(x => x.SecondaryOrderDetails)
                //                                                  .ElemMatch(x => x.SecondaryOrderDetails,
                //                                                             Builders<SecondaryOrderDetail>.Filter.Eq(y => y.Product_Id, 46474));

                //var result = _secondaryOrder.Find(filter)
                //                       .Project(projection)
                //                       .ToList();

                //var projection = Builders<SecondaryOrder>.Projection.Expression(
                //          x => x.SecondaryOrderDetails
                //         .Where(y => y.Product_Id == 46474)
                //        .Select(y => y.Qty)
                //         );
                //var result = _secondaryOrderCollections.Find(filter)
                //                       .Project(projection)
                //                       .ToList();

                // var filter = Builders<SecondaryOrder>.Filter.Eq(x => x.Product_Id == 46474);

                //var result = _secondaryOrder.Find(filter).ToList();
                //BsonDocument filter = new BsonDocument{
                //             {
                //                 "SecondaryOrderDetails.Product_Id", new BsonDocument{
                //                     { "$match", 46474 }
                //                 }
                //             }
                //             };

                var master = await _secondaryOrder.AsQueryable<SecondaryOrder>()
                    .Where(o => o.SecondaryOrderDetails.Any(od => od.Product_Id == 46474)).ToListAsync();
                var result =  master.SelectMany(o => o.SecondaryOrderDetails).Where(it=>it.Product_Id == 46474);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
