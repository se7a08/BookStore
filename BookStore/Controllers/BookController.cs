using BookStore.Data;
using BookStore.DTOs;
using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        IRepository<Book> _repo;
        public BookController(IRepository<Book> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _repo.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var book=await _repo.GetByIDAsync(id);
            if (book is null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Addnew(BookOnly bookonly)
        {
            Book book1 = new Book()
            {
                AuthorName = bookonly.AuthorName,
                Title = bookonly.Title,
                BookRole = bookonly.BookRole,
                Price = bookonly.Price,
                Quantity = bookonly.Quantity,
                Description= bookonly.Description
            };
             await _repo.AddAsync(book1);
            await _repo.SaveChangesAsync();
            return Ok(book1);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditAsync(int id, BookOnly bookonly)
        {
            var book = await _repo.GetByIDAsync(id);
            if (book is null) return NotFound();

            book.AuthorName = bookonly.AuthorName;
            book.Title = bookonly.Title;
            book.Price = bookonly.Price;
            book.Quantity = bookonly.Quantity;
            book.Description = bookonly.Description;
            book.BookRole = bookonly.BookRole;

            _repo.Update(book);
            await _repo.SaveChangesAsync();
            return Ok(book);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book=await _repo.GetByIDAsync(id);
            if(book is null) return NotFound();
            book.IsDeleted = true;
            _repo.Update(book);
            await _repo.SaveChangesAsync();
            return Ok(book);
        }
    }
}
