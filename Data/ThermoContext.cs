using Microsoft.EntityFrameworkCore;
using Thermo.Entities;

namespace Thermo.Data;

public class ThermoContext : DbContext
{
    public ThermoContext(DbContextOptions<ThermoContext> options) : base(options)
    {

    }

    public DbSet<ThermodynamicProperty> ThermodynamicProperties { get; set; }
    public DbSet<ThermodynamicTable> ThermodynamicTables { get; set; }
    public DbSet<ThermodynamicValue> ThermodynamicValues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ThermodynamicProperty>().Property(b => b.PropertyName).IsRequired();
        modelBuilder.Entity<ThermodynamicTable>().Property(b => b.TableName).IsRequired();
    }
}