using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarNGames.Models
{
    public class VendorAndSubcategory
    {
        public Vendors GameVendor { get; set; }
        public List<VendorSubcategories> VendorSubcategory { get; set; }
    }
}
