using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarNGames.HelperMethods;
using DarNGames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DarNGames.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Profile Profile { get; set; }

        private readonly DarNGames.Data.DarNGamesContext _context;


        public LoginModel(DarNGames.Data.DarNGamesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
     

        public async Task<IActionResult> OnPost()
        {
            var options = new HashingOptions
            {
                Iterations = 10000
            };

            Profile = _context.Profile.FirstOrDefault(p => p.Email == Profile.Email);
            var passwordHasher = new PasswordHasher(options);
            var isCorrectPassword = passwordHasher.Check(Profile.Password, Profile.Password);

            return Redirect($"./ProfilePages/ProfilePage/{Profile.Id}");


        }
    }
}
