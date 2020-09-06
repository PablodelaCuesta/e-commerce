using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;

namespace Models.Interfaces
{
    public interface IProductsRepository
    {
        Task<Product> GetProductByIdAsync(int productId);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<ProductBrand> GetProductBrand(int brandId);
        Task<IReadOnlyList<ProductBrand>> GetAllProductBrand();
        Task<IReadOnlyList<ProductType>> GetAllProductType();
        
    }
}