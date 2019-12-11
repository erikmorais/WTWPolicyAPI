using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WTW.App.Domain;

namespace WTW.App.Data.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PolicyHolder>().HasData(
             new PolicyHolder
             {
                 Id = 1,
                 Name = "Dwayne Johnson",
                 Age = 44,
                 Gender = Gender.Male
             },
             new PolicyHolder
             {
                 Id = 2,
                 Name = "John Cena",
                 Age = 38,
                 Gender = Gender.Male
             },

            new PolicyHolder
            {
                Id = 3,
                Name = "Trish Stratus",
                Age = 42,
                Gender = Gender.Female
            }
                );
            modelBuilder.Entity<Policy>().HasData(
                 new Policy
                 {
                     PolicyNumber = 739562,
                     PolicyHolderId = 1
                 },
                new Policy
                {
                    PolicyNumber = 383002,
                    PolicyHolderId = 1
                },
                new Policy
                {
                    PolicyNumber = 462946,
                    PolicyHolderId = 2
                },
                new Policy
                {
                    PolicyNumber = 355679,
                    PolicyHolderId = 3
                },
                new Policy
                {
                    PolicyNumber = 589881,
                    PolicyHolderId = 3
                },
                new Policy
                {
                    PolicyNumber = 998256,
                    PolicyHolderId = 3
                },
                new Policy
                {
                    PolicyNumber = 100374,
                    PolicyHolderId = 3
                }
        );
        }
    }
}