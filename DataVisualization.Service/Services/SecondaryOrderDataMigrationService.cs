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
    public class SecondaryOrderDataMigrationService : ISecondaryOrderDataMigrationService
    {
        private readonly ISecondaryOrderDataMigrationRepository _secondaryOrderDataMigrationRepository;
        public SecondaryOrderDataMigrationService(ISecondaryOrderDataMigrationRepository secondaryOrderDataRepository)
        {
            this._secondaryOrderDataMigrationRepository = secondaryOrderDataRepository;
        }
        public async Task<bool> MigrateSqlToNoSql()
        {
            return await _secondaryOrderDataMigrationRepository.MigrateSqlToNoSql();
        }
    }
}
