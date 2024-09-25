using System;
using System.Collections.Generic;

namespace OrdersService.Models 
{
    
    public enum OrderStatus
        {
            Pending,
            Processing,
            Shipped,
            Delivered,
            Cancelled
        }
}
