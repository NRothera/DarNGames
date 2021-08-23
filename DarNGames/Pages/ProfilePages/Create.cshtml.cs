using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DarNGames.Data;
using DarNGames.Models;
using DarNGames.HelperMethods;
using Microsoft.Extensions.Options;

namespace DarNGames.Pages.ProfilePages
{
    public class CreateModel : PageModel
    {
        private readonly DarNGames.Data.DarNGamesContext _context;
        private PasswordHasher passwordHasher;
        public CreateModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Profile Profile { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var options = new HashingOptions();
            options.Iterations = 10000;
            passwordHasher = new PasswordHasher(options);
            var password = passwordHasher.Hash(Profile.Password);

            Profile.Password = password;

            _context.Profile.Add(Profile);
            await _context.SaveChangesAsync();

            return Redirect($"/ProfilePages/ProfilePage/{Profile.Id}");
        }
    }
}
