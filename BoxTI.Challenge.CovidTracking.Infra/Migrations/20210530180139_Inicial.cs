using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoxTI.Challenge.CovidTracking.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Covid",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active_Cases_text = table.Column<int>(type: "int", nullable: true),
                    Country_text = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Last_Update = table.Column<DateTime>(type: "datetime2", nullable: true),
                    New_Cases_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    New_Deaths_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total_Cases_text = table.Column<int>(type: "int", nullable: true),
                    Total_Deaths_text = table.Column<int>(type: "int", nullable: true),
                    Total_Recovered_text = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covid", x => x.Id);
                    table.UniqueConstraint("AK_Covid_Country_text", x => x.Country_text);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Covid");
        }
    }
}
