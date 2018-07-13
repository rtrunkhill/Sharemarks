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
    public class IndexModel : PageModel
    {
        private readonly Sharemarks.Models.SharemarksContext _context;

        public IndexModel(Sharemarks.Models.SharemarksContext context)
        {
            _context = context;
        }

        public IList<Bookmark> Bookmark { get;set; }

        public async Task OnGetAsync()
        {
            Bookmark = await _context.Bookmark
                .Include(b => b.Topic).ToListAsync();
        }
    }
}
