using System.Security.Claims;
using Authentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        public IActionResult Login()
        {
            var claimUser = HttpContext.User;

            if (claimUser.Identity != null)
            {
                if (claimUser.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }


        [HttpPost]
        public IActionResult Login(UserForLogin model)
        {

            if (model.Email == "admin@logicode.co.th" && model.Password == "123")
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, model.Email),
                    new Claim(ClaimTypes.Role, "admin"),
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    IsPersistent = true,
                });
                return RedirectToAction("Index", "Home");
            }

            ViewData["ValidataMessage"] = "User not found.";
            return View();
        }

    }
}