using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimeTravelTourismAgency.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeDestinationsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TimeDestinations",
                columns: new[] { "Id", "Capacity", "CreatedAt", "DangerLevel", "Description", "IsActive", "Price", "TargetYear", "Title" },
                values: new object[,]
                {
                    { 1, 15, new DateTime(2026, 11, 15, 19, 46, 0, 470, DateTimeKind.Utc).AddTicks(4073), 3, "Kolezyum'daki gladyatör dövüşlerini canlı izleyin ve Roma Senatosu'na tanıklık edin.", true, 12500m, "MS 80", "Antik Roma" },
                    { 2, 10, new DateTime(2026, 11, 15, 19, 46, 0, 470, DateTimeKind.Utc).AddTicks(4080), 1, "Leonardo da Vinci ve Michelangelo'nun atölyelerini ziyaret edin, sanatın altın çağını yaşayın.", true, 18000m, "1504", "Rönesans Floransa" },
                    { 3, 8, new DateTime(2026, 11, 15, 19, 46, 0, 470, DateTimeKind.Utc).AddTicks(4081), 5, "Devasa dinozorların arasında, güvenli kuantum gözlem kubbemizden doğayı keşfedin.", true, 45000m, "MÖ 150 Milyon", "Jura Devri" },
                    { 4, 20, new DateTime(2026, 11, 15, 19, 46, 0, 470, DateTimeKind.Utc).AddTicks(4083), 4, "1453 yılında Fatih Sultan Mehmet'in akınlarına ve tarihi gemilerin karadan yürütülmesine tanık olun.", true, 15000m, "1453", "İstanbul'un Fethi" },
                    { 5, 12, new DateTime(2026, 11, 15, 19, 46, 0, 470, DateTimeKind.Utc).AddTicks(4084), 2, "Sisli Londra sokaklarında at arabalarıyla gezinin ve Sherlock Holmes atmosferini soluyun.", true, 9500m, "1888", "Viktorya Dönemi Londra" },
                    { 6, 6, new DateTime(2026, 11, 15, 19, 46, 0, 470, DateTimeKind.Utc).AddTicks(4086), 2, "Apollo 11'in fırlatılışını Kennedy Uzay Merkezi'nden en önde izleyin.", true, 35000m, "1969", "Ay'a İlk Ayak Basılış" },
                    { 7, 14, new DateTime(2026, 11, 15, 19, 46, 0, 470, DateTimeKind.Utc).AddTicks(4087), 2, "İlk Olimpiyat oyunlarının düzenlendiği Olympos'ta tarihin sportmenlik ruhunu hissedin.", true, 11000m, "MÖ 776", "Antik Yunan - Antik Olaylar" },
                    { 8, 10, new DateTime(2026, 11, 15, 19, 46, 0, 470, DateTimeKind.Utc).AddTicks(4088), 4, "Teksas kasabalarında dönemin atmosferini yaşayın, tüccarlar ve şeriflerle tanışın.", true, 13500m, "1875", "Vahşi Batı" },
                    { 9, 25, new DateTime(2026, 11, 15, 19, 46, 0, 470, DateTimeKind.Utc).AddTicks(4089), 1, "Yüzyıllar sonrasının uçan arabaları ve holografik gökdelenleriyle dolu metropolünü keşfedin.", true, 50000m, "3024", "Kuantum Gelecek - Neo İstanbul" },
                    { 10, 12, new DateTime(2026, 11, 15, 19, 46, 0, 470, DateTimeKind.Utc).AddTicks(4090), 3, "Babil'in Asma Bahçeleri'nin ihtişamını görün ve insanlık tarihinin ilk yazılı kanunlarına tanıklık edin.", true, 16000m, "MÖ 1750", "Mezopotamya - Babil" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimeDestinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeDestinations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeDestinations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TimeDestinations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TimeDestinations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TimeDestinations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TimeDestinations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TimeDestinations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TimeDestinations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TimeDestinations",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
