using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EntityDefinitions",
                columns: new[] { "EntityDefinitionId", "Name" },
                values: new object[] { 1, "Gadget" });

            migrationBuilder.InsertData(
                table: "EntityDefinitions",
                columns: new[] { "EntityDefinitionId", "Name" },
                values: new object[] { 2, "Widget" });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "AttributeId", "DataType", "EntityDefinitionId", "LookupEntityDefinitionId", "Name" },
                values: new object[,]
                {
                    { 1, 2, 1, null, "GadgetField1" },
                    { 2, 8, 1, null, "GadgetField2" },
                    { 3, 16, 2, null, "WidgetField1" },
                    { 4, 4, 2, null, "WidgetField2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EntityDefinitions",
                keyColumn: "EntityDefinitionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EntityDefinitions",
                keyColumn: "EntityDefinitionId",
                keyValue: 2);
        }
    }
}
