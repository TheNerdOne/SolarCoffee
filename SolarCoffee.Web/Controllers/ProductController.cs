using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Product;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Web.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpGet("/api/product")]
        public ActionResult GetProduct([FromQuery] int? id)
        {
            _logger.LogInformation("Getting Products");
            if (id.HasValue)
            {
                var product = _productService.GetProductById(id.Value);
                return Ok(product);
            }

            var products = _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpPost]
        [Route("/api/product")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        public ActionResult CreateProduct([FromBody] Product product)
        {
            _logger.LogInformation("Creating Product");
            
            // Clear any ID that might have been sent
            product.Id = 0; // This ensures EF Core will generate a new ID
            
            var response = _productService.CreateProduct(product);
            if (response.IsSuccess)
            {
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            return BadRequest(response.Message);
        }
        [HttpPut("/api/product/{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] Data.Models.Product product)
        {
            _logger.LogInformation("Updating Product");
            if (id != product.Id)
            {
                return BadRequest("Product ID mismatch");
            }
            var response = _productService.UpdateProduct(product);
            if (response.IsSuccess)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
        [HttpDelete("/api/product/{id}")]
        public ActionResult ArchiveProduct(int id)
        {
            _logger.LogInformation("Archiving Product");
            var response = _productService.ArchiveProduct(id);
            if (response.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(response.Message);
        }
    }
}
