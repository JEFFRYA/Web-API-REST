﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_CRUD.Models;

#nullable disable

namespace WebAPICRUD.Migrations
{
    [DbContext(typeof(DbEmployeeContext))]
    partial class DbEmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI_CRUD.Models.TDepartment", b =>
                {
                    b.Property<long>("IdTDepartment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IdT_Department");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdTDepartment"));

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("IdTDepartment")
                        .HasName("PK__t_Depart__2BF3CB981AD7A50A");

                    b.ToTable("t_Department", (string)null);
                });

            modelBuilder.Entity("WebAPI_CRUD.Models.TEmployee", b =>
                {
                    b.Property<long>("IdTEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IdT_Employee");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdTEmployee"));

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<long?>("IdFDepartment")
                        .HasColumnType("bigint")
                        .HasColumnName("IdF_Department");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("IdTEmployee")
                        .HasName("PK__t_Employ__2F8770231AB94711");

                    b.ToTable("t_Employee", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
