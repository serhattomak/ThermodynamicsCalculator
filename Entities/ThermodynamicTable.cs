namespace Thermo.Entities
{
    public class ThermodynamicTable
    {
        public int Id { get; set; }
        public string TableName { get; set; }

        public int ThermodynamicPropertyId { get; set; }

        public List<ThermodynamicProperty> ThermodynamicProperties { get; set; }
    }
}
