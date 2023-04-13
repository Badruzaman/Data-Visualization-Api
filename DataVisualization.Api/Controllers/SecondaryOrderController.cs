using DataVisualization.Domain.Abstractions;
using DataVisualization.Domain.DTOs;
using DataVisualization.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataVisualization.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SecondaryOrderController : ControllerBase
    {
        private readonly ISecondaryOrderService _secondaryOrderService;
        public SecondaryOrderController(ISecondaryOrderService secondaryOrderService)
        {
            this._secondaryOrderService = secondaryOrderService;
        }

        [HttpGet("MigrateSqlToNoSql")]
        public async Task<bool> MigrateSqlToNoSql()
        {
            var result = await _secondaryOrderService.MigrateSqlToNoSql();
            return result;
        }
        [HttpPost]
        public async Task<SecondaryOrder> add(SecondaryOrder secondaryOrder)
        {
            var result = await _secondaryOrderService.Add(secondaryOrder);
            return result;
        }
        [HttpGet("GetAll")]
        public async Task<List<SecondaryOrderCollections>> GetAll()
        {
            var result = await _secondaryOrderService.GetAll();
            return result;
        }

        //[HttpGet("GetByProductId")]
        //public async Task<List<SecondaryOrder>> GetByProductId()
        //{
        //    var result = await _secondaryOrderService.GetAll();
        //    return result;
        //}
    }
}
