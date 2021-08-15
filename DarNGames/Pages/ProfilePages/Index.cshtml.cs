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
    public class IndexModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public IndexModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        public IList<Profile> Profile { get;set; }

        public async Task OnGetAsync()
        {
            Profile = await _context.Profile.ToListAsync();
        }
    }
}
