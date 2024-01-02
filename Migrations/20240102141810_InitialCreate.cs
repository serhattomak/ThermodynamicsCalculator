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
                name: "ThermodynamicTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableName = table.Column<string>(type: "text", nullable: false),
                    ThermodynamicPropertyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThermodynamicTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThermodynamicProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropertyName = table.Column<string>(type: "text", nullable: false),
                    ThermodynamicTableId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThermodynamicProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThermodynamicProperties_ThermodynamicTables_ThermodynamicTa~",
                        column: x => x.ThermodynamicTableId,
                        principalTable: "ThermodynamicTables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ThermodynamicValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<double>(type: "double precision", nullable: true),
                    ThermodynamicPropertyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThermodynamicValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThermodynamicValues_ThermodynamicProperties_ThermodynamicPr~",
                        column: x => x.ThermodynamicPropertyId,
                        principalTable: "ThermodynamicProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThermodynamicProperties_ThermodynamicTableId",
                table: "ThermodynamicProperties",
                column: "ThermodynamicTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ThermodynamicValues_ThermodynamicPropertyId",
                table: "ThermodynamicValues",
                column: "ThermodynamicPropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThermodynamicValues");

            migrationBuilder.DropTable(
                name: "ThermodynamicProperties");

            migrationBuilder.DropTable(
                name: "ThermodynamicTables");
        }
    }
}
