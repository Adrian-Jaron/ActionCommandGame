using ActionCommandGame.Sdk;
using ActionCommandGame.Services.Model.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.Mvc.Controllers
{
    public class AuthController(AuthSdk authSdk) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserSignInRequest request)
        {
            var token = await authSdk.Login(request);
            if (token is null)
            {
                ModelState.AddModelError(string.Empty, "Verkeerd email of wachtwoord");
                return View(request);
            }

            HttpContext.Session.SetString("JwtToken", token);
            return RedirectToAction("Index", "Game");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            var result = await authSdk.Register(request);
            if (result is null)
            {
                ModelState.AddModelError(string.Empty, "Registratie mislukt");
                return View(request);
            }
            return RedirectToAction("Login");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JwtToken");
            return RedirectToAction("Login");
        }
    }
}
