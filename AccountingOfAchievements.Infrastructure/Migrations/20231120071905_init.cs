using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingOfAchievements.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OgrName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationID);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    PortfolioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.PortfolioId);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    AchievementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerPortfolioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateOfReceiving = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedFromOrganizationID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.AchievementId);
                    table.ForeignKey(
                        name: "FK_Achievements_Organizations_IssuedFromOrganizationID",
                        column: x => x.IssuedFromOrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationID");
                    table.ForeignKey(
                        name: "FK_Achievements_Portfolios_OwnerPortfolioId",
                        column: x => x.OwnerPortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "PortfolioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_IssuedFromOrganizationID",
                table: "Achievements",
                column: "IssuedFromOrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_OwnerPortfolioId",
                table: "Achievements",
                column: "OwnerPortfolioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Portfolios");
        }
    }
}
