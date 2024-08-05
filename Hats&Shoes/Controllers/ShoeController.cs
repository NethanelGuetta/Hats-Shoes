using Microsoft.AspNetCore.Mvc;
using Hats_Shoes.DAL;
using Hats_Shoes.Models;
using System;


namespace Hats_Shoes.Controllers
{
    public class ShoeController : Controller
    {
        private readonly ILogger<ShoeController> _logger;

        public ShoeController(ILogger<ShoeController> logger)
        {
            _logger = logger;
        }

        //מציג את כל הנעליים
        public IActionResult Index()
        {
            var Shoes = Data.Get.Shoes.ToList();
            return View(Shoes);
        }

        public IActionResult Delete(int? id)
        { 
            if (id == null) return RedirectToAction("Index");
            Shoe? shoeToDelete = Data.Get.Shoes.FirstOrDefault(x => x.Id == id);
            if (shoeToDelete == null) return RedirectToAction("Index");

            Data.Get.Remove(shoeToDelete);
            Data.Get.SaveChanges();

            return RedirectToAction("Index");
           
        }
    }
}
