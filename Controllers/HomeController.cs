using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JsonBasedLocalization.Models;
using Microsoft.Extensions.Localization;

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
        var welcomeMessage = _localizer["welcome"];
        Console.WriteLine(welcomeMessage.ResourceNotFound);
        Console.WriteLine(welcomeMessage.Name);
        Console.WriteLine(welcomeMessage.Value);
        ViewBag.welcomeMessage = welcomeMessage;
        return View();
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
