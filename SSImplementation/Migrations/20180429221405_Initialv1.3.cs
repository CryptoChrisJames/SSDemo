using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSImplementation.Migrations
{
    public partial class Initialv13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "profileBookingID",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "studioBookedID",
                table: "Booking",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_profileBookingID",
                table: "Booking",
                column: "profileBookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_studioBookedID",
                table: "Booking",
                column: "studioBookedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Profiles_profileBookingID",
                table: "Booking",
                column: "profileBookingID",
                principalTable: "Profiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_StudioListings_studioBookedID",
                table: "Booking",
                column: "studioBookedID",
                principalTable: "StudioListings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Profiles_profileBookingID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_StudioListings_studioBookedID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_profileBookingID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_studioBookedID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "profileBookingID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "studioBookedID",
                table: "Booking");
        }
    }
}
