using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week3ClassDemo.Models
{
    public class Article
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
