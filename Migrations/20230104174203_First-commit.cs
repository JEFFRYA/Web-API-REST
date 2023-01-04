using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICRUD.Migrations
{
    /// <inheritdoc />
    public partial class Firstcommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_Department",
                columns: table => new
                {
                    IdTDepartment = table.Column<long>(name: "IdT_Department", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_Depart__2BF3CB981AD7A50A", x => x.IdTDepartment);
                });

            migrationBuilder.CreateTable(
                name: "t_Employee",
                columns: table => new
                {
                    IdTEmployee = table.Column<long>(name: "IdT_Employee", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FullName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdFDepartment = table.Column<long>(name: "IdF_Department", type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_Employ__2F8770231AB94711", x => x.IdTEmployee);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_Department");

            migrationBuilder.DropTable(
                name: "t_Employee");
        }
    }
}
