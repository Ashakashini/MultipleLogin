using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultipleLogin.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddFilePathColumnsToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarFileName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EducationalCertificateFileName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IDProofFileName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ResumeFileName",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Avatarpath",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationalCertificatepath",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDProofpath",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resumepath",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatarpath",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EducationalCertificatepath",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IDProofpath",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Resumepath",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "AvatarFileName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EducationalCertificateFileName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IDProofFileName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResumeFileName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
