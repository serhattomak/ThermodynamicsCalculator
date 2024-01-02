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

        var sicaklikVerisi = _context.ThermodynamicValues.FirstOrDefault(s=>s.Value==value.Value);

        if (sicaklikVerisi == null)
        {
            var kucukSicaklik=_context.ThermodynamicValues.FirstOrDefault(k=>k.Value<value.Value);
            var buyukSicaklik = _context.ThermodynamicValues.FirstOrDefault(b => b.Value > value.Value);
        }
            /*if (model.InputTemperature.HasValue)
            {
                var data = GetDataFromDatabase();
    
                if (data != null)
                {
                    // Eşleşen verileri güncelleme yeri
    
                    model.SaturationPressure = data.SaturationPressure;
    
                    // Diğer özellikler de burada güncellenebilir.
                }
            }
            else
            {
                //Eşleşen veri yoksa interpolasyon.
                model.SaturationPressure=Interpolasyon(model.InputTemperature.Value);
            }*/
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