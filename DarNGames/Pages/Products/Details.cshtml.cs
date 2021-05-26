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
    public class DetailsModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public DetailsModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        public DarNGames.Models.Products Products { get; set; }

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
    }
}
