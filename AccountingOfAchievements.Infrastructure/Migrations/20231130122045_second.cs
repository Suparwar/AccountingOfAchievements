using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingOfAchievements.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Organizations_IssuedFromOrganizationID",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Portfolios_OwnerPortfolioId",
                table: "Achievements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_IssuedFromOrganizationID",
                table: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_OwnerPortfolioId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "IssuedFromOrganizationID",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "OwnerPortfolioId",
                table: "Achievements");

            migrationBuilder.RenameColumn(
                name: "PortfolioId",
                table: "Portfolios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OgrName",
                table: "Organizations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OrganizationID",
                table: "Organizations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AchievementId",
                table: "Achievements",
                newName: "PortfolioId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Achievements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IssuedFromId",
                table: "Achievements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_IssuedFromId",
                table: "Achievements",
                column: "IssuedFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_PortfolioId",
                table: "Achievements",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Organizations_IssuedFromId",
                table: "Achievements",
                column: "IssuedFromId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Portfolios_PortfolioId",
                table: "Achievements",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Organizations_IssuedFromId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Portfolios_PortfolioId",
                table: "Achievements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_IssuedFromId",
                table: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_PortfolioId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "IssuedFromId",
                table: "Achievements");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Portfolios",
                newName: "PortfolioId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Organizations",
                newName: "OgrName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Organizations",
                newName: "OrganizationID");

            migrationBuilder.RenameColumn(
                name: "PortfolioId",
                table: "Achievements",
                newName: "AchievementId");

            migrationBuilder.AddColumn<Guid>(
                name: "IssuedFromOrganizationID",
                table: "Achievements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerPortfolioId",
                table: "Achievements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_IssuedFromOrganizationID",
                table: "Achievements",
                column: "IssuedFromOrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_OwnerPortfolioId",
                table: "Achievements",
                column: "OwnerPortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Organizations_IssuedFromOrganizationID",
                table: "Achievements",
                column: "IssuedFromOrganizationID",
                principalTable: "Organizations",
                principalColumn: "OrganizationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Portfolios_OwnerPortfolioId",
                table: "Achievements",
                column: "OwnerPortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId");
        }
    }
}
