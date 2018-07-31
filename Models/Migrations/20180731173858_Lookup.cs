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

            migrationBuilder.InsertData(
                table: "EntityDefinitions",
                columns: new[] { "EntityDefinitionId", "Name" },
                values: new object[] { 3, "Weekdays" });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "AttributeId", "DataType", "EntityDefinitionId", "LookupEntityDefinitionId", "Name" },
                values: new object[] { 5, 1, 3, null, "Name" });

            migrationBuilder.InsertData(
                table: "Entities",
                columns: new[] { "EntityId", "EntityDefinitionId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 3 }
                });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "ValueId", "AttributeId", "BoolValue", "DateValue", "EntityId", "IntValue", "LookupEntityId", "NumberValue", "StringValue" },
                values: new object[,]
                {
                    { 1, 5, null, null, 1, null, null, null, "Monday" },
                    { 2, 5, null, null, 2, null, null, null, "Tuesday" },
                    { 3, 5, null, null, 3, null, null, null, "Wednesday" },
                    { 4, 5, null, null, 4, null, null, null, "Thursday" },
                    { 5, 5, null, null, 5, null, null, null, "Friday" },
                    { 6, 5, null, null, 6, null, null, null, "Saturday" },
                    { 7, 5, null, null, 7, null, null, null, "Sunday" }
                });

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

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EntityDefinitions",
                keyColumn: "EntityDefinitionId",
                keyValue: 3);

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
