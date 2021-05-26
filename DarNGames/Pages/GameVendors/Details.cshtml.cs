using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DarNGames.Data;
using DarNGames.Models;

namespace DarNGames.Pages.GameVendors
{
    public class DetailsModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public DetailsModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        public Models.Vendors GameVendors { get; set; }

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
    }
}
