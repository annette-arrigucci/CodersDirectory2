using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CodersDirectory.Data.Migrations
{
    public partial class Update_26Oct18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Language_Profile_ProfileId",
                table: "Language");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Profile_ProfileId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                table: "Profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "Profiles");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_UserId",
                table: "Profiles",
                newName: "IX_Profiles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_ProfileId",
                table: "Profiles",
                newName: "IX_Profiles_ProfileId");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FavoriteProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FavoriteId = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageId = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageProfiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_LanguageId",
                table: "Profiles",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Language_Profiles_ProfileId",
                table: "Language",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Language_Profiles_ProfileId",
                table: "Language");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Language_LanguageId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Profiles_ProfileId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "FavoriteProfiles");

            migrationBuilder.DropTable(
                name: "LanguageProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_LanguageId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "Profile");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_UserId",
                table: "Profile",
                newName: "IX_Profile_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_ProfileId",
                table: "Profile",
                newName: "IX_Profile_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Language_Profile_ProfileId",
                table: "Language",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Profile_ProfileId",
                table: "Profile",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_AspNetUsers_UserId",
                table: "Profile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
