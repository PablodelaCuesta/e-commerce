using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;

namespace Models.Interfaces
{
    public interface IProductsRepository
    {
        Task<Product> GetProductByIdAsync(int productId);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        
    }
}