﻿// <auto-generated />
using System;
using MCF_AppData.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MCF_AppData.Migrations.SecondDbMigrations
{
    [DbContext(typeof(SecondDbContext))]
    [Migration("20230208043542_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MCF_AppData.Tables.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Location_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("MCF_AppData.Tables.Tr_Bpkb", b =>
                {
                    b.Property<string>("AgreementNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Bpkb_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Bpkb_Date_In")
                        .HasColumnType("datetime2");

                    b.Property<string>("Bpkb_No")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Faktur_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Faktur_No")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Police_No")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("AgreementNumber");

                    b.HasIndex("LocationId");

                    b.ToTable("TR_BPKB");
                });

            modelBuilder.Entity("MCF_AppData.Tables.Tr_Bpkb", b =>
                {
                    b.HasOne("MCF_AppData.Tables.Location", "Location")
                        .WithMany("Tr_Bpkb")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("MCF_AppData.Tables.Location", b =>
                {
                    b.Navigation("Tr_Bpkb");
                });
#pragma warning restore 612, 618
        }
    }
}
