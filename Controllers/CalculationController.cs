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