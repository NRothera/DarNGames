using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DarNGames.Data;
using DarNGames.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Web;

namespace DarNGames.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public CreateModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        
        [BindProperty]
        public DarNGames.Models.Products Products { get; set; }
        public int SubcategoryId { get; set; }
        public Models.VendorSubcategories VendorSubcategory { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int subcategoryId, int gameVendorId)
        {
            SubcategoryId = subcategoryId;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var files = Request.Form.Files;

            var savePath = System.IO.Directory.GetCurrentDirectory() + "\\Data\\Nintento\\Test\\";
            if (!System.IO.Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            var size = files.Sum(f => f.Length);
           foreach(var file in files)
            {
                string untrustedFileName = Path.GetRandomFileName();
                var pathToCheck = savePath + untrustedFileName;

                var filePath = Path.Combine(savePath, Path.GetRandomFileName());

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }

            }

           


            Products.VendorSubcategoryId = SubcategoryId;
            _context.Products.Add(Products);
            await _context.SaveChangesAsync();

            return Redirect($"/Products/ProductsHome/{SubcategoryId}/{gameVendorId}");
        }


    }
}
