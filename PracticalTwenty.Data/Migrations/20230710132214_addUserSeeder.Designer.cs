﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticalTwenty.Data.Contexts;

#nullable disable

namespace PracticalTwenty.Data.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230710132214_addUserSeeder")]
    partial class addUserSeeder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PracticalTwenty.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "bhavin@gmail.com",
                            Firstname = "Bhavin",
                            LastName = "Kareliya",
                            Password = "123123"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jil@gmail.com",
                            Firstname = "Jil",
                            LastName = "Patel",
                            Password = "123123"
                        },
                        new
                        {
                            Id = 3,
                            Email = "vipul@gmail.com",
                            Firstname = "Vipul",
                            LastName = "Kumar",
                            Password = "123123"
                        },
                        new
                        {
                            Id = 4,
                            Email = "abhi@gmail.com",
                            Firstname = "Abhi",
                            LastName = "Dasadiya",
                            Password = "123123"
                        },
                        new
                        {
                            Id = 5,
                            Email = "jay@gmail.com",
                            Firstname = "Jay",
                            LastName = "Gohel",
                            Password = "123123"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
