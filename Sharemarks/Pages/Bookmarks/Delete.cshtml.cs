using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sharemarks.Models;

namespace Sharemarks.Pages.Bookmarks
{
    public class DeleteModel : PageModel
    {
        private readonly Sharemarks.Models.SharemarksContext _context;

        public DeleteModel(Sharemarks.Models.SharemarksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bookmark Bookmark { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bookmark = await _context.Bookmark
                .Include(b => b.Topic).FirstOrDefaultAsync(m => m.ID == id);

            if (Bookmark == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bookmark = await _context.Bookmark.FindAsync(id);

            if (Bookmark != null)
            {
                _context.Bookmark.Remove(Bookmark);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
