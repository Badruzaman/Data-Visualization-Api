using DataVisualization.Domain.Abstractions;
using DataVisualization.Domain.DTOs;
using DataVisualization.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualization.Service.Services
{
    public class SecondaryOrderService : ISecondaryOrderService
    {
        private readonly ISecondaryOrderRepository _secondaryOrderRepository;
        public SecondaryOrderService(ISecondaryOrderRepository secondaryOrderRepository)
        {
            this._secondaryOrderRepository = secondaryOrderRepository;
        }
       
        public async Task<SecondaryOrderCollections> Add(SecondaryOrderCollections secondaryOrderCollection)
        {
            return await _secondaryOrderRepository.Add(secondaryOrderCollection);
        }
        public async Task<List<SecondaryOrderCollections>> GetAll()
        {
            return await _secondaryOrderRepository.GetAll();
        }
        public async Task<IEnumerable<SecondaryOrder>> GetAllv1()
        {
            return await _secondaryOrderRepository.GetAllv1();
        }
    }
}
