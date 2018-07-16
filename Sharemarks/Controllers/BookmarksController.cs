using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sharemarks.Models;

namespace Sharemarks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly SharemarksContext _context;

        public BookmarksController(SharemarksContext context)
        {
            _context = context;
        }

        // GET: api/Bookmarks
        [HttpGet]
        public IEnumerable<Bookmark> GetBookmark()
        {
            return _context.Bookmark;
        }

        // GET: api/Bookmarks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookmark([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookmark = await _context.Bookmark.FindAsync(id);

            if (bookmark == null)
            {
                return NotFound();
            }

            return Ok(bookmark);
        }

        // PUT: api/Bookmarks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookmark([FromRoute] int id, [FromBody] Bookmark bookmark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookmark.ID)
            {
                return BadRequest();
            }

            _context.Entry(bookmark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookmarkExists(id))
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

        // POST: api/Bookmarks
        [HttpPost]
        public async Task<IActionResult> PostBookmark([FromBody] Bookmark bookmark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bookmark.Add(bookmark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookmark", new { id = bookmark.ID }, bookmark);
        }

        // DELETE: api/Bookmarks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookmark([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookmark = await _context.Bookmark.FindAsync(id);
            if (bookmark == null)
            {
                return NotFound();
            }

            _context.Bookmark.Remove(bookmark);
            await _context.SaveChangesAsync();

            return Ok(bookmark);
        }

        private bool BookmarkExists(int id)
        {
            return _context.Bookmark.Any(e => e.ID == id);
        }
    }
}