using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sactions_SactionTypes_SactionTypeId",
                table: "Sactions");

            migrationBuilder.AlterColumn<int>(
                name: "SactionTypeId",
                table: "Sactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sactions_SactionTypes_SactionTypeId",
                table: "Sactions",
                column: "SactionTypeId",
                principalTable: "SactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sactions_SactionTypes_SactionTypeId",
                table: "Sactions");

            migrationBuilder.AlterColumn<int>(
                name: "SactionTypeId",
                table: "Sactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sactions_SactionTypes_SactionTypeId",
                table: "Sactions",
                column: "SactionTypeId",
                principalTable: "SactionTypes",
                principalColumn: "Id");
        }
    }
}
