using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DarNGames.Data;
using DarNGames.Models;

namespace DarNGames.Pages.VendorSubcategories
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public IndexModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }
        public int Id { get; set; }
        public VendorAndSubcategory VendorAndSubcategory { get; set; }
        public DarNGames.Models.Vendors Vendor { get; set; }
        public Models.VendorSubcategories Subcategory { get; set; }

        public async Task OnGetAsync(int id)
        {
            Id = id;
            VendorAndSubcategory = new VendorAndSubcategory();

            VendorAndSubcategory.GameVendor =  (from g in _context.GameVendors where g.Id.Equals(id) select g).FirstOrDefault();
            VendorAndSubcategory.VendorSubcategory = (from x in _context.VendorSubcategories where x.GameVendorId.Equals(Id) select x).ToList();
        }
    }
}
