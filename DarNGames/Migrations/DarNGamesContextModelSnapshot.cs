﻿// <auto-generated />
using System;
using DarNGames.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DarNGames.Migrations
{
    [DbContext(typeof(DarNGamesContext))]
    partial class DarNGamesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DarNGames.Models.CommonGameProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VendorSubcategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("VendorSubcategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VendorSubcategoriesId");

                    b.ToTable("CommonGameProperties");
                });

            modelBuilder.Entity("DarNGames.Models.GameVendors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GameVendors");
                });

            modelBuilder.Entity("DarNGames.Models.VendorSubcategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameVendorId")
                        .HasColumnType("int");

                    b.Property<int?>("GameVendorsId")
                        .HasColumnType("int");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameVendorsId");

                    b.ToTable("VendorSubcategories");
                });

            modelBuilder.Entity("DarNGames.Models.CommonGameProperties", b =>
                {
                    b.HasOne("DarNGames.Models.VendorSubcategories", null)
                        .WithMany("CommonGameProperties")
                        .HasForeignKey("VendorSubcategoriesId");
                });

            modelBuilder.Entity("DarNGames.Models.VendorSubcategories", b =>
                {
                    b.HasOne("DarNGames.Models.GameVendors", null)
                        .WithMany("VendorSubcategories")
                        .HasForeignKey("GameVendorsId");
                });
#pragma warning restore 612, 618
        }
    }
}