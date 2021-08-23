using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarNGames.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageLink { get; set; }
        public int VendorSubcategoryId { get; set; }
        public Guid ProfileId { get; set; }

    }
}
