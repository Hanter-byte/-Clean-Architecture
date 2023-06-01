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
        [HttpGet("{id:int}", Name = "GetProduct")]
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
        public async Task<ActionResult> Post([FromBody] ProductDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Data Invalid");

            await _productService.Add(produtoDto);

            return new CreatedAtRouteResult("GetProduct",
                new { id = produtoDto.Id }, produtoDto);
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            if (product == null)
            {
                return BadRequest();
            }
            await _productService.Update(product);
            return Ok(product);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Detele(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.Remove(id);
            return Ok(product);
        }
    }
}