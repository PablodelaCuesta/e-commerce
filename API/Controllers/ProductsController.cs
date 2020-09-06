using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repo;

        public ProductsController(IProductsRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsAsync()
        {
            IReadOnlyList<Product> products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            Product product = await _repo.GetProductByIdAsync(productId);
            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductsBrands()
        {
            IReadOnlyList<ProductBrand> result = await _repo.GetAllProductBrand();
            return Ok(result);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsTypes()
        {
            IReadOnlyList<ProductType> result = await _repo.GetAllProductType();
            return Ok(result);
        }
    }
}