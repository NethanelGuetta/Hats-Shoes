using System.ComponentModel.DataAnnotations;

namespace Hats_Shoes.Models
{
    public class Shoe
    {
        [Key]
        public int Id { get; set; }

        [Display (Name = "size")]
        public int Size { get; set; }

        [Display(Name = "color")]
        public string Color { get; set; }

        [Display(Name = "brand")]
        public string Brand { get; set; }

        [Display (Name = "image")]
        public string Image { get; set; }

        public Shoe (int size, string color, string brand, string image)
        {
            Size = size;
            Color = color;
            Brand = brand;
            Image = image;
        }

        public Shoe() { }
    }
}
