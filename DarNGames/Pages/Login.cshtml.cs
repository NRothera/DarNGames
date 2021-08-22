using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Profile Profile { get; set; }
        [BindProperty, Required, EmailAddress, Compare(nameof(LoginModel.Profile.Email), ErrorMessage ="Sorry your email or password was incorrect")]
        public string Email { get; set; }
        [BindProperty, Required, Compare(nameof(LoginModel.Profile.Password), ErrorMessage = "Sorry your email or password was incorrect")]
        public string Password { get; set; }

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
            Profile = _context.Profile.FirstOrDefault(p => p.Email == Email);
            if (Profile != null)
            {
                
                var passwordHasher = new PasswordHasher(options);
                var isCorrectPassword = passwordHasher.Check(Profile.Password, Password);

                if (isCorrectPassword.Verified)
                {
                    return Redirect($"./ProfilePages/ProfilePage/{Profile.Id}");
                }
                else
                {
                    Console.WriteLine(ModelState);
                    return Page();
                   
                }
            }
            Console.WriteLine(ModelState);
            return Page();
           


        }
    }
}
