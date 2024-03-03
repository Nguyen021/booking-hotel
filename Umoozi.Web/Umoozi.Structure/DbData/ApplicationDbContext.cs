using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umoozi.Domain.Entities;

namespace Umoozi.Structure.DbData
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<House> Houses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); when add identity we will need it

            modelBuilder.Entity<House>().HasData(
                new House
                {
                    Id = 1,
                    Name = "Name",
                    Description = "Description",
                    ImgUrl = "",
                    Occupancy =4,
                    SquareFeet = 550
                },
                 new House
                 {
                     Id = 2,
                     Name = "Name @2",
                     Description = "Description",
                     ImgUrl = "",
                     Occupancy = 4,
                     SquareFeet = 550
                 });

        }
        public void SeedDataHouse()
        {
            var faker = new Faker<House>()
                .RuleFor(t => t.Id, f => f.UniqueIndex)
                .RuleFor(t => t.Name, f => f.Company.CompanyName())
                .RuleFor(t => t.Description, f => f.Lorem.Paragraph())
                .RuleFor(t => t.Price, f => f.Random.Double(100, 10000))
                .RuleFor(t => t.SquareFeet, f => f.Random.Int(100, 500))
                .RuleFor(t => t.Occupancy, f => f.Random.Int(1, 10))
                .RuleFor(t => t.ImgUrl, f => f.Internet.Url());

            var table = faker.Generate(10);
            Houses.AddRange(table);
            SaveChanges();
        }
    }
}
