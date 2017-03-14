using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsAppDate.DataAccess.Migrations
{
    public partial class Migration_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasUnsavedChanges",
                table: "ContactInfos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasUnsavedChanges",
                table: "ContactEvents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasUnsavedChanges",
                table: "ContactAddresss",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasUnsavedChanges",
                table: "Contacts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasUnsavedChanges",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "HasUnsavedChanges",
                table: "ContactEvents");

            migrationBuilder.DropColumn(
                name: "HasUnsavedChanges",
                table: "ContactAddresss");

            migrationBuilder.DropColumn(
                name: "HasUnsavedChanges",
                table: "Contacts");
        }
    }
}
