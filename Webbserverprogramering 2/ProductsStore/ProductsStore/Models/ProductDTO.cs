using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsStore.Models;

namespace ProductsStore.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}