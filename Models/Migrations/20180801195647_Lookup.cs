using System;
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
                table: "Attributes",
                columns: new[] { "AttributeId", "DataType", "EntityDefinitionId", "LookupEntityDefinitionId", "Name" },
                values: new object[,]
                {
                    { 6, 32, 1, 3, "Gadget Weekday" },
                    { 7, 32, 2, 3, "Widget Weekday" }
                });

            migrationBuilder.InsertData(
                table: "Entities",
                columns: new[] { "EntityId", "EntityDefinitionId" },
                values: new object[,]
                {
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 2 },
                    { 13, 2 },
                    { 14, 2 }
                });

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
                    { 7, 3 },
                    { 5, 3 },
                    { 4, 3 },
                    { 3, 3 },
                    { 2, 3 },
                    { 1, 3 },
                    { 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "ValueId", "AttributeId", "BoolValue", "DateValue", "EntityId", "IntValue", "LookupEntityId", "NumberValue", "StringValue" },
                values: new object[,]
                {
                    { 27, 4, null, null, 14, 30, null, null, null },
                    { 26, 3, true, null, 14, null, null, null, null },
                    { 24, 4, null, null, 13, 20, null, null, null },
                    { 23, 3, false, null, 13, null, null, null, null },
                    { 20, 3, true, null, 12, null, null, null, null },
                    { 18, 2, null, new DateTime(1, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, null, null, null, null },
                    { 17, 1, null, null, 11, null, null, 40.0, null },
                    { 15, 2, null, new DateTime(1, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, null, null, null, null },
                    { 14, 1, null, null, 10, null, null, 30.0, null },
                    { 12, 2, null, new DateTime(1, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, null, null, null },
                    { 11, 1, null, null, 9, null, null, 20.0, null },
                    { 9, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, null, null, null, null },
                    { 21, 4, null, null, 12, 10, null, null, null },
                    { 8, 1, null, null, 8, null, null, 10.0, null }
                });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "ValueId", "AttributeId", "BoolValue", "DateValue", "EntityId", "IntValue", "LookupEntityId", "NumberValue", "StringValue" },
                values: new object[,]
                {
                    { 1, 5, null, null, 1, null, null, null, "Monday" },
                    { 10, 6, null, null, 8, null, 1, null, null },
                    { 2, 5, null, null, 2, null, null, null, "Tuesday" },
                    { 22, 7, null, null, 12, null, 2, null, null },
                    { 3, 5, null, null, 3, null, null, null, "Wednesday" },
                    { 13, 6, null, null, 9, null, 3, null, null },
                    { 4, 5, null, null, 4, null, null, null, "Thursday" },
                    { 25, 7, null, null, 13, null, 4, null, null },
                    { 5, 5, null, null, 5, null, null, null, "Friday" },
                    { 16, 6, null, null, 10, null, 5, null, null },
                    { 6, 5, null, null, 6, null, null, null, "Saturday" },
                    { 28, 7, null, null, 14, null, 6, null, null },
                    { 7, 5, null, null, 7, null, null, null, "Sunday" },
                    { 19, 6, null, null, 11, null, 7, null, null }
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
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ValueId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeId",
                keyValue: 7);

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
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: 14);

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
