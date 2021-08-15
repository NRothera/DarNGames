using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DarNGames.Models;

namespace DarNGames.Pages.Products
{
    public class ProductModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public ProductModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Products Product { get; set; }
        public Models.VendorSubcategories VendorSubcategory { get; set; }
        public Models.Vendors Vendor { get; set; }
        public string[] Images { get; set; }
        public int FocusedImage { get; set; }

        public void OnGet(int productId)
        {
            Product =  _context.Products.Find(productId);
            VendorSubcategory = _context.VendorSubcategories.Find(Product.VendorSubcategoryId);
            Vendor = _context.GameVendors.Find(VendorSubcategory.GameVendorId);
            FocusedImage = 0;
            Images = Product.ImageLink.Split(",");
        }

        public void ChangeImage(int index)
        {
            FocusedImage = index;
        }
    }
}
