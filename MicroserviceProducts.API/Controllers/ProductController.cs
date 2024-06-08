using MicroserviceProducts.API.Models;
using MicroserviceProducts.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace MicroserviceProducts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productRepo.GetProducts();
            return new OkObjectResult(products);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _productRepo.GetProductByID(id);
            return new ObjectResult(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            using (var scope = new TransactionScope())
            {
                _productRepo.InsertProduct(product);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            if (product == null)
            {
                using (var scope = new TransactionScope())
                {
                    _productRepo.UpdateProduct(product);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepo.DeleteProduct(id);
            return new OkResult();
        }
    }
}