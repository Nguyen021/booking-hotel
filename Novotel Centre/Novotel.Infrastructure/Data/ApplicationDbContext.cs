﻿using Microsoft.EntityFrameworkCore;
using Novotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novotel.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<House> Houses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    Id = 1,
                    Name = "Royal House",
                    Description = "",
                    ImageUrl= "https://placehold.co/600x400",
                    Occupancy=4,
                    Price=400,
                    Sqft=550,
                },
                new House
                {
                    Id = 2,
                    Name = "Royal House",
                    Description = "",
                    ImageUrl = "https://placehold.co/600x400",
                    Occupancy = 3,
                    Price = 300,
                    Sqft = 540,
                },
                new House
                {
                    Id = 3,
                    Name = "Royal House",
                    Description = "",
                    ImageUrl = "https://placehold.co/600x400",
                    Occupancy = 4,
                    Price = 500,
                    Sqft = 650,
                }
                );
            modelBuilder.Entity<HouseNumber>().HasData(
                new HouseNumber
                {
                    House_Number = 101,
                    HouseId = 1,
                },
                 new HouseNumber
                 {
                     House_Number = 102,
                     HouseId = 1,
                 },
                  new HouseNumber
                  {
                      House_Number = 103,
                      HouseId = 1,
                  },
                   new HouseNumber
                   {
                       House_Number = 201,
                       HouseId = 2,
                   },
                    new HouseNumber
                    {
                        House_Number = 202,
                        HouseId = 2,
                    }
                );

        }

        public DbSet<HouseNumber> HousesNumbers { get; set; }


    }
   
}
