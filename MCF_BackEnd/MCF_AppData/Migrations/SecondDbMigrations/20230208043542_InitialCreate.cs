using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCF_AppData.Migrations.SecondDbMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TR_BPKB",
                columns: table => new
                {
                    AgreementNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bpkb_No = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bpkb_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Faktur_No = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Faktur_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Police_No = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Bpkb_Date_In = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TR_BPKB", x => x.AgreementNumber);
                    table.ForeignKey(
                        name: "FK_TR_BPKB_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TR_BPKB_LocationId",
                table: "TR_BPKB",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TR_BPKB");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
