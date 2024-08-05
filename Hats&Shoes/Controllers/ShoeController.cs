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
    }
}
