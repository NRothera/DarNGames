using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DarNGames.Data;
using DarNGames.Models;

namespace DarNGames.Pages.VendorSubcategories
{
    public class IndexModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public IndexModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        public IList<Models.VendorSubcategories> VendorSubcategories { get;set; }

        public async Task OnGetAsync()
        {
            VendorSubcategories = await _context.VendorSubcategories.ToListAsync();
        }
    }
}
