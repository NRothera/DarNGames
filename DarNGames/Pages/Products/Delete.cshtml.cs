using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DarNGames.Data;
using DarNGames.Models;
using System.IO;

namespace DarNGames.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public DeleteModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DarNGames.Models.Products Products { get; set; }

        public int SubcategoryId { get; set; }
        public Models.VendorSubcategories VendorSubcategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Products = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Products == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int subcategoryId, int gameVendorId)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubcategoryId = subcategoryId;

            var filePath = _context.Products.Where(p => p.Id == id).FirstOrDefault().ImageLink;

            System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\wwwroot\\" + filePath.Replace("%20", " "));

            Products = await _context.Products.FindAsync(id);

            if (Products != null)
            {
                _context.Products.Remove(Products);
                await _context.SaveChangesAsync();
            }

            return Redirect($"/Products/ProductsHome/{Products.VendorSubcategoryId}/{gameVendorId}");
        }
    }
}
