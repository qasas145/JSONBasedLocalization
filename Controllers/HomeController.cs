using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JsonBasedLocalization.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using JsonBasedLocalization.ViewModels;

namespace JsonBasedLocalization.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStringLocalizer<HomeController> _localizer;

    public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
    {
        _logger = logger;
        _localizer = localizer;
    }

    [HttpPost("getvalue/{name}")]
    public IActionResult GetValue(string name) {
        return Ok(_localizer[name]);
    }
    [HttpPost]
    public IActionResult Create(CreateDTO model) {
        return Ok();
    }
    [HttpPost("changeCulture/{culture}")]
    public IActionResult SetLanguage(string culture){
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName, 
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), 
            new CookieOptions(){Expires = DateTimeOffset.Now.AddYears(1)}
        );
        return Ok("The culture has been changed");
    }

}
