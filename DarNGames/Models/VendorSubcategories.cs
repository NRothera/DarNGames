using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DarNGames.Models
{
    public class VendorSubcategories
    {
        public int Id { get; set; }
        public string ImageLink { get; set; }
        public string Title { get; set; }
        public int GameVendorId { get; set; }
        public List<CommonGameProperties> CommonGameProperties {get; set; }
    }
}
