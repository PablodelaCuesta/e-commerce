using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.DTO;
using Core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Interfaces;
using Models.Specifications;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductsController(IGenericRepository<Product> productsRepo, 
            IGenericRepository<ProductBrand> productBrandRepo, 
            IGenericRepository<ProductType> productTypeRepo)
        {
            _productsRepo = productsRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // IReadOnlyList<Product> products = await _productsRepo.GetAllAsync();
            ProductsWithTypesAndBrandsSpecification spec = new ProductsWithTypesAndBrandsSpecification();
            
            // Return from database
            IReadOnlyList<Product> products = await _productsRepo.ListAsync(spec);

            //Shape our data with DTO
            IReadOnlyList<ProductToReturnDTO> result = products.AsParallel().Select(product => new ProductToReturnDTO(product)).ToList();

            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            // Product product = await _productsRepo.GetByIdAsync(productId);
            ProductsWithTypesAndBrandsSpecification spec = new ProductsWithTypesAndBrandsSpecification(productId);
            Product product = await _productsRepo.GetEntityWithSpec(spec);

            // Shape our data with DTO
            ProductToReturnDTO result = new ProductToReturnDTO(product);

            return Ok(result);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductsBrands()
        {
            IReadOnlyList<ProductBrand> result = await _productBrandRepo.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsTypes()
        {
            IReadOnlyList<ProductType> result = await _productTypeRepo.GetAllAsync();
            return Ok(result);
        }
    }
}