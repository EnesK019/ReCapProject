using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Cars;Trusted_Connection=true");
        }

        public DbSet<Car> car { get; set; }
        public DbSet<Brand> brand { get; set; }
        public DbSet<Color> color { get; set; }
    }
}
