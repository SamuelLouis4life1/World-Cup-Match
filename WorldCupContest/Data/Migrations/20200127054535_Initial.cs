using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldCupContest.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterTournaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentName = table.Column<string>(nullable: true),
                    TournamentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterTournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisterTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(nullable: true),
                    RegisteredTeamId = table.Column<int>(nullable: true),
                    MatchupId = table.Column<int>(nullable: true),
                    RegisterTournamentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterTeams_RegisterTournaments_RegisterTournamentId",
                        column: x => x.RegisterTournamentId,
                        principalTable: "RegisterTournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterTeams_RegisterTeams_RegisteredTeamId",
                        column: x => x.RegisteredTeamId,
                        principalTable: "RegisterTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matchups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamQuantity = table.Column<int>(nullable: false),
                    MatchupDate = table.Column<DateTime>(nullable: false),
                    RegisteredTeamId = table.Column<int>(nullable: true),
                    RegisteredTournamentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchups_RegisterTeams_RegisteredTeamId",
                        column: x => x.RegisteredTeamId,
                        principalTable: "RegisterTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchups_RegisterTournaments_RegisteredTournamentId",
                        column: x => x.RegisteredTournamentId,
                        principalTable: "RegisterTournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_RegisteredTeamId",
                table: "Matchups",
                column: "RegisteredTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_RegisteredTournamentId",
                table: "Matchups",
                column: "RegisteredTournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterTeams_MatchupId",
                table: "RegisterTeams",
                column: "MatchupId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterTeams_RegisterTournamentId",
                table: "RegisterTeams",
                column: "RegisterTournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterTeams_RegisteredTeamId",
                table: "RegisterTeams",
                column: "RegisteredTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterTeams_Matchups_MatchupId",
                table: "RegisterTeams",
                column: "MatchupId",
                principalTable: "Matchups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matchups_RegisterTeams_RegisteredTeamId",
                table: "Matchups");

            migrationBuilder.DropTable(
                name: "RegisterTeams");

            migrationBuilder.DropTable(
                name: "Matchups");

            migrationBuilder.DropTable(
                name: "RegisterTournaments");
        }
    }
}
