using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Entities;
using Models.Interfaces;

namespace Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
            _basketRepo = basketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            // Get basket from the repo
            CustomerBasket basket = await _basketRepo.GetBasketAsync(basketId);

            // Get items from the product repo
            List<OrderItem> items = new List<OrderItem>();

            foreach (BasketItem item in basket.Items)
            {
                Product product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                ProductItemOrdered itemOrdered = new ProductItemOrdered(product.Id, product.Name, product.Name);
                OrderItem orderItem = new OrderItem(itemOrdered, product.Price, item.Quantity);

                items.Add(orderItem);
            }

            // Get delivery method from repo
            DeliveryMethod deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);

            // Calc subtotal
            decimal subtotal = items.Sum(item => item.Price * item.Quantity);

            // create order
            Order order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal);
            _unitOfWork.Repository<Order>().Add(order);

            // Save to db
            int result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                return null;
            }

            //delete basket
            await _basketRepo.DeleteBasketAsync(basketId);

            // return order
            return order;
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