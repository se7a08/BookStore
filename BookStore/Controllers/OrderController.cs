using BookStore.DTOs;
using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        IRepository<Order> _orderRepo;
        public OrderController(IRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order=await _orderRepo.GetAllAsync();
            return Ok(order);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order=await _orderRepo.GetByIDAsync(id);
            if (order is null) return NotFound();
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderOnly orderOnly)
        {
            Order order = new Order()
            {
                TotalPrice = orderOnly.TotalPrice,
                CustomerName = orderOnly.CustomerName,
                Date = DateTime.Now
            };
            await _orderRepo.AddAsync(order);
            await _orderRepo.SaveChangesAsync();
            return Ok(order);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(int id,OrderOnly orderOnly)
        {
            var order = await _orderRepo.GetByIDAsync(id);
            if(order is null) return NotFound();

            order.TotalPrice= orderOnly.TotalPrice;
            order.CustomerName= orderOnly.CustomerName;

            _orderRepo.Update(order);
            await _orderRepo.SaveChangesAsync();
            return Ok(order);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderRepo.GetByIDAsync(id);
            if (order is null) return NotFound();
            order.IsDeleted=true;
            _orderRepo.Update(order);
            await _orderRepo.SaveChangesAsync();
            return Ok(order);
        }

    }
}
