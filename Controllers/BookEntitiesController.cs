using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookEntitiesController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookEntitiesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/BookEntities
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<BookEntity>>> GetBookEntities()
        {
            return await _context.BookEntities.ToListAsync();
        }

        // GET: api/BookEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookEntity>> GetBookEntity(int id)
        {
            var bookEntity = await _context.BookEntities.FindAsync(id);

            if (bookEntity == null)
            {
                return NotFound();
            }

            return bookEntity;
        }

        // PUT: api/BookEntities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookEntity(string id, BookEntity bookEntity)
        {
            if (!(id.Equals(bookEntity.Id)))
            {
                return BadRequest();
            }

            _context.Entry(bookEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookEntityExists(id))
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

        // POST: api/BookEntities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookEntity>> PostBookEntity(BookEntity bookEntity)
        {
            _context.BookEntities.Add(bookEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookEntity", new { id = bookEntity.Id }, bookEntity);
        }

        // DELETE: api/BookEntities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookEntity>> DeleteBookEntity(int id)
        {
            var bookEntity = await _context.BookEntities.FindAsync(id);
            if (bookEntity == null)
            {
                return NotFound();
            }

            _context.BookEntities.Remove(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity;
        }

        private bool BookEntityExists(string id)
        {
            return _context.BookEntities.Any(e => e.Id == id);
        }
    }
}
