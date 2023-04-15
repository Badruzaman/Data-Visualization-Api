
using DataVisualization.Domain.Abstractions;
using DataVisualization.Domain.Models;
using MongoDB.Driver.Linq;
using MongoDB.Driver;


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
