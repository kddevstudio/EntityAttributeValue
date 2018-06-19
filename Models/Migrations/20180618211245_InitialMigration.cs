using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityDefinitions",
                columns: table => new
                {
                    EntityDefinitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityDefinitions", x => x.EntityDefinitionId);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    AttributeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DataType = table.Column<int>(nullable: false),
                    LookupEntityDefinitionId = table.Column<int>(nullable: true),
                    EntityDefinitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK_Attributes_EntityDefinitions_EntityDefinitionId",
                        column: x => x.EntityDefinitionId,
                        principalTable: "EntityDefinitions",
                        principalColumn: "EntityDefinitionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityDefinitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Entities_EntityDefinitions_EntityDefinitionId",
                        column: x => x.EntityDefinitionId,
                        principalTable: "EntityDefinitions",
                        principalColumn: "EntityDefinitionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    ValueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<int>(nullable: false),
                    AttributeId = table.Column<int>(nullable: false),
                    StringValue = table.Column<string>(nullable: true),
                    DateValue = table.Column<DateTime>(nullable: true),
                    BoolValue = table.Column<bool>(nullable: false),
                    NumberValue = table.Column<double>(nullable: false),
                    IntValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.ValueId);
                    table.ForeignKey(
                        name: "FK_Values_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "AttributeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Values_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_EntityDefinitionId_Name",
                table: "Attributes",
                columns: new[] { "EntityDefinitionId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entities_EntityDefinitionId",
                table: "Entities",
                column: "EntityDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Values_AttributeId",
                table: "Values",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Values_EntityId",
                table: "Values",
                column: "EntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "EntityDefinitions");
        }
    }
}
