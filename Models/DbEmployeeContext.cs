using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_CRUD.Models;

public partial class DbEmployeeContext : DbContext
{
    public DbEmployeeContext()
    {
    }

    public DbEmployeeContext(DbContextOptions<DbEmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TDepartment> TDepartments { get; set; }

    public virtual DbSet<TEmployee> TEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=DB_Employee; Trusted_Connection=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TDepartment>(entity =>
        {
            entity.HasKey(e => e.IdTDepartment).HasName("PK__t_Depart__2BF3CB981AD7A50A");

            entity.ToTable("t_Department");

            entity.Property(e => e.IdTDepartment).HasColumnName("IdT_Department");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TEmployee>(entity =>
        {
            entity.HasKey(e => e.IdTEmployee).HasName("PK__t_Employ__2F8770231AB94711");

            entity.ToTable("t_Employee");

            entity.Property(e => e.IdTEmployee).HasColumnName("IdT_Employee");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdFDepartment).HasColumnName("IdF_Department");
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
