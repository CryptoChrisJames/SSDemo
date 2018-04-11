using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SSImplementation.Migrations
{
    public partial class InitialV12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountofTimeBooked = table.Column<int>(nullable: false),
                    BookingEndTime = table.Column<int>(nullable: false),
                    BookingStartTime = table.Column<int>(nullable: false),
                    ConfirmationNumber = table.Column<int>(nullable: false),
                    DateOfBooking = table.Column<DateTime>(nullable: false),
                    DateReservationWasMade = table.Column<DateTime>(nullable: false),
                    FinalCost = table.Column<int>(nullable: false),
                    ProfileMakingReservationID = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StudioBookedID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Booking_Profiles_ProfileMakingReservationID",
                        column: x => x.ProfileMakingReservationID,
                        principalTable: "Profiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_StudioListings_StudioBookedID",
                        column: x => x.StudioBookedID,
                        principalTable: "StudioListings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ProfileMakingReservationID",
                table: "Booking",
                column: "ProfileMakingReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_StudioBookedID",
                table: "Booking",
                column: "StudioBookedID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}
