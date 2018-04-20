using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSImplementation.Migrations
{
    public partial class Ignore1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Profiles_ProfileMakingReservationID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_StudioListings_StudioBookedID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ProfileMakingReservationID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_StudioBookedID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "ProfileMakingReservationID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "StudioBookedID",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "DateOfBooking",
                table: "Booking",
                newName: "ReservationDate");

            migrationBuilder.AddColumn<string>(
                name: "BookingUserID",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudioUserID",
                table: "Booking",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Booking_BookingID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BookingID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BookingUserID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "StudioUserID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "Booking",
                newName: "DateOfBooking");

            migrationBuilder.AddColumn<int>(
                name: "ProfileMakingReservationID",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudioBookedID",
                table: "Booking",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ProfileMakingReservationID",
                table: "Booking",
                column: "ProfileMakingReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_StudioBookedID",
                table: "Booking",
                column: "StudioBookedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Profiles_ProfileMakingReservationID",
                table: "Booking",
                column: "ProfileMakingReservationID",
                principalTable: "Profiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_StudioListings_StudioBookedID",
                table: "Booking",
                column: "StudioBookedID",
                principalTable: "StudioListings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
