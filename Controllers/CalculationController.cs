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
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SaturatedWaterTemperature()
    {
        return View();
    }
    [HttpPost]
    public IActionResult SaturatedWaterTemperature([FromBody] SaturatedWaterTemperaturePropertyDTO model)
    {
        var query = _context.SaturatedWaterTemperatureProperties.AsQueryable();

        if (!string.IsNullOrWhiteSpace(model.Temperature))
        {
            query = query.Where(x => x.Temperature == Convert.ToDouble(model.Temperature));
        }
        if (!string.IsNullOrWhiteSpace(model.Pressure))
        {
            query = query.Where(x => x.SatPressure == Convert.ToDouble(model.Pressure));
        }
        if (!string.IsNullOrWhiteSpace(model.VolumeFluid))
        {
            query = query.Where(x => x.SatLiquidSpecificVolume == Convert.ToDouble(model.VolumeFluid));
        }
        if (!string.IsNullOrWhiteSpace(model.VolumeVapor))
        {
            query = query.Where(x => x.SatVaporSpecificVolume == Convert.ToDouble(model.VolumeFluid));
        }
        if (!string.IsNullOrWhiteSpace(model.InternalEnergyFluid))
        {
            query = query.Where(x => x.SatLiquidInternalEnergy == Convert.ToDouble(model.InternalEnergyFluid));
        }
        if (!string.IsNullOrWhiteSpace(model.InternalEnergyEvap))
        {
            query = query.Where(x => x.EvapInternalEnergy == Convert.ToDouble(model.InternalEnergyEvap));
        }
        if (!string.IsNullOrWhiteSpace(model.InternalEnergyVapor))
        {
            query = query.Where(x => x.SatVaporInternalEnergy == Convert.ToDouble(model.InternalEnergyVapor));
        }
        if (!string.IsNullOrWhiteSpace(model.EnthalpyFluid))
        {
            query = query.Where(x => x.SatLiquidEnthalpy == Convert.ToDouble(model.EnthalpyFluid));
        }
        if (!string.IsNullOrWhiteSpace(model.EnthalpyEvap))
        {
            query = query.Where(x => x.EvapEnthalpy == Convert.ToDouble(model.EnthalpyEvap));
        }
        if (!string.IsNullOrWhiteSpace(model.EnthalpyVapor))
        {
            query = query.Where(x => x.SatVaporEnthalpy == Convert.ToDouble(model.EnthalpyVapor));
        }
        if (!string.IsNullOrWhiteSpace(model.EntropyFluid))
        {
            query = query.Where(x => x.SatLiquidEntropy == Convert.ToDouble(model.EntropyFluid));
        }
        if (!string.IsNullOrWhiteSpace(model.EntropyEvap))
        {
            query = query.Where(x => x.EvapEntropy == Convert.ToDouble(model.EntropyEvap));
        }
        if (!string.IsNullOrWhiteSpace(model.EntropyVapor))
        {
            query = query.Where(x => x.SatVaporEntropy == Convert.ToDouble(model.EntropyVapor));
        }
        var list =query.ToList();
        if (list.Any())
        {
            var result = list.First();
            return Json(result);
        }
        return Json(new { success = false, message = "Uygun kayıt bulunamadı." });
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