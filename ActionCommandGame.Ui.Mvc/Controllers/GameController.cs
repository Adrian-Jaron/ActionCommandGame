using Microsoft.AspNetCore.Mvc;
using ActionCommandGame.Sdk;

namespace ActionCommandGame.Ui.Mvc.Controllers
{
    public class GameController(GameSdk gameSdk) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PerformAction(int playerId)
        {
            var result = await gameSdk.PerformAction(playerId);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int playerId, int itemId)
        {
            await gameSdk.Buy(playerId, itemId);
            return RedirectToAction("Index", new { playerId });
        }
    }
}

