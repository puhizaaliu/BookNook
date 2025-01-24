using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeVillaIdName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Villas_VillaID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "VillaID",
                table: "Bookings",
                newName: "VillaId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_VillaID",
                table: "Bookings",
                newName: "IX_Bookings_VillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Villas_VillaId",
                table: "Bookings",
                column: "VillaId",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Villas_VillaId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "VillaId",
                table: "Bookings",
                newName: "VillaID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_VillaId",
                table: "Bookings",
                newName: "IX_Bookings_VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Villas_VillaID",
                table: "Bookings",
                column: "VillaID",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
