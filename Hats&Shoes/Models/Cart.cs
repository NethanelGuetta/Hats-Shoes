using System.ComponentModel.DataAnnotations;

namespace Hats_Shoes.Models
{
	public class Cart
	{
		[Key]
		public int Id { get; set; }
		[Display(Name = "כובעים")]
		public List <Hat> Hats { get; set; }
		[Display(Name = "נעליים")]
		public List<Shoe> Shoes { get;set; }

		public Cart() 
		{ 
			Hats = new List<Hat>();
			Shoes = new List<Shoe>();
		}
	}
}
