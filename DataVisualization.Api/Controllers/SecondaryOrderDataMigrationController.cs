using DataVisualization.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataVisualization.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SecondaryOrderDataMigrationController : ControllerBase
    {
        private readonly ISecondaryOrderDataMigrationService _secondaryOrderDataMigrationService;
        public SecondaryOrderDataMigrationController(ISecondaryOrderDataMigrationService secondaryOrderDataMigrationService)
        {
            this._secondaryOrderDataMigrationService = secondaryOrderDataMigrationService;
        }
        [HttpGet("MigrateSqlToNoSql")]
        public async Task<bool> MigrateSqlToNoSql()
        {
            var result = await _secondaryOrderDataMigrationService.MigrateSqlToNoSql();
            return result;
        }
    }
}
