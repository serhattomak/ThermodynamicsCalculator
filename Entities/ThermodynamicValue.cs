namespace Thermo.Entities
{
    public class ThermodynamicValue
    {
        public int Id { get; set; }
        public double? Value { get; set; }

        public int ThermodynamicPropertyId { get; set; }
        public ThermodynamicProperty ThermodynamicProperty { get; set; }
    }
}
