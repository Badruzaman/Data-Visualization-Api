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
        public async Task<bool> MigrateSqlToNoSql()
        {
          return await _secondaryOrderRepository.MigrateSqlToNoSql();
        }
        public async Task<SecondaryOrder> Add(SecondaryOrder secondaryOrder)
        {
            return await _secondaryOrderRepository.Add(secondaryOrder);
        }
        public async Task<List<SecondaryOrder>> GetAll()
        {
            return await _secondaryOrderRepository.GetAll();
        }
    }
}
