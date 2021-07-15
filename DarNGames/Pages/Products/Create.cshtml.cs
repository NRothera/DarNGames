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
            var vendor = _context.GameVendors.Where(g => g.Id == gameVendorId).FirstOrDefault().VendorTitle;
            var subcategory = _context.VendorSubcategories.Where(vendor => vendor.Id == subcategoryId).FirstOrDefault().Title;
            var savePath = System.IO.Directory.GetCurrentDirectory() + @"\\wwwroot\\Images\\" + vendor + "\\" + subcategory + "\\";
            if (!System.IO.Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            var fileName = String.Empty;
            var filePath = String.Empty;
            var size = files.Sum(f => f.Length);
            var imageLinkString = "";
           foreach (var file in files)
            {
                if (imageLinkString != "")
                {
                    imageLinkString = imageLinkString + ",";
                }
                fileName = Path.GetRandomFileName();
                Console.WriteLine(fileName);
                fileName = Path.ChangeExtension(fileName, ".jpg");
                Console.WriteLine(fileName);

                filePath = Path.Combine(savePath, fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                imageLinkString = imageLinkString + fileName;
            }

            Products.VendorSubcategoryId = SubcategoryId;
            Products.ImageLink = imageLinkString;
            _context.Products.Add(Products);
            await _context.SaveChangesAsync();

            return Redirect($"/Products/ProductsHome/{SubcategoryId}/{gameVendorId}");
        }


    }
}
