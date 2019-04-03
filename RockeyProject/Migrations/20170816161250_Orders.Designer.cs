﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RockeyProject.Models;
using System;

namespace RockeyProject.Migrations
{
	[DbContext(typeof(ApplicationDbContext))]
	[Migration("20170816161250_Orders")]
	partial class Orders
	{
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			modelBuilder.Entity("RockeyProject.Models.CartLine", b =>
				{
					b.Property<int>("CartLineID")
						.ValueGeneratedOnAdd();

					b.Property<int?>("OrderID");

					b.Property<int?>("ProductID");

					b.Property<int>("Quantity");

					b.HasKey("CartLineID");

					b.HasIndex("OrderID");

					b.HasIndex("ProductID");

					b.ToTable("CartLine");
				});

			modelBuilder.Entity("RockeyProject.Models.Order", b =>
				{
					b.Property<int>("OrderID")
						.ValueGeneratedOnAdd();

					b.Property<string>("City")
						.IsRequired();

					b.Property<string>("Country")
						.IsRequired();

					b.Property<bool>("GiftWrap");

					b.Property<string>("Line1")
						.IsRequired();

					b.Property<string>("Line2");

					b.Property<string>("Line3");

					b.Property<string>("Name")
						.IsRequired();

					b.Property<string>("State")
						.IsRequired();

					b.Property<string>("Zip");

					b.HasKey("OrderID");

					b.ToTable("Orders");
				});

			modelBuilder.Entity("RockeyProject.Models.Product", b =>
				{
					b.Property<int>("ProductID")
						.ValueGeneratedOnAdd();

					b.Property<string>("Category");

					b.Property<string>("Description");

					b.Property<string>("Name");

					b.Property<decimal>("Price");

					b.HasKey("ProductID");

					b.ToTable("Products");
				});

			modelBuilder.Entity("RockeyProject.Models.CartLine", b =>
				{
					b.HasOne("RockeyProject.Models.Order")
						.WithMany("Lines")
						.HasForeignKey("OrderID");

					b.HasOne("RockeyProject.Models.Product", "Product")
						.WithMany()
						.HasForeignKey("ProductID");
				});
#pragma warning restore 612, 618
		}
	}
}
