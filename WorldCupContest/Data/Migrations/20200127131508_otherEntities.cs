using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldCupContest.Data.Migrations
{
    public partial class otherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AwayHomeGame",
                table: "RegisterTournaments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "RegisterTeams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstTeamName",
                table: "Matchups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondTimeName",
                table: "Matchups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayHomeGame",
                table: "RegisterTournaments");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "RegisterTeams");

            migrationBuilder.DropColumn(
                name: "FirstTeamName",
                table: "Matchups");

            migrationBuilder.DropColumn(
                name: "SecondTimeName",
                table: "Matchups");
        }
    }
}
