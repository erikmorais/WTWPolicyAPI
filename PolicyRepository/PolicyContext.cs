using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WTW.App.Data.SeedData;
using WTW.App.Domain;

namespace WTW.App.Data
{
    public class PolicyContext : DbContext
    {
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyHolder> PolicyHolders { get; set; }
        //public PolicyContext(DbContextOptions<PolicyContext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                 "Server =  DESKTOP-SFC808U; Database = DBPolicy; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>()
                .HasKey(s => new { s.PolicyNumber});


            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}
