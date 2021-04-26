using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DarNGames.Data;
using DarNGames.Models;

namespace DarNGames.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public DeleteModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CommonGameProperties CommonGameProperties { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CommonGameProperties = await _context.CommonGameProperties.FirstOrDefaultAsync(m => m.Id == id);

            if (CommonGameProperties == null)
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

            CommonGameProperties = await _context.CommonGameProperties.FindAsync(id);

            if (CommonGameProperties != null)
            {
                _context.CommonGameProperties.Remove(CommonGameProperties);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
