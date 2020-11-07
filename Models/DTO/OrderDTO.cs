using Models.Entities;

namespace Models.DTO
{
    public class OrderDTO
    {
        public OrderDTO(string basketId, int deliveryMethod, Address shipToAddress)
        {
            BasketId = basketId;
            DeliveryMethodId = deliveryMethod;
            ShipToAddress = shipToAddress;
        }

        public string BasketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public Address ShipToAddress { get; set; }
    }
}