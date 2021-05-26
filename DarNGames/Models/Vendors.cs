using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DarNGames.Models
{
    public class Vendors
    {
        public int Id { get; set; }
        public string VendorTitle { get; set; }
        public string ImageLink { get; set; }
    }
}
