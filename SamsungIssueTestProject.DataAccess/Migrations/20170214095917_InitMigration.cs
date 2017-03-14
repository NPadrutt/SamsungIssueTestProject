using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamsungIssueTestProject.DataAccess.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsEstablished = table.Column<bool>(nullable: false),
                    UserFromNumber = table.Column<string>(nullable: true),
                    UserToNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdService = table.Column<long>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdAddressbook = table.Column<long>(nullable: false),
                    IdService = table.Column<long>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    IsAllowedToReceiveMyInfos = table.Column<bool>(nullable: false),
                    IsMe = table.Column<bool>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Prename = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactAddresss",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(nullable: true),
                    ContactId = table.Column<long>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    IdAddressbook = table.Column<long>(nullable: false),
                    IdService = table.Column<long>(nullable: false),
                    InfoType = table.Column<int>(nullable: false),
                    Postcode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactAddresss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactAddresss_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactEvents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContactId = table.Column<long>(nullable: false),
                    IdAddressbook = table.Column<long>(nullable: false),
                    IdService = table.Column<long>(nullable: false),
                    InfoType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Periodicity = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactEvents_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContactId = table.Column<long>(nullable: false),
                    IdAddressbook = table.Column<long>(nullable: false),
                    IdService = table.Column<long>(nullable: false),
                    Info = table.Column<string>(nullable: true),
                    InfoType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddresss_ContactId",
                table: "ContactAddresss",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactEvents_ContactId",
                table: "ContactEvents",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_ContactId",
                table: "ContactInfos",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactAddresss");

            migrationBuilder.DropTable(
                name: "ContactEvents");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
