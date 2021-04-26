using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DarNGames.Data;
using DarNGames.Models;

namespace DarNGames.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public EditModel(DarNGames.Data.DarNGamesContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CommonGameProperties).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommonGamePropertiesExists(CommonGameProperties.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CommonGamePropertiesExists(int id)
        {
            return _context.CommonGameProperties.Any(e => e.Id == id);
        }
    }
}
