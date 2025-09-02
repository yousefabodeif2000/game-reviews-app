using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace game_reviews_app.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "2b3ada38-6de7-4498-b536-66004e661b13", "Yousef", "test@example.com", true, false, null, "TESTUSER@EXAMPLE.COM", "TESTUSER", null, null, false, "3a62deff-a374-42da-bc92-d85dc5507805", false, "testuser" });
        }
    }
}
