using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Interfaces;

namespace Core.Data
{
    public class ProductRepository : IProductsRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetAllProductBrand()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetAllProductType()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<ProductBrand> GetProductBrand(int brandId)
        {
            return await _context.ProductBrands.FirstOrDefaultAsync(brand => brand.Id == brandId);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                                .Include(p => p.ProductBrand)
                                .Include(p => p.ProductType)
                                .ToListAsync();
        }
    }
}