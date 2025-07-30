using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultipleLogin.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resume",
                table: "Employees",
                newName: "ResumeFileName");

            migrationBuilder.RenameColumn(
                name: "IDProof",
                table: "Employees",
                newName: "IDProofFileName");

            migrationBuilder.RenameColumn(
                name: "EducationalCertificate",
                table: "Employees",
                newName: "EducationalCertificateFileName");

            migrationBuilder.RenameColumn(
                name: "Avathar",
                table: "Employees",
                newName: "AvatarFileName");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateofBirth",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResumeFileName",
                table: "Employees",
                newName: "Resume");

            migrationBuilder.RenameColumn(
                name: "IDProofFileName",
                table: "Employees",
                newName: "IDProof");

            migrationBuilder.RenameColumn(
                name: "EducationalCertificateFileName",
                table: "Employees",
                newName: "EducationalCertificate");

            migrationBuilder.RenameColumn(
                name: "AvatarFileName",
                table: "Employees",
                newName: "Avathar");

            migrationBuilder.AlterColumn<int>(
                name: "PostalCode",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DateofBirth",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
