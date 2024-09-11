﻿// <auto-generated />
using System;
using EFCoreRelationshipsDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreRelationshipsDemo.Migrations
{
    [DbContext(typeof(SampleDbContext))]
    [Migration("20240901125611_AddInvoiceItemTable")]
    partial class AddInvoiceItemTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCoreRelationshipsDemo.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Amount");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("ContactName");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Description");

                    b.Property<DateTimeOffset>("DueDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("DueDate");

                    b.Property<DateTimeOffset>("InvoiceDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("InvoiceDate");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasColumnName("InvoiceNumber");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceNumber")
                        .IsUnique();

                    b.ToTable("Invoices", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("236f8acd-5dc2-4ea7-9428-fc9eaefd3116"),
                            Amount = 100m,
                            ContactName = "Iron Man",
                            Description = "Invoice for the first month",
                            DueDate = new DateTimeOffset(new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            InvoiceDate = new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            InvoiceNumber = "INV-001",
                            Status = "AwaitPayment"
                        },
                        new
                        {
                            Id = new Guid("2b3cba71-a9c2-42ca-87e2-6af26664ed9f"),
                            Amount = 200m,
                            ContactName = "Captain America",
                            Description = "Invoice for the first month",
                            DueDate = new DateTimeOffset(new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            InvoiceDate = new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            InvoiceNumber = "INV-002",
                            Status = "AwaitPayment"
                        });
                });

            modelBuilder.Entity("EFCoreRelationshipsDemo.Models.InvoiceItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Amount");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Description");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("InvoiceId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Name");

                    b.Property<decimal>("Quantity")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceItems", (string)null);
                });

            modelBuilder.Entity("EFCoreRelationshipsDemo.Models.InvoiceItem", b =>
                {
                    b.HasOne("EFCoreRelationshipsDemo.Models.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("EFCoreRelationshipsDemo.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceItems");
                });
#pragma warning restore 612, 618
        }
    }
}
