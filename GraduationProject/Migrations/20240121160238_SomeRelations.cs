using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class SomeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MedicineIsAvailable = table.Column<bool>(type: "bit", maxLength: 5, nullable: false),
                    MedicineExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineId);
                });

            migrationBuilder.CreateTable(
                name: "relatives",
                columns: table => new
                {
                    RelativeSsn = table.Column<int>(type: "int", maxLength: 14, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelativeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RelativePhone = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    DegreeOfKinShip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminSsn = table.Column<string>(type: "nvarchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relatives", x => x.RelativeSsn);
                    table.ForeignKey(
                        name: "FK_relatives_hospital_Admins_AdminSsn",
                        column: x => x.AdminSsn,
                        principalTable: "hospital_Admins",
                        principalColumn: "AdminSsn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineRelative",
                columns: table => new
                {
                    MedicinesMedicineId = table.Column<int>(type: "int", nullable: false),
                    RelativeSsn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineRelative", x => new { x.MedicinesMedicineId, x.RelativeSsn });
                    table.ForeignKey(
                        name: "FK_MedicineRelative_Medicines_MedicinesMedicineId",
                        column: x => x.MedicinesMedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineRelative_relatives_RelativeSsn",
                        column: x => x.RelativeSsn,
                        principalTable: "relatives",
                        principalColumn: "RelativeSsn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelativeMedicine",
                columns: table => new
                {
                    RelativeSsn = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelativeMedicine", x => new { x.RelativeSsn, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_RelativeMedicine_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelativeMedicine_relatives_RelativeSsn",
                        column: x => x.RelativeSsn,
                        principalTable: "relatives",
                        principalColumn: "RelativeSsn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineRelative_RelativeSsn",
                table: "MedicineRelative",
                column: "RelativeSsn");

            migrationBuilder.CreateIndex(
                name: "IX_RelativeMedicine_MedicineId",
                table: "RelativeMedicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_relatives_AdminSsn",
                table: "relatives",
                column: "AdminSsn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineRelative");

            migrationBuilder.DropTable(
                name: "RelativeMedicine");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "relatives");
        }
    }
}
