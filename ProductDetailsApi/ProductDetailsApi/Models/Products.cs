using System;
using System.Collections.Generic;

namespace ProductDetailsApi.Models
{
    public partial class Products
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public string Color { get; set; }
        public string Path { get; set; }
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string SubCategory { get; set; }
        public string Category { get; set; }
    }
}
