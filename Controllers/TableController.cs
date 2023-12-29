using Microsoft.AspNetCore.Mvc;

namespace Thermo.Controllers;

public class TableController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SaturatedWaterTemperature()
    {
        return View();
    }
    public IActionResult SaturatedWaterPressure()
    {
        return View();
    }
    public IActionResult SaturatedR134ATemperature()
    {
        return View();
    }
    public IActionResult SaturatedR134APressure()
    {
        return View();
    }
}