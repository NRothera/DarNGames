using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarNGames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DarNGames.Pages
{
    public class LoginModel : PageModel
    {
        public Profile Profile;

        public void OnGet()
        {
        }
    }
}
