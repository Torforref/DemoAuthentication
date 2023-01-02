using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Authentication.Models;
using NETCore.Encrypt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Authentication.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var key = "myauth@lgc";

        var username1 = "abcd1234";
        var hashed1 = EncryptProvider.HMACSHA256(username1, key);
        var username2 = "anotherusername";
        var hashed2 = EncryptProvider.HMACSHA256(username2, key);

        var test1 = EncryptProvider.HMACSHA256(username1, key);
        var test2 = EncryptProvider.HMACSHA256(username2, key);

        return View();
    }

    [Authorize(Roles = "Store, admin")]
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }


}
