using BookStore.DTOs;
using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/orderItems")]
    public class BookAndOrderController : ControllerBase
    {
        IRepository<OrderItems> _OrderRepoItem;
        public BookAndOrderController(IRepository<OrderItems> orderRepoItem)
        {
            _OrderRepoItem = orderRepoItem;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBookOrder()
        {
            var orderItems=await _OrderRepoItem.GetAllAsync();
            return Ok(orderItems);
        }

        [HttpGet("{orderItemID:int}")]
        public async Task<IActionResult> GetBybookId(int orderItemID)
        {
            var OrderItems=await _OrderRepoItem.GetByIDAsync(orderItemID);
            if(OrderItems == null) return NotFound();
            return Ok(OrderItems);
        }
        [HttpPost]
        public async Task<IActionResult> ADDOrderBook(OrderBook orderBook)
        {
            OrderItems orderItems = new OrderItems()
            {
                BookId= orderBook.BookId,
                OrderId= orderBook.OrderId,
                Quantity= orderBook.Quantity,
                UnitPrice= orderBook.UnitPrice,
            };
            await _OrderRepoItem.AddAsync(orderItems);
            await _OrderRepoItem.SaveChangesAsync();
            return Ok(orderItems);
        }
    }
}
