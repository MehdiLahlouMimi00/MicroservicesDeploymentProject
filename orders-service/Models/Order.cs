using System;
using System.Collections.Generic;

namespace OrdersService.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public required string CustomerName { get; set; }
        public required string CustomerEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public OrderStatus Status { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
