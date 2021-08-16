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
    public class ProfilePage : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;

        public ProfilePage(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        public Profile Profile { get;set; }

        public async Task OnGetAsync(Guid profileId)
        {
            Profile =  _context.Profile.FirstOrDefault(p => p.Id == profileId);
        }
    }
}
