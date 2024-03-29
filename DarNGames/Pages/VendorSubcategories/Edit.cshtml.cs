﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DarNGames.Data;
using DarNGames.Models;

namespace DarNGames.Pages.VendorSubcategories
{
    public class EditModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public EditModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        public int GameVendorId { get; set; }
        [BindProperty]
        public Models.VendorSubcategories VendorSubcategories { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VendorSubcategories = await _context.VendorSubcategories.FirstOrDefaultAsync(m => m.Id == id);

            if (VendorSubcategories == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int gameVendorId)
        {
            GameVendorId = gameVendorId;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VendorSubcategories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorSubcategoriesExists(VendorSubcategories.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect($"./{GameVendorId}");
        }

        private bool VendorSubcategoriesExists(int id)
        {
            return _context.VendorSubcategories.Any(e => e.Id == id);
        }
    }
}
