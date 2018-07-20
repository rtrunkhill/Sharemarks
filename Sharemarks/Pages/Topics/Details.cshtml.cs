using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sharemarks.Models;
 

namespace Sharemarks.Pages.Topics
{
    public class DetailsModel : PageModel
    {
        private readonly Sharemarks.Models.SharemarksContext _context;

        public DetailsModel(Sharemarks.Models.SharemarksContext context)
        {
            _context = context;
        }

        public Topic Topic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Topic = await _context.Topic
                .Include(b => b.Bookmarks).FirstOrDefaultAsync(m => m.ID == id);

            if (Topic == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
