﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImportExcel.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dob",
                table: "StudentList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "dob",
                table: "StudentList",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}