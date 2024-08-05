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
            if (!Hats.Any())
            {
                Hat hat = new Hat(41,"black","adidas", "data:image/webp;base64,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");
                Hats.Add(hat);
                Data.Get.SaveChanges();
            }
            if (!Shoes.Any())
            {
                Shoe shoe = new Shoe(44, "black", "Adidas", "https://www.google.com/imgres?q=adidas%20shoe&imgurl=https%3A%2F%2Fassets.adidas.com%2Fimages%2Fw_600%2Cf_auto%2Cq_auto%2Fb768c27751ec43ab8815ae71001fbb7c_9366%2FNora_Shoes_Black_GV6777_01_standard.jpg&imgrefurl=https%3A%2F%2Fwww.adidas.com%2Fus%2Fnora-shoes%2FGV6777.html&docid=IUM1yo8vxj5cmM&tbnid=Rw2HCHwm7HlRWM&vet=12ahUKEwir4qX0nN2HAxUQZ0EAHbsrEgMQM3oECGMQAA..i&w=600&h=600&hcb=2&ved=2ahUKEwir4qX0nN2HAxUQZ0EAHbsrEgMQM3oECGMQAA");
                Shoes.Add(shoe);
                Data.Get.SaveChanges();
            }
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
