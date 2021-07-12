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

namespace DarNGames.Pages.GameVendors
{
    public class DeleteModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public DeleteModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Vendors GameVendors { get; set; }
        public Models.VendorSubcategories VendorSubcategories { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GameVendors = await _context.GameVendors.FirstOrDefaultAsync(m => m.Id == id);

            if (GameVendors == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var allSubcategoriesUnderVendor = _context.VendorSubcategories.Where(x => x.GameVendorId == id).ToList();
            GameVendors = await _context.GameVendors.FindAsync(id);

            if (GameVendors != null)
            {
                var currentDirectory = System.IO.Directory.GetCurrentDirectory();

                foreach (var subCategory in allSubcategoriesUnderVendor)
                {
                    var productsInSubcategory = _context.Products.Where(x => x.VendorSubcategoryId == subCategory.Id).ToList();
                    foreach (var product in productsInSubcategory)
                    {
                        _context.Products.Remove(product);
                        await _context.SaveChangesAsync();
                    }
                    _context.VendorSubcategories.Remove(subCategory);
                    await _context.SaveChangesAsync();
                }
               
                _context.GameVendors.Remove(GameVendors);
                await _context.SaveChangesAsync();

                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(currentDirectory + $"\\wwwroot\\Images\\{GameVendors.VendorTitle}");
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }

            return RedirectToPage("../Index");
        }
    }
}
