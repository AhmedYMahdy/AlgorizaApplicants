using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgorizaApplicants.DAL.Migrations
{
    public partial class AddDatesToApplicantsTableV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Applicants",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 12, 13, 1, 19, 2, DateTimeKind.Utc).AddTicks(8659));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Applicants",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 12, 13, 1, 19, 2, DateTimeKind.Utc).AddTicks(8531));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 12, 13, 1, 19, 2, DateTimeKind.Utc).AddTicks(8659),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 12, 13, 1, 19, 2, DateTimeKind.Utc).AddTicks(8531),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
