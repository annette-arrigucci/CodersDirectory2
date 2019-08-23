using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CodersDirectory.Data.Migrations
{
    public partial class update_26Oct18B : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Language_LanguageId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Profiles_ProfileId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_LanguageId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProfileId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageProfiles_ProfileId",
                table: "LanguageProfiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProfiles_ProfileId",
                table: "FavoriteProfiles",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProfiles_Profiles_ProfileId",
                table: "FavoriteProfiles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageProfiles_Profiles_ProfileId",
                table: "LanguageProfiles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProfiles_Profiles_ProfileId",
                table: "FavoriteProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageProfiles_Profiles_ProfileId",
                table: "LanguageProfiles");

            migrationBuilder.DropIndex(
                name: "IX_LanguageProfiles_ProfileId",
                table: "LanguageProfiles");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteProfiles_ProfileId",
                table: "FavoriteProfiles");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Profiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Language_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_LanguageId",
                table: "Profiles",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfileId",
                table: "Profiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Language_ProfileId",
                table: "Language",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Language_LanguageId",
                table: "Profiles",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Profiles_ProfileId",
                table: "Profiles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
