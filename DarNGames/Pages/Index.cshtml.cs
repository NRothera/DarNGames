using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarNGames.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DarNGames.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public IndexModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        public IList<Models.GameVendors> GameVendors { get; set; }

        public async Task OnGetAsync()
        {
            GameVendors = await _context.GameVendors.ToListAsync();
        }

    }
}
