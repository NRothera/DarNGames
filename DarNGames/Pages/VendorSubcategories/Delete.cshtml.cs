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

namespace DarNGames.Pages.VendorSubcategories
{
    public class DeleteModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public DeleteModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        public int GameVendorId { get; set; }
        [BindProperty]
        public Models.VendorSubcategories VendorSubcategories { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VendorSubcategories = await _context.VendorSubcategories.FirstOrDefaultAsync(m => m.Id == id);

            if (VendorSubcategories == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int gameVendorId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var gameVendor = await  _context.GameVendors.FindAsync(gameVendorId);
            GameVendorId = gameVendorId;
            VendorSubcategories = await _context.VendorSubcategories.FindAsync(id);

            if (VendorSubcategories != null)
            {
                var currentDirectory = System.IO.Directory.GetCurrentDirectory();

                var productsInSubcategory = _context.Products.Where(x => x.VendorSubcategoryId == VendorSubcategories.Id).ToList();
                foreach (var product in productsInSubcategory)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                }
                _context.VendorSubcategories.Remove(VendorSubcategories);
                await _context.SaveChangesAsync();

                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(currentDirectory + $"\\wwwroot\\Images\\{gameVendor.VendorTitle}\\{VendorSubcategories.Title}");
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }

            return Redirect($"./{GameVendorId}");
        }

    }
}
