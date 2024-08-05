using Microsoft.EntityFrameworkCore;
using Hats_Shoes.Models;
using System;

namespace Hats_Shoes.DAL
{
    public class DataLayer : DbContext
    {
        public DataLayer(string connectionString) : base(GetOptions(connectionString))
        {
            Database.EnsureCreated();
            Seed();
        }

        private void Seed() { }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .Options;
        }

        public DbSet<Hat> Hats { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
 
    }
}
