namespace Thermo.Entities;

public class Saturated134APressureProperty
{
    public int Id { get; set; }
    public double Pressure { get; set; }
    public double SatTemperature { get; set; }
    public double SatLiquidSpecificVolume { get; set; }
    public double SatVaporSpecificVolume { get; set; }
    public double SatLiquidInternalEnergy { get; set; }
    public double EvapInternalEnergy { get; set; }
    public double SatVaporInternalEnergy { get; set; }
    public double SatLiquidEnthalpy { get; set; }
    public double EvapEnthalpy { get; set; }
    public double SatVaporEnthalpy { get; set; }
    public double SatLiquidEntropy { get; set; }
    public double EvapEntropy { get; set; }
    public double SatVaporEntropy { get; set; }
}