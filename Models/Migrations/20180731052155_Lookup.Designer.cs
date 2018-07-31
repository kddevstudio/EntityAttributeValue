﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Models.Migrations
{
    [DbContext(typeof(EAVContext))]
    [Migration("20180731052155_Lookup")]
    partial class Lookup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Attribute", b =>
                {
                    b.Property<int>("AttributeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DataType");

                    b.Property<int>("EntityDefinitionId");

                    b.Property<int?>("LookupEntityDefinitionId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("AttributeId");

                    b.HasIndex("EntityDefinitionId", "Name")
                        .IsUnique();

                    b.ToTable("Attributes");

                    b.HasData(
                        new { AttributeId = 1, DataType = 2, EntityDefinitionId = 1, Name = "GadgetField1" },
                        new { AttributeId = 2, DataType = 8, EntityDefinitionId = 1, Name = "GadgetField2" },
                        new { AttributeId = 3, DataType = 16, EntityDefinitionId = 2, Name = "WidgetField1" },
                        new { AttributeId = 4, DataType = 4, EntityDefinitionId = 2, Name = "WidgetField2" }
                    );
                });

            modelBuilder.Entity("Models.Entity", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EntityDefinitionId");

                    b.HasKey("EntityId");

                    b.HasIndex("EntityDefinitionId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("Models.EntityDefinition", b =>
                {
                    b.Property<int>("EntityDefinitionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("EntityDefinitionId");

                    b.ToTable("EntityDefinitions");

                    b.HasData(
                        new { EntityDefinitionId = 1, Name = "Gadget" },
                        new { EntityDefinitionId = 2, Name = "Widget" }
                    );
                });

            modelBuilder.Entity("Models.Value", b =>
                {
                    b.Property<int>("ValueId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeId");

                    b.Property<bool?>("BoolValue");

                    b.Property<DateTime?>("DateValue");

                    b.Property<int>("EntityId");

                    b.Property<int?>("IntValue");

                    b.Property<int?>("LookupEntityId");

                    b.Property<double?>("NumberValue");

                    b.Property<string>("StringValue");

                    b.HasKey("ValueId");

                    b.HasIndex("AttributeId");

                    b.HasIndex("EntityId");

                    b.HasIndex("LookupEntityId");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("Models.Attribute", b =>
                {
                    b.HasOne("Models.EntityDefinition", "EntityDefinition")
                        .WithMany("Attributes")
                        .HasForeignKey("EntityDefinitionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.Entity", b =>
                {
                    b.HasOne("Models.EntityDefinition", "EntityDefinition")
                        .WithMany()
                        .HasForeignKey("EntityDefinitionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.Value", b =>
                {
                    b.HasOne("Models.Attribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Entity", "Entity")
                        .WithMany("Values")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Entity", "LookupEntity")
                        .WithMany("LookupEntityValues")
                        .HasForeignKey("LookupEntityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
