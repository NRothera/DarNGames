using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DarNGames.Data;
using DarNGames.Models;

namespace DarNGames.Pages.ProfilePages
{
    public class DetailsModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public DetailsModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        public Profile Profile { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Profile = await _context.Profile.FirstOrDefaultAsync(m => m.Id == id);

            if (Profile == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
