﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DarNGames.Models;

namespace DarNGames.Data
{
    public class DarNGamesContext : DbContext
    {
        public DarNGamesContext (DbContextOptions<DarNGamesContext> options)
            : base(options)
        {
        }

        public DbSet<DarNGames.Models.GameVendors> GameVendors { get; set; }
        public DbSet<DarNGames.Models.VendorSubcategories> VendorSubcategories { get; set; }
        public DbSet<DarNGames.Models.CommonGameProperties> CommonGameProperties { get; set; }

    }
}
