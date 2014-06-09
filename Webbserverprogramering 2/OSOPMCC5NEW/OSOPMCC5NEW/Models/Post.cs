using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSOPMCC5NEW.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Alias { get; set; }
    }
}