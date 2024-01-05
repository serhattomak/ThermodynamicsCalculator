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
        var list = query.ToList();
        if (list.Any())
        {
            var result = list.First();
            return Json(result);
        }
        else if (!list.Any() && !string.IsNullOrWhiteSpace(model.Temperature))
        {
            var (lower, upper) = GetClosestValues(Convert.ToDouble(model.Temperature));
            if (lower != null && upper != null)
            {
                var returnModel = new SaturatedWaterTemperatureProperty
                {
                    Temperature = Convert.ToDouble(model.Temperature),
                    SatPressure = LinearInterpolate(lower.Temperature, lower.SatPressure, upper.Temperature, upper.SatPressure, Convert.ToDouble(model.Temperature)),
                    SatLiquidSpecificVolume = LinearInterpolate(lower.Temperature, lower.SatLiquidSpecificVolume, upper.Temperature, upper.SatLiquidSpecificVolume, Convert.ToDouble(model.Temperature)),
                    SatVaporSpecificVolume = LinearInterpolate(lower.Temperature, lower.SatVaporSpecificVolume, upper.Temperature, upper.SatVaporSpecificVolume, Convert.ToDouble(model.Temperature)),
                    SatLiquidInternalEnergy = LinearInterpolate(lower.Temperature, lower.SatLiquidInternalEnergy, upper.Temperature, upper.SatLiquidInternalEnergy, Convert.ToDouble(model.Temperature)),
                    EvapInternalEnergy = LinearInterpolate(lower.Temperature, lower.EvapInternalEnergy, upper.Temperature, upper.EvapInternalEnergy, Convert.ToDouble(model.Temperature)),
                    SatVaporInternalEnergy = LinearInterpolate(lower.Temperature, lower.SatVaporInternalEnergy, upper.Temperature, upper.SatVaporInternalEnergy, Convert.ToDouble(model.Temperature)),
                    SatLiquidEnthalpy = LinearInterpolate(lower.Temperature, lower.SatLiquidEnthalpy, upper.Temperature, upper.SatLiquidEnthalpy, Convert.ToDouble(model.Temperature)),
                    EvapEnthalpy = LinearInterpolate(lower.Temperature, lower.EvapEnthalpy, upper.Temperature, upper.EvapEnthalpy, Convert.ToDouble(model.Temperature)),
                    SatVaporEnthalpy = LinearInterpolate(lower.Temperature, lower.SatVaporEnthalpy, upper.Temperature, upper.SatVaporEnthalpy, Convert.ToDouble(model.Temperature)),
                    SatLiquidEntropy = LinearInterpolate(lower.Temperature, lower.SatLiquidEntropy, upper.Temperature, upper.SatLiquidEntropy, Convert.ToDouble(model.Temperature)),
                    EvapEntropy = LinearInterpolate(lower.Temperature, lower.EvapEntropy, upper.Temperature, upper.EvapEntropy, Convert.ToDouble(model.Temperature)),
                    SatVaporEntropy = LinearInterpolate(lower.Temperature, lower.SatVaporEntropy, upper.Temperature, upper.SatVaporEntropy, Convert.ToDouble(model.Temperature))
                };
                return Json(returnModel);
            }
        }
        return Json(new { success = false, message = "Uygun kayıt bulunamadı." });
    }

    public double LinearInterpolate(double x0, double y0, double x1, double y1, double x)
    {
        // Yatay (x ekseni) ve dikey (y ekseni) farkları hesapla
        double deltaX = x1 - x0;
        double deltaY = y1 - y0;

        // x'in, x0 ve x1 arasındaki oransal konumunu hesapla
        double ratio = (x - x0) / deltaX;

        // Interpolasyon sonucunu hesapla ve döndür
        double y = y0 + ratio * deltaY;
        return y;
    }
    public (SaturatedWaterTemperatureProperty lower, SaturatedWaterTemperatureProperty upper) GetClosestValues(double targetTemperature)
    {
        var lower = _context.SaturatedWaterTemperatureProperties
            .Where(x => x.Temperature <= targetTemperature)
            .OrderByDescending(x => x.Temperature)
            .FirstOrDefault();

        var upper = _context.SaturatedWaterTemperatureProperties
            .Where(x => x.Temperature > targetTemperature)
            .OrderBy(x => x.Temperature)
            .FirstOrDefault();

        return (lower, upper);
    }

    public IActionResult SaturatedWaterPressure()
    {
        return View();
    }
    [HttpPost]
    public IActionResult SaturatedWaterPressure([FromBody] SaturatedWaterPressurePropertyDTO model)
    {
        var query = _context.SaturatedWaterPressureProperties.AsQueryable();

        if (!string.IsNullOrWhiteSpace(model.Pressure))
        {
            query = query.Where(x => x.Pressure == Convert.ToDouble(model.Pressure));
        }
        if (!string.IsNullOrWhiteSpace(model.Temperature))
        {
            query = query.Where(x => x.SatTemperature == Convert.ToDouble(model.Temperature));
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
        var list = query.ToList();
        if (list.Any())
        {
            var result = list.First();
            return Json(result);
        }
        else if (!list.Any() && !string.IsNullOrWhiteSpace(model.Pressure))
        {
            var (lower, upper) = GetClosestValuesWP(Convert.ToDouble(model.Pressure));
            if (lower != null && upper != null)
            {
                var returnModel = new SaturatedWaterPressureProperty
                {
                    Pressure = Convert.ToDouble(model.Pressure),
                    SatTemperature = LinearInterpolate(lower.Pressure, lower.SatTemperature, upper.Pressure, upper.SatTemperature, Convert.ToDouble(model.Pressure)),
                    SatLiquidSpecificVolume = LinearInterpolate(lower.Pressure, lower.SatLiquidSpecificVolume, upper.Pressure, upper.SatLiquidSpecificVolume, Convert.ToDouble(model.Pressure)),
                    SatVaporSpecificVolume = LinearInterpolate(lower.Pressure, lower.SatVaporSpecificVolume, upper.Pressure, upper.SatVaporSpecificVolume, Convert.ToDouble(model.Pressure)),
                    SatLiquidInternalEnergy = LinearInterpolate(lower.Pressure, lower.SatLiquidInternalEnergy, upper.Pressure, upper.SatLiquidInternalEnergy, Convert.ToDouble(model.Pressure)),
                    EvapInternalEnergy = LinearInterpolate(lower.Pressure, lower.EvapInternalEnergy, upper.Pressure, upper.EvapInternalEnergy, Convert.ToDouble(model.Pressure)),
                    SatVaporInternalEnergy = LinearInterpolate(lower.Pressure, lower.SatVaporInternalEnergy, upper.Pressure, upper.SatVaporInternalEnergy, Convert.ToDouble(model.Pressure)),
                    SatLiquidEnthalpy = LinearInterpolate(lower.Pressure, lower.SatLiquidEnthalpy, upper.Pressure, upper.SatLiquidEnthalpy, Convert.ToDouble(model.Pressure)),
                    EvapEnthalpy = LinearInterpolate(lower.Pressure, lower.EvapEnthalpy, upper.Pressure, upper.EvapEnthalpy, Convert.ToDouble(model.Pressure)),
                    SatVaporEnthalpy = LinearInterpolate(lower.Pressure, lower.SatVaporEnthalpy, upper.Pressure, upper.SatVaporEnthalpy, Convert.ToDouble(model.Pressure)),
                    SatLiquidEntropy = LinearInterpolate(lower.Pressure, lower.SatLiquidEntropy, upper.Pressure, upper.SatLiquidEntropy, Convert.ToDouble(model.Pressure)),
                    EvapEntropy = LinearInterpolate(lower.Pressure, lower.EvapEntropy, upper.Pressure, upper.EvapEntropy, Convert.ToDouble(model.Pressure)),
                    SatVaporEntropy = LinearInterpolate(lower.Pressure, lower.SatVaporEntropy, upper.Pressure, upper.SatVaporEntropy, Convert.ToDouble(model.Pressure))
                };
                return Json(returnModel);
            }
        }
        return Json(new { success = false, message = "Uygun kayıt bulunamadı." });
    }
    public (SaturatedWaterPressureProperty lower, SaturatedWaterPressureProperty upper) GetClosestValuesWP(double targetPressure)
    {
        var lower = _context.SaturatedWaterPressureProperties
            .Where(x => x.Pressure <= targetPressure)
            .OrderByDescending(x => x.Pressure)
            .FirstOrDefault();

        var upper = _context.SaturatedWaterPressureProperties
            .Where(x => x.Pressure > targetPressure)
            .OrderBy(x => x.Pressure)
            .FirstOrDefault();

        return (lower, upper);
    }

    public IActionResult SaturatedR134ATemperature()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SaturatedR134ATemperature([FromBody] Saturated134ATemperaturePropertyDTO model)
    {
        var query = _context.Saturated134ATemperatureProperties.AsQueryable();

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
        var list = query.ToList();
        if (list.Any())
        {
            var result = list.First();
            return Json(result);
        }
        else if (!list.Any() && !string.IsNullOrWhiteSpace(model.Temperature))
        {
            var (lower, upper) = GetClosestValues134A(Convert.ToDouble(model.Temperature));
            if (lower != null && upper != null)
            {
                var returnModel = new Saturated134ATemperatureProperty
                {
                    Temperature = Convert.ToDouble(model.Temperature),
                    SatPressure = LinearInterpolate(lower.Temperature, lower.SatPressure, upper.Temperature, upper.SatPressure, Convert.ToDouble(model.Temperature)),
                    SatLiquidSpecificVolume = LinearInterpolate(lower.Temperature, lower.SatLiquidSpecificVolume, upper.Temperature, upper.SatLiquidSpecificVolume, Convert.ToDouble(model.Temperature)),
                    SatVaporSpecificVolume = LinearInterpolate(lower.Temperature, lower.SatVaporSpecificVolume, upper.Temperature, upper.SatVaporSpecificVolume, Convert.ToDouble(model.Temperature)),
                    SatLiquidInternalEnergy = LinearInterpolate(lower.Temperature, lower.SatLiquidInternalEnergy, upper.Temperature, upper.SatLiquidInternalEnergy, Convert.ToDouble(model.Temperature)),
                    EvapInternalEnergy = LinearInterpolate(lower.Temperature, lower.EvapInternalEnergy, upper.Temperature, upper.EvapInternalEnergy, Convert.ToDouble(model.Temperature)),
                    SatVaporInternalEnergy = LinearInterpolate(lower.Temperature, lower.SatVaporInternalEnergy, upper.Temperature, upper.SatVaporInternalEnergy, Convert.ToDouble(model.Temperature)),
                    SatLiquidEnthalpy = LinearInterpolate(lower.Temperature, lower.SatLiquidEnthalpy, upper.Temperature, upper.SatLiquidEnthalpy, Convert.ToDouble(model.Temperature)),
                    EvapEnthalpy = LinearInterpolate(lower.Temperature, lower.EvapEnthalpy, upper.Temperature, upper.EvapEnthalpy, Convert.ToDouble(model.Temperature)),
                    SatVaporEnthalpy = LinearInterpolate(lower.Temperature, lower.SatVaporEnthalpy, upper.Temperature, upper.SatVaporEnthalpy, Convert.ToDouble(model.Temperature)),
                    SatLiquidEntropy = LinearInterpolate(lower.Temperature, lower.SatLiquidEntropy, upper.Temperature, upper.SatLiquidEntropy, Convert.ToDouble(model.Temperature)),
                    EvapEntropy = LinearInterpolate(lower.Temperature, lower.EvapEntropy, upper.Temperature, upper.EvapEntropy, Convert.ToDouble(model.Temperature)),
                    SatVaporEntropy = LinearInterpolate(lower.Temperature, lower.SatVaporEntropy, upper.Temperature, upper.SatVaporEntropy, Convert.ToDouble(model.Temperature))
                };
                return Json(returnModel);
            }
        }
        return Json(new { success = false, message = "Uygun kayıt bulunamadı." });
    }
    public (Saturated134ATemperatureProperty lower, Saturated134ATemperatureProperty upper) GetClosestValues134A(double targetTemperature)
    {
        var lower = _context.Saturated134ATemperatureProperties
            .Where(x => x.Temperature <= targetTemperature)
            .OrderByDescending(x => x.Temperature)
            .FirstOrDefault();

        var upper = _context.Saturated134ATemperatureProperties
            .Where(x => x.Temperature > targetTemperature)
            .OrderBy(x => x.Temperature)
            .FirstOrDefault();

        return (lower, upper);
    }
    public IActionResult SaturatedR134APressure()
    {
        return View();
    }
    [HttpPost]
    public IActionResult SaturatedR134APressure([FromBody] Saturated134APressurePropertyDTO model)
    {
        var query = _context.Saturated134APressureProperties.AsQueryable();

        if (!string.IsNullOrWhiteSpace(model.Pressure))
        {
            query = query.Where(x => x.Pressure == Convert.ToDouble(model.Pressure));
        }
        if (!string.IsNullOrWhiteSpace(model.Temperature))
        {
            query = query.Where(x => x.SatTemperature == Convert.ToDouble(model.Temperature));
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
        var list = query.ToList();
        if (list.Any())
        {
            var result = list.First();
            return Json(result);
        }
        else if (!list.Any() && !string.IsNullOrWhiteSpace(model.Pressure))
        {
            var (lower, upper) = GetClosestValues134AP(Convert.ToDouble(model.Pressure));
            if (lower != null && upper != null)
            {
                var returnModel = new Saturated134APressureProperty
                {
                    Pressure = Convert.ToDouble(model.Pressure),
                    SatTemperature = LinearInterpolate(lower.Pressure, lower.SatTemperature, upper.Pressure, upper.SatTemperature, Convert.ToDouble(model.Pressure)),
                    SatLiquidSpecificVolume = LinearInterpolate(lower.Pressure, lower.SatLiquidSpecificVolume, upper.Pressure, upper.SatLiquidSpecificVolume, Convert.ToDouble(model.Pressure)),
                    SatVaporSpecificVolume = LinearInterpolate(lower.Pressure, lower.SatVaporSpecificVolume, upper.Pressure, upper.SatVaporSpecificVolume, Convert.ToDouble(model.Pressure)),
                    SatLiquidInternalEnergy = LinearInterpolate(lower.Pressure, lower.SatLiquidInternalEnergy, upper.Pressure, upper.SatLiquidInternalEnergy, Convert.ToDouble(model.Pressure)),
                    EvapInternalEnergy = LinearInterpolate(lower.Pressure, lower.EvapInternalEnergy, upper.Pressure, upper.EvapInternalEnergy, Convert.ToDouble(model.Pressure)),
                    SatVaporInternalEnergy = LinearInterpolate(lower.Pressure, lower.SatVaporInternalEnergy, upper.Pressure, upper.SatVaporInternalEnergy, Convert.ToDouble(model.Pressure)),
                    SatLiquidEnthalpy = LinearInterpolate(lower.Pressure, lower.SatLiquidEnthalpy, upper.Pressure, upper.SatLiquidEnthalpy, Convert.ToDouble(model.Pressure)),
                    EvapEnthalpy = LinearInterpolate(lower.Pressure, lower.EvapEnthalpy, upper.Pressure, upper.EvapEnthalpy, Convert.ToDouble(model.Pressure)),
                    SatVaporEnthalpy = LinearInterpolate(lower.Pressure, lower.SatVaporEnthalpy, upper.Pressure, upper.SatVaporEnthalpy, Convert.ToDouble(model.Pressure)),
                    SatLiquidEntropy = LinearInterpolate(lower.Pressure, lower.SatLiquidEntropy, upper.Pressure, upper.SatLiquidEntropy, Convert.ToDouble(model.Pressure)),
                    EvapEntropy = LinearInterpolate(lower.Pressure, lower.EvapEntropy, upper.Pressure, upper.EvapEntropy, Convert.ToDouble(model.Pressure)),
                    SatVaporEntropy = LinearInterpolate(lower.Pressure, lower.SatVaporEntropy, upper.Pressure, upper.SatVaporEntropy, Convert.ToDouble(model.Pressure))
                };
                return Json(returnModel);
            }
        }
        return Json(new { success = false, message = "Uygun kayıt bulunamadı." });
    }
    public (Saturated134APressureProperty lower, Saturated134APressureProperty upper) GetClosestValues134AP(double targetPressure)
    {
        var lower = _context.Saturated134APressureProperties
            .Where(x => x.Pressure <= targetPressure)
            .OrderByDescending(x => x.Pressure)
            .FirstOrDefault();

        var upper = _context.Saturated134APressureProperties
            .Where(x => x.Pressure > targetPressure)
            .OrderBy(x => x.Pressure)
            .FirstOrDefault();

        return (lower, upper);
    }
}