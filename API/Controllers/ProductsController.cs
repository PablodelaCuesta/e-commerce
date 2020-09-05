using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsAsync()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public string GetProduct(int productId)
        {
            return "A specific product";
        }
    }
}