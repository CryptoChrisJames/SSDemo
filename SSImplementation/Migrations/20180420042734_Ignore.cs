using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSImplementation.Migrations
{
    public partial class Ignore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConfirmationNumber",
                table: "Booking",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ConfirmationNumber",
                table: "Booking",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
