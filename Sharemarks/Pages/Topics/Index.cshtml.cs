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
    public class IndexModel : PageModel
    {
        private readonly Sharemarks.Models.SharemarksContext _context;

        public IndexModel(Sharemarks.Models.SharemarksContext context)
        {
            _context = context;
        }

        public IList<Topic> Topic { get;set; }

        public async Task OnGetAsync()
        {
            Topic = await _context.Topic.ToListAsync();
        }
    }
}
