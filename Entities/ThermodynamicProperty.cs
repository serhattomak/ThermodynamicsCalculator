namespace Thermo.Entities
{
    public class ThermodynamicProperty
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public List<ThermodynamicValue> ThermodynamicValues { get; set; }
    }
}
