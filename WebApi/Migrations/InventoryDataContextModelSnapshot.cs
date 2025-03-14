﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductInventory.Api.Data;

#nullable disable

namespace ProductInventory.Api.Migrations
{
    [DbContext(typeof(InventoryDataContext))]
    partial class InventoryDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("ProductInventory.Api.Data.Entities.InventoryTransactionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TransactionType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("inventory_transactions");
                });

            modelBuilder.Entity("ProductInventory.Api.Data.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("ProductInventory.Api.Data.Entities.InventoryTransactionEntity", b =>
                {
                    b.HasOne("ProductInventory.Api.Data.Entities.ProductEntity", "Product")
                        .WithMany("InventoryTransactions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductInventory.Api.Data.Entities.ProductEntity", b =>
                {
                    b.Navigation("InventoryTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
