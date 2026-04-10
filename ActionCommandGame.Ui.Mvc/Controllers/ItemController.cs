using Microsoft.AspNetCore.Mvc;
using ActionCommandGame.Sdk;

namespace ActionCommandGame.Ui.Mvc.Controllers
{
    public class ItemController(ItemSdk itemSdk) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await itemSdk.Find();
            return View(result?.Data);
        }
    }
}
