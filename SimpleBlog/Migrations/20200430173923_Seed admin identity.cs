using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBlog.Migrations
{
    public partial class Seedadminidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d4b5e35-3885-4bdc-b0b3-31ed2539c767", "5b3baa59-6705-40f7-ac1b-137a414ed2af", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5d4b5e35-3885-4bdc-b0b3-31ed2539c767", 0, "a1aff880-5407-4f13-87f1-084a655920b1", "some-admin-email@nonce.fake", true, false, null, "some-admin-email@nonce.fake", "admin", "AQAAAAEAACcQAAAAELvsImBpE2EdXiv4vSitqU1AwgyUV1qNrhws2GpEwKl48IYfdMjUELmWm/kWbkwBIQ==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "5d4b5e35-3885-4bdc-b0b3-31ed2539c767", "5d4b5e35-3885-4bdc-b0b3-31ed2539c767" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5d4b5e35-3885-4bdc-b0b3-31ed2539c767", "5d4b5e35-3885-4bdc-b0b3-31ed2539c767" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d4b5e35-3885-4bdc-b0b3-31ed2539c767");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d4b5e35-3885-4bdc-b0b3-31ed2539c767");
        }
    }
}
