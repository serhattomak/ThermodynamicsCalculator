using Microsoft.AspNetCore.Mvc;
using Thermo.Entities;
using Thermo.Models;
using Thermo.Services;

namespace Thermo.Controllers;

public class CalculationController : Controller
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