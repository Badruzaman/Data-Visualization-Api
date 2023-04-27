using DataVisualization.Domain.DTOs;
using DataVisualization.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualization.Domain.Abstractions
{
    public interface ISecondaryOrderService
    {
        Task<SecondaryOrderCollections> Add(SecondaryOrderCollections secondaryOrderCollections);
        Task<List<SecondaryOrderCollections>> GetAll();
        Task<IEnumerable<SecondaryOrder>> GetAllv1();

    }
}
