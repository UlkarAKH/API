using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductStockApi.Data.Migrations
{
    public partial class initialcreateStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductStocks",
                columns: table => new
                {
                    Productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStocks", x => x.Productid);
                });

            migrationBuilder.InsertData(
                table: "ProductStocks",
                columns: new[] { "Productid", "Stock" },
                values: new object[] { 1, 100 });

            migrationBuilder.InsertData(
                table: "ProductStocks",
                columns: new[] { "Productid", "Stock" },
                values: new object[] { 2, 200 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStocks");
        }
    }
}
