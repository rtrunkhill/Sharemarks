using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sharemarks.Models;

namespace Sharemarks.Models
{
    public class SharemarksContext : DbContext
    {
        public SharemarksContext (DbContextOptions<SharemarksContext> options)
            : base(options)
        {
        }

        public DbSet<Sharemarks.Models.Topic> Topic { get; set; }

        public DbSet<Sharemarks.Models.Bookmark> Bookmark { get; set; }
    }
}
