using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSImplementation.Migrations
{
    public partial class RemoveBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Booking_BookingID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BookingID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BookingID",
                table: "AspNetUsers",
                column: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Booking_BookingID",
                table: "AspNetUsers",
                column: "BookingID",
                principalTable: "Booking",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
