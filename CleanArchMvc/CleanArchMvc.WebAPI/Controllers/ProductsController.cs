using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var category = await _productService.GetProducts();
            if (category == null)
            {
                return NotFound("Products not found!");
            }
            return Ok(category);
        }
        [HttpGet("{id:int}", Name = "GetProductId")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound("Product not found!");
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest("Invalid Data");
            }
            await _productService.Add(product);
            return new CreatedAtRouteResult("GetProductId", new { id = product.Id }, product); //Retorna 201
        }
    }
}