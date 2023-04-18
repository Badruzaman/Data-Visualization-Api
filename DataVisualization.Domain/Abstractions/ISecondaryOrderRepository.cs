using DataVisualization.Domain.DTOs;
using DataVisualization.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualization.Domain.Abstractions
{
    public interface ISecondaryOrderRepository
    {
        Task<SecondaryOrderCollections> Add(SecondaryOrderCollections secondaryOrderCollection);
        Task<List<SecondaryOrderCollections>> GetAll();
        Task<IEnumerable<SecondaryOrderDetail>> GetAllv1();
    }
}
