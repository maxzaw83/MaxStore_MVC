using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaxStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryTableProductTableandSeedCategoryTableandProductTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ListPrice = table.Column<double>(type: "double", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "မုန့်ဟင်းခါး၊ အုန်းနို့ခေါက်ဆွဲ၊ ရခိုင်မုန့်တီ နဲ့ အသုပ်အမျိုးမျိုး" },
                    { 2, 2, "ရှမ်းအစားအသောက်များ" },
                    { 3, 3, "ကော်ဖီ၊ လက်ဖက်ရည် နဲ့ လက်ဖက်ခြောက်" },
                    { 4, 4, "အသင့်စားစည်သွပ်ဘူးများ" },
                    { 5, 5, "အရံဟင်းလျာများ" },
                    { 6, 6, "လက်ဖက် နဲ့ အကြော်စုံ" },
                    { 7, 7, "ငါးပိ၊ ငါးခြောက် နဲ့ ပုဇွန်ခြောက်" },
                    { 8, 8, "Medicine" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ListPrice", "Title" },
                values: new object[,]
                {
                    { 1, 1, "a Description", 4.0, "Product a" },
                    { 2, 2, "b Description", 5.0, "Product b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
