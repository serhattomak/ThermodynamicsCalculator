using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Thermo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Saturated134APressureProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pressure = table.Column<double>(type: "double precision", nullable: false),
                    SatTemperature = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidSpecificVolume = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporSpecificVolume = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidInternalEnergy = table.Column<double>(type: "double precision", nullable: false),
                    EvapInternalEnergy = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporInternalEnergy = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidEnthalpy = table.Column<double>(type: "double precision", nullable: false),
                    EvapEnthalpy = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporEnthalpy = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidEntropy = table.Column<double>(type: "double precision", nullable: false),
                    EvapEntropy = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporEntropy = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saturated134APressureProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saturated134ATemperatureProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Temperature = table.Column<double>(type: "double precision", nullable: false),
                    SatPressure = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidSpecificVolume = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporSpecificVolume = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidInternalEnergy = table.Column<double>(type: "double precision", nullable: false),
                    EvapInternalEnergy = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporInternalEnergy = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidEnthalpy = table.Column<double>(type: "double precision", nullable: false),
                    EvapEnthalpy = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporEnthalpy = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidEntropy = table.Column<double>(type: "double precision", nullable: false),
                    EvapEntropy = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporEntropy = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saturated134ATemperatureProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaturatedWaterPressureProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pressure = table.Column<double>(type: "double precision", nullable: false),
                    SatTemperature = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidSpecificVolume = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporSpecificVolume = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidInternalEnergy = table.Column<double>(type: "double precision", nullable: false),
                    EvapInternalEnergy = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporInternalEnergy = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidEnthalpy = table.Column<double>(type: "double precision", nullable: false),
                    EvapEnthalpy = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporEnthalpy = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidEntropy = table.Column<double>(type: "double precision", nullable: false),
                    EvapEntropy = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporEntropy = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaturatedWaterPressureProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaturatedWaterTemperatureProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Temperature = table.Column<double>(type: "double precision", nullable: false),
                    SatPressure = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidSpecificVolume = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporSpecificVolume = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidInternalEnergy = table.Column<double>(type: "double precision", nullable: false),
                    EvapInternalEnergy = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporInternalEnergy = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidEnthalpy = table.Column<double>(type: "double precision", nullable: false),
                    EvapEnthalpy = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporEnthalpy = table.Column<double>(type: "double precision", nullable: false),
                    SatLiquidEntropy = table.Column<double>(type: "double precision", nullable: false),
                    EvapEntropy = table.Column<double>(type: "double precision", nullable: false),
                    SatVaporEntropy = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaturatedWaterTemperatureProperties", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saturated134APressureProperties");

            migrationBuilder.DropTable(
                name: "Saturated134ATemperatureProperties");

            migrationBuilder.DropTable(
                name: "SaturatedWaterPressureProperties");

            migrationBuilder.DropTable(
                name: "SaturatedWaterTemperatureProperties");
        }
    }
}
