using DatabaseService.Entities;
using DatabaseService.Models;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProductsAPI.Controllers
{
    [Route("/api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateProductDto productDto)
        {
            int productId = _productService.Create(productDto);
            return Created($"/api/products/{productId}", null);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            var product = _productService.GetById(id);

            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            _productService.DeleteById(id);
            return NoContent();
        }
    }
}
