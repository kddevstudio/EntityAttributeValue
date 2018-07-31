using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class Lookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "NumberValue",
                table: "Values",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "IntValue",
                table: "Values",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "BoolValue",
                table: "Values",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "LookupEntityId",
                table: "Values",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Values_LookupEntityId",
                table: "Values",
                column: "LookupEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Values_Entities_LookupEntityId",
                table: "Values",
                column: "LookupEntityId",
                principalTable: "Entities",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Values_Entities_LookupEntityId",
                table: "Values");

            migrationBuilder.DropIndex(
                name: "IX_Values_LookupEntityId",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "LookupEntityId",
                table: "Values");

            migrationBuilder.AlterColumn<double>(
                name: "NumberValue",
                table: "Values",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IntValue",
                table: "Values",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "BoolValue",
                table: "Values",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
