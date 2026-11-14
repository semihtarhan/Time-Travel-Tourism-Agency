using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimeTravelTourismAgency.Migrations
{
    /// <inheritdoc />
    public partial class SeedFirstCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "PassportNumber", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 14, 12, 0, 0, 0, DateTimeKind.Utc), "ayse.kaya@gelecek.com", "Ayşe", "Kaya", "TR123456789", "Password123*", "+905321112233" },
                    { 2, new DateTime(2026, 11, 14, 12, 0, 0, 0, DateTimeKind.Utc), "kaan.demir@paradoks.com", "Kaan", "Demir", "TR987654321", "Time456*", "+905332223344" },
                    { 3, new DateTime(2026, 11, 14, 12, 0, 0, 0, DateTimeKind.Utc), "zeynep.celik@zamanagaci.com", "Zeynep", "Çelik", "TR555666777", "Chrono789!", "+905553334455" },
                    { 4, new DateTime(2026, 11, 14, 12, 0, 0, 0, DateTimeKind.Utc), "can.ozkan@gecmis.net", "Can", "Özkan", "TR111222333", "Kuantum2026!", "+905444445566" },
                    { 5, new DateTime(2026, 11, 14, 12, 0, 0, 0, DateTimeKind.Utc), "elif.yildiz@sonsuzluk.com", "Elif", "Yıldız", "TR999888777", "Infinity99*", "+905305556677" },
                    { 6, new DateTime(2026, 11, 14, 12, 0, 0, 0, DateTimeKind.Utc), "burak.yilmaz@gmail.com", "Burak", "Yılmaz", "TR555111222", "BurakPassword1*", "+905321234567" },
                    { 7, new DateTime(2026, 11, 14, 12, 0, 0, 0, DateTimeKind.Utc), "ceren.aydin@hotmail.com", "Ceren", "Aydın", "TR777888999", "CerenTime2026!", "+905339876543" },
                    { 8, new DateTime(2026, 11, 14, 12, 0, 0, 0, DateTimeKind.Utc), "tolga.sahin@yahoo.com", "Tolga", "Şahin", "TR112233445", "TolgaQuantum9^", "+905441112233" },
                    { 9, new DateTime(2026, 11, 14, 12, 0, 0, 0, DateTimeKind.Utc), "melis.koc@outlook.com", "Melis", "Koç", "TR998877665", "MelisFuture5!", "+905556667788" },
                    { 10, new DateTime(2026, 11, 14, 12, 0, 0, 0, DateTimeKind.Utc), "ozan.tekin@icloud.com", "Ozan", "Tekin", "TR334455667", "OzanHistory7*", "+905309998877" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
