using Microsoft.EntityFrameworkCore;
using Thermo.Entities;

namespace Thermo.Data;

public class ThermoContext : DbContext
{
    public ThermoContext(DbContextOptions<ThermoContext> options) : base(options)
    {

    }
    
    public DbSet<SaturatedWaterTemperatureProperty> SaturatedWaterTemperatureProperties { get; set; }
    public DbSet<SaturatedWaterPressureProperty> SaturatedWaterPressureProperties { get; set; }
    public DbSet<Saturated134ATemperatureProperty> Saturated134ATemperatureProperties { get; set; }
    public DbSet<Saturated134APressureProperty> Saturated134APressureProperties { get; set; }
}