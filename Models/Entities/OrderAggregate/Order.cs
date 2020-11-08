using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public class Order : BaseEntity
    {

        public Order()
        {
        }

        public Order(List<OrderItem> items, string buyerEmail, Address shippingAddress, DeliveryMethod deliveryMethod, decimal subtotal)
        {
            OrderItems = items;
            BuyerEmail = buyerEmail;
            ShipToAddress = shippingAddress;
            DeliveryMethod = deliveryMethod;
            Subtotal = subtotal;
        }

        public Order(string buyerEmail, DateTimeOffset orderDate, Address shipToAddress, DeliveryMethod deliveryMethod, List<OrderItem> orderItems, decimal subtotal, OrderStatus status, int paymentIntentId)
        {
            BuyerEmail = buyerEmail;
            OrderDate = orderDate;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
            Status = status;
            PaymentIntentId = paymentIntentId;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; }
        public int PaymentIntentId { get; set; }
    }
}