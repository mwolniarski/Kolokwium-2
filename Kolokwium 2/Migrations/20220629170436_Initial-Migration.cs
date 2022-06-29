using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium_2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrganizationDomain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MemberNickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => new { x.FileId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_Files_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "MemberShips",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    MembershipDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShips", x => new { x.MemberId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_MemberShips_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                    table.ForeignKey(
                        name: "FK_MemberShips_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationId", "OrganizationDomain", "OrganizationName" },
                values: new object[] { 1, "Budowlana", "Organizacja 1" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationId", "OrganizationDomain", "OrganizationName" },
                values: new object[] { 2, "Spożywcza", "Organizacja 2" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "MemberName", "MemberNickName", "MemberSurname", "OrganizationId" },
                values: new object[,]
                {
                    { 1, "Grzegorz", "grzeKa", "Kantor", 1 },
                    { 2, "Michał", "MichSu", "Suwak", 2 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "OrganizationId", "TeamDescription", "TeamName" },
                values: new object[,]
                {
                    { 2, 1, "Description 2", "Team 2" },
                    { 1, 2, "Description 1", "Team 1" }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "FileId", "TeamId", "FileExtension", "FileName", "FileSize" },
                values: new object[,]
                {
                    { 2, 2, "wav", "Test2", 30 },
                    { 1, 1, "txt", "Test1", 20 }
                });

            migrationBuilder.InsertData(
                table: "MemberShips",
                columns: new[] { "MemberId", "TeamId", "MembershipDate" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2011, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, new DateTime(2013, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_TeamId",
                table: "Files",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_OrganizationId",
                table: "Members",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberShips_TeamId",
                table: "MemberShips",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_OrganizationId",
                table: "Teams",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "MemberShips");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
