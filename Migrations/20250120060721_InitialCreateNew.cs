using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_TenantId1",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TenantId1",
                table: "Bookings",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TenantId1",
                table: "Bookings",
                newName: "IX_Bookings_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_ApplicationUserId",
                table: "Bookings",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_ApplicationUserId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Bookings",
                newName: "TenantId1");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ApplicationUserId",
                table: "Bookings",
                newName: "IX_Bookings_TenantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_TenantId1",
                table: "Bookings",
                column: "TenantId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
