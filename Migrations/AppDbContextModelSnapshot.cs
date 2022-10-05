﻿// <auto-generated />
using System;
using EF_Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace New_folder__2_.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("EF_Core.Entites.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("NumberLine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EF_Core.Entites.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("NextOfKin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Wallet")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EF_Core.Entites.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AvailableTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("NumberOfPlates")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("EF_Core.Entites.FoodOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("OrderId");

                    b.ToTable("foodOrder");
                });

            modelBuilder.Entity("EF_Core.Entites.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EF_Core.Entites.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("NextOfKin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("EF_Core.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FoodOrder", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.HasKey("FoodId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("FoodOrder");
                });

            modelBuilder.Entity("EF_Core.Entites.Customer", b =>
                {
                    b.HasOne("EF_Core.Entites.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EF_Core.Entites.FoodOrder", b =>
                {
                    b.HasOne("EF_Core.Entites.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_Core.Entites.Order", "order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("order");
                });

            modelBuilder.Entity("EF_Core.Entites.Order", b =>
                {
                    b.HasOne("EF_Core.Entites.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EF_Core.Entites.Staff", b =>
                {
                    b.HasOne("EF_Core.Entites.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EF_Core.Entites.User", b =>
                {
                    b.HasOne("EF_Core.Entites.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("FoodOrder", b =>
                {
                    b.HasOne("EF_Core.Entites.Food", null)
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_Core.Entites.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EF_Core.Entites.Customer", b =>
                {
                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
