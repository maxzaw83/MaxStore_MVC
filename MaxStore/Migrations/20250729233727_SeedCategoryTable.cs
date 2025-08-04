using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaxStore.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, "မုန့်ဟင်းခါး၊ အုန်းနို့ခေါက်ဆွဲ၊ ရခိုင်မုန့်တီ နဲ့ အသုပ်အမျိုးမျိုး", 1, "မုန့်ဟင်းခါး၊ အုန်းနို့ခေါက်ဆွဲ၊ ရခိုင်မုန့်တီ နဲ့ အသုပ်အမျိုးမျိုး" },
                    { 2, "ရှမ်းအစားအသောက်များ", 2, "ရှမ်းအစားအသောက်များ" },
                    { 3, "ကော်ဖီ၊ လက်ဖက်ရည် နဲ့ လက်ဖက်ခြောက်", 3, "ကော်ဖီ၊ လက်ဖက်ရည် နဲ့ လက်ဖက်ခြောက်" },
                    { 4, "အသင့်စားစည်သွပ်ဘူးများ", 4, "အသင့်စားစည်သွပ်ဘူးများ" },
                    { 5, "အရံဟင်းလျာများ", 5, "အရံဟင်းလျာများ" },
                    { 6, "လက်ဖက် နဲ့ အကြော်စုံ", 6, "လက်ဖက် နဲ့ အကြော်စုံ" },
                    { 7, "ငါးပိ၊ ငါးခြောက် နဲ့ ပုဇွန်ခြောက်", 7, "ငါးပိ၊ ငါးခြောက် နဲ့ ပုဇွန်ခြောက်" },
                    { 8, "Medicine", 8, "Medicine" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
