using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class finalvfinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_SanctionTypes_SactionTypeId",
                table: "Sanctions");

            migrationBuilder.AlterColumn<int>(
                name: "SactionTypeId",
                table: "Sanctions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_SanctionTypes_SactionTypeId",
                table: "Sanctions",
                column: "SactionTypeId",
                principalTable: "SanctionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_SanctionTypes_SactionTypeId",
                table: "Sanctions");

            migrationBuilder.AlterColumn<int>(
                name: "SactionTypeId",
                table: "Sanctions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_SanctionTypes_SactionTypeId",
                table: "Sanctions",
                column: "SactionTypeId",
                principalTable: "SanctionTypes",
                principalColumn: "Id");
        }
    }
}
