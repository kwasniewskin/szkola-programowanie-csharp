using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzelicznikWPF.Model.BazaDanych.Model
{
    class DataBaseContext : DbContext
    {
        //add-migration "message" -OutputDir BazaDanych/Migrations
        //update-database

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=bazaPrzelicznik.db");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Rodzaj> Rodzaj { get; set; }

        public DbSet<Jednostki> Jednostki { get; set; }

        public DbSet<Przeliczniki> Przeliczniki { get; set; }

    }
}
