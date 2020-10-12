using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Interfaces;
using Models.Specifications;
using Microsoft.Extensions.Configuration;
using API.DTO;
using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using API.Helpers;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IConfiguration _config;
        private readonly ILogger<Product> _logger;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductsController(IGenericRepository<Product> productsRepo, 
                                  IGenericRepository<ProductBrand> productBrandRepo, 
                                  IGenericRepository<ProductType> productTypeRepo,
                                  IConfiguration configuration,
                                  ILogger<Product> logger)
        {
            _productsRepo = productsRepo;
            _config = configuration;
            _logger = logger;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDTO>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            // IReadOnlyList<Product> products = await _productsRepo.GetAllAsync();
            ProductsWithTypesAndBrandsSpecification spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            
            // Count specification
            ProductWithFiltersForCountSpecification countspec = new ProductWithFiltersForCountSpecification(productParams);

            // Return from database
            IReadOnlyList<Product> products = await _productsRepo.ListAsync(spec);
            int totalItems = await _productsRepo.CountAsync(countspec);


            //Shape our data with DTO
            IReadOnlyList<ProductToReturnDTO> result = products.Select(product => new ProductToReturnDTO(product, _config)).ToList();

            return Ok(new Pagination<ProductToReturnDTO>(productParams.PageIndex, productParams.PageSize, totalItems, result));
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int productId)
        {
            // Product product = await _productsRepo.GetByIdAsync(productId);
            ProductsWithTypesAndBrandsSpecification spec = new ProductsWithTypesAndBrandsSpecification(productId);
            Product product = await _productsRepo.GetEntityWithSpec(spec);

            if (product is null) return NotFound(new ApiResponse(404));

            // Shape our data with DTO
            ProductToReturnDTO result = new ProductToReturnDTO(product, _config);

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