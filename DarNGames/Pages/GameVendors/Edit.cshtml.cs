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

namespace DarNGames.Pages.GameVendors
{
    public class EditModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public EditModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.GameVendors GameVendors { get; set; }

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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GameVendors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameVendorsExists(GameVendors.Id))
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

        private bool GameVendorsExists(int id)
        {
            return _context.GameVendors.Any(e => e.Id == id);
        }
    }
}
