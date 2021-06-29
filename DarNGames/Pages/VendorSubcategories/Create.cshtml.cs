using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DarNGames.Data;
using DarNGames.Models;
using System.IO;

namespace DarNGames.Pages.VendorSubcategories
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
        public int GameVendorId { get; set; }
        [BindProperty]
        public Models.VendorSubcategories VendorSubcategories { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int gameVendorId)
        {
            GameVendorId = gameVendorId;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            VendorSubcategories.GameVendorId = GameVendorId;
            var gameVendor = _context.GameVendors.Where(g => g.Id == GameVendorId).FirstOrDefault().VendorTitle;

            var files = Request.Form.Files;
            var savePath = System.IO.Directory.GetCurrentDirectory() + @"\\wwwroot\\Images\\" + gameVendor + "\\" + VendorSubcategories.Title + "\\";
            if (!System.IO.Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            var fileName = String.Empty;
            var filePath = String.Empty;
            var size = files.Sum(f => f.Length);
            foreach (var file in files)
            {
                fileName = Path.GetRandomFileName();
                fileName = Path.ChangeExtension(fileName, ".jpg");
                filePath = Path.Combine(savePath, fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
            }
            var fileImagePath = $"Images\\{gameVendor}\\{fileName}".Replace(" ", "%20");
            VendorSubcategories.ImageLink = fileImagePath;

            _context.VendorSubcategories.Add(VendorSubcategories);
            await _context.SaveChangesAsync();

            return Redirect($"./{GameVendorId}");
        }
    }
}
