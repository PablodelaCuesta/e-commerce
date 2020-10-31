using System.Threading.Tasks;
using Models.Entities;

namespace Models.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync( CustomerBasket basket );
        Task<bool> DeleteBasketAsync(string basketId);
    }
}