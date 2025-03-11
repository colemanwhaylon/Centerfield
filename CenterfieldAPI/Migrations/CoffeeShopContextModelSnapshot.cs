﻿// <auto-generated />
using System;
using CenterfieldAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CenterfieldAPI.Migrations
{
    [DbContext(typeof(CoffeeShopContext))]
    partial class CoffeeShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("CenterfieldAPI.Entities.CoffeeShop", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("ClosingTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("OpeningTime")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rating")
                        .HasPrecision(3, 2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CoffeeShops");
                });
#pragma warning restore 612, 618
        }
    }
}
