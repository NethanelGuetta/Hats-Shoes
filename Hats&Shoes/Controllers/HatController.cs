using Hats_Shoes.DAL;
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



    }
}
