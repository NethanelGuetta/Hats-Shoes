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
    }
}
