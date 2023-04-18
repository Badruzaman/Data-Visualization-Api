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

        [HttpPost]
        public async Task<SecondaryOrderCollections> add(SecondaryOrderCollections secondaryOrderCollection)
        {
            var result = await _secondaryOrderService.Add(secondaryOrderCollection);
            return result;
        }
        [HttpGet("GetAll")]
        public async Task<List<SecondaryOrderCollections>> GetAll()
        {
            try
            {
                var result = await _secondaryOrderService.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetAllv1")]
        public async Task<IEnumerable<SecondaryOrderDetail>> GetAllv1()
        {
            var result = await _secondaryOrderService.GetAllv1();
            return result;
        }
    }
}
