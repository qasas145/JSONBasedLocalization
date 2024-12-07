using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JsonBasedLocalization.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using JsonBasedLocalization.ViewModels;

namespace JsonBasedLocalization.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStringLocalizer<HomeController> _localizer;

    public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
    {
        _logger = logger;
        _localizer = localizer;
    }

    public IActionResult Index()
    {
        var welcomeMessage = _localizer["welcome", "Muhammad Elsayed elqasas"];
        ViewBag.welcomeMessage = welcomeMessage;
        return View();
    }
    public IActionResult Create() {
        return View();
    }
    [HttpPost]
    public IActionResult Create(CreateDTO model) {
        return View();
    }
    [HttpPost]
    public IActionResult SetLanguage(string culture, string returnUrl){
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName, 
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), 
            new CookieOptions(){Expires = DateTimeOffset.Now.AddYears(1)}
        );
        return LocalRedirect(returnUrl);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
