using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeMangement.Data.Migrations
{
    public partial class Create_Entities_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCategory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TableFood",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableFood", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    idCategory = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Food_FoodCategory_idCategory",
                        column: x => x.idCategory,
                        principalTable: "FoodCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    DateCheckIn = table.Column<DateTime>(nullable: false),
                    DateCheckOut = table.Column<DateTime>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    discount = table.Column<int>(nullable: false),
                    totalPrice = table.Column<double>(nullable: false),
                    idTable = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bill_TableFood_idTable",
                        column: x => x.idTable,
                        principalTable: "TableFood",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillInfo",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    idBill = table.Column<Guid>(nullable: false),
                    idFood = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BillInfo_Bill_idBill",
                        column: x => x.idBill,
                        principalTable: "Bill",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillInfo_Food_idFood",
                        column: x => x.idFood,
                        principalTable: "Food",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_idTable",
                table: "Bill",
                column: "idTable");

            migrationBuilder.CreateIndex(
                name: "IX_BillInfo_idBill",
                table: "BillInfo",
                column: "idBill");

            migrationBuilder.CreateIndex(
                name: "IX_BillInfo_idFood",
                table: "BillInfo",
                column: "idFood");

            migrationBuilder.CreateIndex(
                name: "IX_Food_idCategory",
                table: "Food",
                column: "idCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillInfo");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "TableFood");

            migrationBuilder.DropTable(
                name: "FoodCategory");
        }
    }
}
