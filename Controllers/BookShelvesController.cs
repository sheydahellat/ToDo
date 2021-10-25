using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Dto;


namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookShelvesController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookShelvesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/BookShelves
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BookShelves>>> GetBookShelves()
        {

            var UserName = User.Claims.Where(x => x.Type.Equals("Name"))
            .Select(x => x.Value)
            .FirstOrDefault();
            
            var books = await _context.BookShelves
            .Where(u => u.OwnerId.Equals(UserName))
            .ToListAsync();

            return books;
        }

        // GET: api/BookShelves/5
        [HttpGet("{id}")]
        public List<bookdto> GetBookShelves(string id)
        {
           var books = _context.BookShelves
                .Where(x => x.ShelfId.Equals(id))
                .Include(x => x.bookEntity)
                .Select (x => new bookdto
                {
                    bookname = x.bookEntity.Title
                })
                .ToList();
            return books;
        }

        // PUT: api/BookShelves/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookShelves(string id, BookShelves bookShelves)
        {
            if (!(id .Equals( bookShelves.Id)))
            {
                return BadRequest();
            }

            _context.Entry(bookShelves).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookShelvesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookShelves
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
       
        public async Task<ActionResult<BookShelves>> PostBookShelves([FromBody] BookShelves bookShelves)
        {
            _context.BookShelves.Add(bookShelves);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookShelves", new { id = bookShelves.Id }, bookShelves);
        }

        // DELETE: api/BookShelves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookShelves>> DeleteBookShelves(int id)
        {
            var bookShelves = await _context.BookShelves.FindAsync(id);
            if (bookShelves == null)
            {
                return NotFound();
            }

            _context.BookShelves.Remove(bookShelves);
            await _context.SaveChangesAsync();

            return bookShelves;
        }

        private bool BookShelvesExists(string id)
        {
            return _context.BookShelves.Any(e => e.Id == id);
        }
    }
}
