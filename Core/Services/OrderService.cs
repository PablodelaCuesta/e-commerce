using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;
using Models.Interfaces;

namespace Core.Services
{
    public class OrderService : IOrderService
    {
        public Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketId, Address shippingAddress)
        {
            // Get basket from the repo
            // Get items from the product repo
            // Get delivery method from repo
            // Calc subtotal
            // create order
            // Save to db
            // return order
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new System.NotImplementedException();
        }
    }
}