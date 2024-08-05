using Microsoft.AspNetCore.Mvc;
using Hats_Shoes.DAL;
using Hats_Shoes.Models;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Create()
        {
            return View(new Shoe());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Shoe shoe)
        {

            Data.Get.Shoes.Add(shoe);
            Data.Get.SaveChanges();
            return RedirectToAction("Index");
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
        public IActionResult Edit()
        { return View(); }


        [HttpPost]
        public IActionResult Edit(Shoe shoe)
        {
            if (shoe.Id == null) return RedirectToAction("Index");

            Shoe? shoeToUpdate = Data.Get.Shoes.FirstOrDefault(x => x.Id == shoe.Id);
            if (shoeToUpdate == null) return RedirectToAction("Index");

            shoeToUpdate.Size = shoe.Size;
            shoeToUpdate.Color = shoe.Color;
            shoeToUpdate.Brand = shoe.Brand;        
            shoeToUpdate.Image = shoe.Image;

            Data.Get.Shoes.Update(shoeToUpdate);
            Data.Get.SaveChanges();
           
            return RedirectToAction("Index");
        }
    }
}
