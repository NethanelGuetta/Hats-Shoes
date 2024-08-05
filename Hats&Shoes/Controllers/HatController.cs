using Hats_Shoes.DAL;
using Hats_Shoes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hats_Shoes.Controllers
{
    public class HatController : Controller
    {
        public IActionResult Index()
        {
            var hats = Data.Get.Hats.ToList();
            return View(hats);
        }
        public IActionResult Delete(int id)
        {
            var hat = Data.Get.Hats.FirstOrDefault(h => h.Id == id);
            Data.Get.Hats.Remove(hat);
            Data.Get.SaveChanges();
            var hats = Data.Get.Hats.ToList();
            TempData["ErrorMessage"] = "נמחק בהצלחה";
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(int id)
        {
            var hat = Data.Get.Hats.FirstOrDefault(h => h.Id == id);
           
            return View(hat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Hat hat2)
        {
            var hat = Data.Get.Hats.FirstOrDefault(h => h.Id ==hat2.Id);
            hat.Brand = hat2.Brand;
            hat.Color = hat2.Color;
            hat.Size = hat2.Size;
            hat.Image = hat2.Image;
            Data.Get.SaveChanges();
			TempData["ErrorMessage"] = "עודכן בהצלחה";

			return RedirectToAction(nameof(Index));
        }

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create( Hat hat)
		{
            Data.Get.Hats.Add(hat);
            Data.Get.SaveChanges();
			TempData["ErrorMessage"] = "נוצר בהצלחה";

			return RedirectToAction(nameof(Index));
		}
	}
}
