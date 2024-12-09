﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PearlySoft.Migrations
{
    /// <inheritdoc />
    public partial class AddingNotesColumnToEmployeesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Employees");
        }
    }
}
