using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharemarks.Models
{
    public class Bookmark
    {
        public int ID { get; set; }
        public string Url { get; set; }

        public int TopicID { get; set; }
        public Topic Topic { get; set; }
    }
}
