﻿using DataVisualization.Domain.DTOs;
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
        Task<bool> MigrateSqlToNoSql();
        Task<SecondaryOrder> Add(SecondaryOrder secondaryOrder);
        Task<List<SecondaryOrderCollections>> GetAll();
    }
}