﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Thermo.Data;

#nullable disable

namespace Thermo.Migrations
{
    [DbContext(typeof(ThermoContext))]
    [Migration("20240105125317_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Thermo.Entities.Saturated134APressureProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("EvapEnthalpy")
                        .HasColumnType("double precision");

                    b.Property<double>("EvapEntropy")
                        .HasColumnType("double precision");

                    b.Property<double>("EvapInternalEnergy")
                        .HasColumnType("double precision");

                    b.Property<double>("Pressure")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidEnthalpy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidEntropy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidInternalEnergy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidSpecificVolume")
                        .HasColumnType("double precision");

                    b.Property<double>("SatTemperature")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporEnthalpy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporEntropy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporInternalEnergy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporSpecificVolume")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Saturated134APressureProperties");
                });

            modelBuilder.Entity("Thermo.Entities.Saturated134ATemperatureProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("EvapEnthalpy")
                        .HasColumnType("double precision");

                    b.Property<double>("EvapEntropy")
                        .HasColumnType("double precision");

                    b.Property<double>("EvapInternalEnergy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidEnthalpy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidEntropy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidInternalEnergy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidSpecificVolume")
                        .HasColumnType("double precision");

                    b.Property<double>("SatPressure")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporEnthalpy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporEntropy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporInternalEnergy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporSpecificVolume")
                        .HasColumnType("double precision");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Saturated134ATemperatureProperties");
                });

            modelBuilder.Entity("Thermo.Entities.SaturatedWaterPressureProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("EvapEnthalpy")
                        .HasColumnType("double precision");

                    b.Property<double>("EvapEntropy")
                        .HasColumnType("double precision");

                    b.Property<double>("EvapInternalEnergy")
                        .HasColumnType("double precision");

                    b.Property<double>("Pressure")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidEnthalpy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidEntropy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidInternalEnergy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidSpecificVolume")
                        .HasColumnType("double precision");

                    b.Property<double>("SatTemperature")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporEnthalpy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporEntropy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporInternalEnergy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporSpecificVolume")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("SaturatedWaterPressureProperties");
                });

            modelBuilder.Entity("Thermo.Entities.SaturatedWaterTemperatureProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("EvapEnthalpy")
                        .HasColumnType("double precision");

                    b.Property<double>("EvapEntropy")
                        .HasColumnType("double precision");

                    b.Property<double>("EvapInternalEnergy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidEnthalpy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidEntropy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidInternalEnergy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatLiquidSpecificVolume")
                        .HasColumnType("double precision");

                    b.Property<double>("SatPressure")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporEnthalpy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporEntropy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporInternalEnergy")
                        .HasColumnType("double precision");

                    b.Property<double>("SatVaporSpecificVolume")
                        .HasColumnType("double precision");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("SaturatedWaterTemperatureProperties");
                });
#pragma warning restore 612, 618
        }
    }
}