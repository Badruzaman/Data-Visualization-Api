using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualization.Domain.DTOs
{
    public class SecondaryOrderDto
    {
        public decimal Id { get; set; }
        public string Code { get; set; } = string.Empty; 
        public decimal Product_Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Qty { get; set; }

    }
}
