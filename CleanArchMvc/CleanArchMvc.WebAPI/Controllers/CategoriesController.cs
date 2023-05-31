using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CleanArchMvc.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if(categories == null)
            {
                return NotFound("Categories not found!");
            }
            return Ok(categories);
        }
        [HttpGet("{id:int}", Name = "GetGategoryId")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound("Category not found!");
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO category)
        {
            if (category == null)
            {
                return BadRequest("Invalid Data");
            }
           await _categoryService.Add(category);
            return new CreatedAtRouteResult("GetGategoryId", new  { id = category.Id}, category); //Retorna 201
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO category)
        {
            if(id != category.Id)
            {
                return BadRequest();
            }
            if(category == null)
            {
                return BadRequest();
            }
            await _categoryService.Update(category);
            return Ok(category);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetById(id);
            if(category == null)
            {
                return NotFound();
            }
            await _categoryService.Remove(id);
            return Ok(category);
        }
    }
}