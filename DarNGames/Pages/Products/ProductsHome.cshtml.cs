using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DarNGames.Data;
using DarNGames.Models;

namespace DarNGames.Pages.Products
{
    public class ProductsHome : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public ProductsHome(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<DarNGames.Models.Products> Products { get;set; }

        public async Task OnGetAsync(int id)
        {
            Subcategory = new DarNGames.Models.VendorSubcategories();

            Subcategory = (from s in _context.VendorSubcategories where s.Id.Equals(id) select s).FirstOrDefault();
            Products = (from x in _context.Products where x.VendorSubcategoryId.Equals(id) select x).ToList();
        }

        public DarNGames.Models.VendorSubcategories Subcategory { get; set; }
      
    }
}
