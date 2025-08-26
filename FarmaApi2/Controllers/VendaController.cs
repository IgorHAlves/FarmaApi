using FarmaApi2.DTOs;
using FarmaApi2.Entity;
using FarmaApi2.Interfaces;
using FarmaApi2.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmaApi2.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VendaController : Controller
    {
        private readonly ISaleService _saleService;

        public VendaController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet(Name = "GetSales")]
        public IActionResult GetSales()
        {
            List<Sale> sales = _saleService.GetSales();
            return Ok(sales);
        }

        [HttpGet(Name = "GetSale")]
        public IActionResult GetSales([FromQuery] Guid id)
        {
            Sale sales = _saleService.GetSale(id);
            return Ok(sales);
        }

        [HttpPost(Name = "CreateSales")]
        public IActionResult CreateSale([FromBody] CreateSaleDTO dto)
        {
            var sale = _saleService.CreateSale(dto);
            return Ok(sale);
        }





    }
}
