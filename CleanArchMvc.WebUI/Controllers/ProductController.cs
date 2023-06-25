using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}