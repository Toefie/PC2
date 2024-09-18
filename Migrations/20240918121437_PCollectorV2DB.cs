using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PcollectorV2.Migrations
{
    /// <inheritdoc />
    public partial class PCollectorV2DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    CollectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.CollectionID);
                    table.ForeignKey(
                        name: "FK_Collections_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    CurrentPrice = table.Column<double>(type: "float", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cards_Collections_CollectionID",
                        column: x => x.CollectionID,
                        principalTable: "Collections",
                        principalColumn: "CollectionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "CollectionID", "CollectionName", "InventoryID" },
                values: new object[] { 1, "Holo", 0 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "ID", "BuyDate", "BuyPrice", "CollectionID", "CollectionName", "Condition", "CurrentPrice", "Description", "Name", "Specialty" },
                values: new object[] { 1, new DateTime(2024, 9, 18, 14, 14, 36, 537, DateTimeKind.Local).AddTicks(928), 13.0, 1, "expensive", "Mint Condition", 23.0, "Met verpakking", "Test", "PSA 8" });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CollectionID",
                table: "Cards",
                column: "CollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_InventoryID",
                table: "Collections",
                column: "InventoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
