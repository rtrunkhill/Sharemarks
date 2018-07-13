using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharemarks.Models
{
    public class Topic
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public ICollection<Bookmark> Bookmarks { get; set; }
    }
}
