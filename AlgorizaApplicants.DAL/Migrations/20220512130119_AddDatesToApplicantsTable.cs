using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgorizaApplicants.DAL.Migrations
{
    public partial class AddDatesToApplicantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 12, 13, 1, 19, 2, DateTimeKind.Utc).AddTicks(8531));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 12, 13, 1, 19, 2, DateTimeKind.Utc).AddTicks(8659));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Applicants");
        }
    }
}
