using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingOfAchievements.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademArea",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AchievementType",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreaStage",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArtAchievement_AreaStage",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KindOfSport",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfCompet",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademArea",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "AchievementType",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "AreaStage",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "ArtAchievement_AreaStage",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "KindOfSport",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "NameOfCompet",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "Achievements");
        }
    }
}
