using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thermo.Data;
using Thermo.Entities;
using Thermo.Models;
using Thermo.Services;

namespace Thermo.Controllers;

public class CalculationController : Controller
{
    private readonly ThermoContext _context;

    public CalculationController(ThermoContext context)
    {
        _context=context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SaturatedWaterTemperature(ThermodynamicValue value)
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