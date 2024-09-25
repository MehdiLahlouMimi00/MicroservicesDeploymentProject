using Microsoft.AspNetCore.Mvc;
using OrdersService.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrdersService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        public static OrderItem itemTest = new OrderItem {OrderItemId=1, ProductId=1, Quantity=1, UnitPrice=599, ProductName="Product 1"};
        private static readonly List<Order> Orders = new List<Order>() {
            new Order {OrderId=1, OrderDate=DateTime.Now, Status=OrderStatus.Delivered, CustomerName="John Doe", CustomerEmail="john@email.com", TotalAmount=599, OrderItems= new List<OrderItem>{itemTest}}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return Ok(Orders);
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            return Ok(Orders.FirstOrDefault(o => o.OrderId == id));
        }
    
        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            order.OrderId = Orders.Count + 1;
            Orders.Add(order);
            return Ok(order);
        }

        [HttpPut("{id}")]
        public ActionResult<Order> UpdateOrder(int id, Order order)
        {
            var existingOrder = Orders.FirstOrDefault(o => o.OrderId == id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.Status = order.Status;
            existingOrder.CustomerName = order.CustomerName;
            existingOrder.CustomerEmail = order.CustomerEmail;
            existingOrder.TotalAmount = order.TotalAmount;
            existingOrder.OrderItems = order.OrderItems;
            return Ok(existingOrder);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var order = Orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            Orders.Remove(order);
            return NoContent();
        }
    }

   
}
    
