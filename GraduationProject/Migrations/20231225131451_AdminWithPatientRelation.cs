using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class AdminWithPatientRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hospital_Admins",
                columns: table => new
                {
                    AdminSsn = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    AdminName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AdminStreet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminZipCode = table.Column<int>(type: "int", nullable: false),
                    AdminPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    AdminBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_Admins", x => x.AdminSsn);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    PatientSsn = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatientCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PatientStreet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatientZipCode = table.Column<int>(type: "int", nullable: false),
                    PatientPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PatientBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MangedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminSsn = table.Column<string>(type: "nvarchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.PatientSsn);
                    table.ForeignKey(
                        name: "FK_patients_hospital_Admins_AdminSsn",
                        column: x => x.AdminSsn,
                        principalTable: "hospital_Admins",
                        principalColumn: "AdminSsn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_patients_AdminSsn",
                table: "patients",
                column: "AdminSsn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "hospital_Admins");
        }
    }
}
