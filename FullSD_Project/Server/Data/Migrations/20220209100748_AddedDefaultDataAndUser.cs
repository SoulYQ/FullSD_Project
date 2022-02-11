using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FullSD_Project.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "b9fdb28e-b703-4655-9910-3ee0177326bc", "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "2db0e687-fa0d-4ad6-9e03-17edd2adc065", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "bfcc9564-8524-41c5-8221-77158733a6a8", "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEJ5kELBljGm91vYalPpYp3Nu10fGaYuqUzlefCRYnPQtKyV1i7qavXK6VdHlSvCT9Q==", null, false, "472f9afd-a446-4777-9d8d-4f53456dd80a", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2021, 11, 9, 18, 7, 47, 584, DateTimeKind.Local).AddTicks(1937), new DateTime(2021, 11, 9, 18, 7, 47, 584, DateTimeKind.Local).AddTicks(1946), "Milwaukee", "System" },
                    { 2, "System", new DateTime(2021, 11, 9, 18, 7, 47, 584, DateTimeKind.Local).AddTicks(1949), new DateTime(2021, 11, 9, 18, 7, 47, 584, DateTimeKind.Local).AddTicks(1950), "RIDGID", "System" },
                    { 3, "System", new DateTime(2021, 11, 9, 18, 7, 47, 584, DateTimeKind.Local).AddTicks(1952), new DateTime(2021, 11, 9, 18, 7, 47, 584, DateTimeKind.Local).AddTicks(1954), "MAKITA", "System" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2021, 11, 9, 18, 7, 47, 582, DateTimeKind.Local).AddTicks(4125), new DateTime(2021, 11, 9, 18, 7, 47, 583, DateTimeKind.Local).AddTicks(959), "90% NEW", "System" },
                    { 2, "System", new DateTime(2021, 11, 9, 18, 7, 47, 583, DateTimeKind.Local).AddTicks(1620), new DateTime(2021, 11, 9, 18, 7, 47, 583, DateTimeKind.Local).AddTicks(1625), "NEW", "System" },
                    { 3, "System", new DateTime(2021, 11, 9, 18, 7, 47, 583, DateTimeKind.Local).AddTicks(1627), new DateTime(2021, 11, 9, 18, 7, 47, 583, DateTimeKind.Local).AddTicks(1628), "Small area scratches", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
