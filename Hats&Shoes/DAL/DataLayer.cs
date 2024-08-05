using Microsoft.EntityFrameworkCore;
using Hats_Shoes.Models;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace Hats_Shoes.DAL
{
    public class DataLayer : DbContext
    {
        // change
        public DataLayer(string connectionString) : base(GetOptions(connectionString))
        {
            Database.EnsureCreated();
            Seed();
        }

        private void Seed() 
        {
            if (Shoes.Any()) return;
            Shoe shoe = new Shoe ( 44,  "black",  "Adidas", "https://www.google.com/imgres?q=adidas%20shoe&imgurl=https%3A%2F%2Fassets.adidas.com%2Fimages%2Fw_600%2Cf_auto%2Cq_auto%2Fb768c27751ec43ab8815ae71001fbb7c_9366%2FNora_Shoes_Black_GV6777_01_standard.jpg&imgrefurl=https%3A%2F%2Fwww.adidas.com%2Fus%2Fnora-shoes%2FGV6777.html&docid=IUM1yo8vxj5cmM&tbnid=Rw2HCHwm7HlRWM&vet=12ahUKEwir4qX0nN2HAxUQZ0EAHbsrEgMQM3oECGMQAA..i&w=600&h=600&hcb=2&ved=2ahUKEwir4qX0nN2HAxUQZ0EAHbsrEgMQM3oECGMQAA");
            Shoes.Add(shoe);    
            SaveChanges();
        
        }
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
