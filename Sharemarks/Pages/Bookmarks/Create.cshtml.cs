using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sharemarks.Models;

namespace Sharemarks.Pages.Bookmarks
{
    public class CreateModel : PageModel
    {
        private readonly Sharemarks.Models.SharemarksContext _context;

        public CreateModel(Sharemarks.Models.SharemarksContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TopicID"] = new SelectList(_context.Topic, "ID", "Title");
            return Page();
        }

        [BindProperty]
        public Bookmark Bookmark { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bookmark.Add(Bookmark);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}