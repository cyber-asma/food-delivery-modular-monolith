﻿// <auto-generated />
using System;
using FoodDelivery.Modules.Orders.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoodDelivery.Modules.Orders.Shared.Data.Migrations.Order
{
    [DbContext(typeof(OrdersDbContext))]
    [Migration("20240719181407_InitialOrdersMigration")]
    partial class InitialOrdersMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FoodDelivery.Modules.Orders.Orders.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("created_by");

                    b.Property<long>("OriginalVersion")
                        .IsConcurrencyToken()
                        .HasColumnType("bigint")
                        .HasColumnName("original_version");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_orders_id");

                    b.ToTable("orders", "order");
                });

            modelBuilder.Entity("FoodDelivery.Modules.Orders.Orders.Models.Order", b =>
                {
                    b.OwnsOne("FoodDelivery.Modules.Orders.Orders.ValueObjects.CustomerInfo", "Customer", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint")
                                .HasColumnName("id");

                            b1.Property<long>("CustomerId")
                                .HasColumnType("bigint")
                                .HasColumnName("customer_customer_id");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("customer_name");

                            b1.HasKey("OrderId");

                            b1.ToTable("orders", "order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId")
                                .HasConstraintName("fk_orders_orders_id");
                        });

                    b.OwnsOne("FoodDelivery.Modules.Orders.Orders.ValueObjects.ProductInfo", "Product", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint")
                                .HasColumnName("id");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("product_name");

                            b1.Property<decimal>("Price")
                                .HasColumnType("numeric")
                                .HasColumnName("product_price");

                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint")
                                .HasColumnName("product_product_id");

                            b1.HasKey("OrderId");

                            b1.ToTable("orders", "order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId")
                                .HasConstraintName("fk_orders_orders_id");
                        });

                    b.Navigation("Customer")
                        .IsRequired();

                    b.Navigation("Product")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
