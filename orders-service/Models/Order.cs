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
        public required List<OrderItem> OrderItems { get; set; }
        public required OrderStatus Status { get; set; }

        
    }

    

    
}
