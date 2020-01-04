using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Registration.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Countries_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false),
                    Password = table.Column<string>(maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 1, "Country 1", null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 2, "Country 2", null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 3, "Country 3", null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 4, "Province 1.1", 1 },
                    { 5, "Province 1.2", 1 },
                    { 6, "Province 2.1", 2 },
                    { 7, "Province 2.2", 2 },
                    { 8, "Province 3.1", 3 },
                    { 9, "Province 3.2", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ParentId",
                table: "Countries",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Login",
                table: "Customers",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProvinceId",
                table: "Customers",
                column: "ProvinceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
