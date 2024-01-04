﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Thermo.Data;

#nullable disable

namespace Thermo.Migrations
{
    [DbContext(typeof(ThermoContext))]
    partial class ThermoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Thermo.Entities.ThermodynamicProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ThermodynamicTableId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ThermodynamicTableId");

                    b.ToTable("ThermodynamicProperties");
                });

            modelBuilder.Entity("Thermo.Entities.ThermodynamicTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ThermodynamicTables");
                });

            modelBuilder.Entity("Thermo.Entities.ThermodynamicValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ThermodynamicPropertyId")
                        .HasColumnType("integer");

                    b.Property<double?>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ThermodynamicPropertyId");

                    b.ToTable("ThermodynamicValues");
                });

            modelBuilder.Entity("Thermo.Entities.ThermodynamicProperty", b =>
                {
                    b.HasOne("Thermo.Entities.ThermodynamicTable", null)
                        .WithMany("ThermodynamicProperties")
                        .HasForeignKey("ThermodynamicTableId");
                });

            modelBuilder.Entity("Thermo.Entities.ThermodynamicValue", b =>
                {
                    b.HasOne("Thermo.Entities.ThermodynamicProperty", "ThermodynamicProperty")
                        .WithMany("ThermodynamicValues")
                        .HasForeignKey("ThermodynamicPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThermodynamicProperty");
                });

            modelBuilder.Entity("Thermo.Entities.ThermodynamicProperty", b =>
                {
                    b.Navigation("ThermodynamicValues");
                });

            modelBuilder.Entity("Thermo.Entities.ThermodynamicTable", b =>
                {
                    b.Navigation("ThermodynamicProperties");
                });
#pragma warning restore 612, 618
        }
    }
}
