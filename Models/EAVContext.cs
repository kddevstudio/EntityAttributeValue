using Microsoft.EntityFrameworkCore;
using System;

namespace Models
{
    public class EAVContext: DbContext
    {
        public EAVContext(DbContextOptions dbContextOptions): base(dbContextOptions) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AttributeConfiguration());
            modelBuilder.ApplyConfiguration(new EntityDefinitionConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfiguration());
            modelBuilder.ApplyConfiguration(new ValuesConfiguration());

            var gadgetEntityDefinition = new EntityDefinition() { EntityDefinitionId = 1, Name = "Gadget" };
            var widgetEntityDefinition = new EntityDefinition() { EntityDefinitionId = 2, Name = "Widget" };
            var weekdayEntityDefinition = new EntityDefinition() { EntityDefinitionId = 3, Name = "Weekdays" };

            modelBuilder.Entity<EntityDefinition>().HasData(
                gadgetEntityDefinition,
                widgetEntityDefinition,
                weekdayEntityDefinition
                );

            modelBuilder.Entity<Attribute>().HasData(
                new Attribute() { AttributeId = 1, EntityDefinitionId = 1, Name = "GadgetField1", DataType = DataType.Number },
                new Attribute() { AttributeId = 2, EntityDefinitionId = 1, Name = "GadgetField2", DataType = DataType.DateTime },
                new Attribute() { AttributeId = 3, EntityDefinitionId = 2, Name = "WidgetField1", DataType = DataType.Boolean },
                new Attribute() { AttributeId = 4, EntityDefinitionId = 2, Name = "WidgetField2", DataType = DataType.Integer },
                new Attribute() { AttributeId = 5, EntityDefinitionId = 3, Name = "Name", DataType = DataType.String },
                new Attribute()
                {
                    AttributeId = 6,
                    EntityDefinitionId = 1,
                    Name = "Gadget Weekday",
                    DataType = DataType.LookupId,
                    LookupEntityDefinitionId = 3
                },
                new Attribute()
                {
                    AttributeId = 7,
                    EntityDefinitionId = 2,
                    Name = "Widget Weekday",
                    DataType = DataType.LookupId,
                    LookupEntityDefinitionId = 3
                }
            );

            var mondayEntity = new Entity() { EntityId = 1, EntityDefinitionId = 3};
            var tuesdayEntity = new Entity() { EntityId = 2, EntityDefinitionId = 3 };
            var wednesdayEntity = new Entity() { EntityId = 3, EntityDefinitionId = 3 };
            var thursdayEntity = new Entity() { EntityId = 4, EntityDefinitionId = 3 };
            var fridayEntity = new Entity() { EntityId = 5, EntityDefinitionId = 3 };
            var saturdayEntity = new Entity() { EntityId = 6, EntityDefinitionId = 3 };
            var sundayEntity = new Entity() { EntityId = 7, EntityDefinitionId = 3 };

            var mondayNameValue = new Value() { ValueId = 1, EntityId = 1, AttributeId = 5, StringValue = "Monday" };
            var tuesdayNameValue = new Value() { ValueId = 2, EntityId = 2, AttributeId = 5, StringValue = "Tuesday" };
            var wednesdayNameValue = new Value() { ValueId = 3, EntityId = 3, AttributeId = 5, StringValue = "Wednesday" };
            var thursdayNameValue = new Value() { ValueId = 4, EntityId = 4, AttributeId = 5, StringValue = "Thursday" };
            var fridayNameValue = new Value() { ValueId = 5, EntityId = 5, AttributeId = 5, StringValue = "Friday" };
            var saturdayNameValue = new Value() { ValueId = 6, EntityId = 6, AttributeId = 5, StringValue = "Saturday" };
            var sundayNameValue = new Value() { ValueId = 7, EntityId = 7, AttributeId = 5, StringValue = "Sunday" };
            
            modelBuilder.Entity<Entity>().HasData(
                mondayEntity,
                tuesdayEntity,
                wednesdayEntity,
                thursdayEntity,
                fridayEntity,
                saturdayEntity,
                sundayEntity
                );

            modelBuilder.Entity<Value>().HasData(
                mondayNameValue,
                tuesdayNameValue,
                wednesdayNameValue,
                thursdayNameValue,
                fridayNameValue,
                saturdayNameValue,
                sundayNameValue
                );

            // add gadgets
            modelBuilder.Entity<Entity>().HasData(
                new Entity() { EntityId = 8, EntityDefinitionId = 1 },
                new Entity() { EntityId = 9, EntityDefinitionId = 1 },
                new Entity() { EntityId = 10, EntityDefinitionId = 1 },
                new Entity() { EntityId = 11, EntityDefinitionId = 1 }
                );

            modelBuilder.Entity<Value>().HasData(
                new Value() { ValueId = 8, EntityId = 8, AttributeId = 1, NumberValue = 10d},
                new Value() { ValueId = 9, EntityId = 8, AttributeId = 2, DateValue = new DateTime() },
                new Value() { ValueId = 10, EntityId = 8, AttributeId = 6, LookupEntityId = 1 },
                new Value() { ValueId = 11, EntityId = 9, AttributeId = 1, NumberValue = 20d },
                new Value() { ValueId = 12, EntityId = 9, AttributeId = 2, DateValue = new DateTime().AddDays(7) },
                new Value() { ValueId = 13, EntityId = 9, AttributeId = 6, LookupEntityId = 3 },
                new Value() { ValueId = 14, EntityId = 10, AttributeId = 1, NumberValue = 30d },
                new Value() { ValueId = 15, EntityId = 10, AttributeId = 2, DateValue = new DateTime().AddDays(14) },
                new Value() { ValueId = 16, EntityId = 10, AttributeId = 6, LookupEntityId = 5 },
                new Value() { ValueId = 17, EntityId = 11, AttributeId = 1, NumberValue = 40d },
                new Value() { ValueId = 18, EntityId = 11, AttributeId = 2, DateValue = new DateTime().AddDays(21) },
                new Value() { ValueId = 19, EntityId = 11, AttributeId = 6, LookupEntityId = 7 }
                );
            
            // add widgets
            modelBuilder.Entity<Entity>().HasData(
                new Entity() { EntityId = 12, EntityDefinitionId = 2 },
                new Entity() { EntityId = 13, EntityDefinitionId = 2 },
                new Entity() { EntityId = 14, EntityDefinitionId = 2 }
                );

            modelBuilder.Entity<Value>().HasData(
                new Value() { ValueId = 20, EntityId = 12, AttributeId = 3, BoolValue = true },
                new Value() { ValueId = 21, EntityId = 12, AttributeId = 4, IntValue = 10 },
                new Value() { ValueId = 22, EntityId = 12, AttributeId = 7, LookupEntityId = 2 },
                new Value() { ValueId = 23, EntityId = 13, AttributeId = 3, BoolValue = false },
                new Value() { ValueId = 24, EntityId = 13, AttributeId = 4, IntValue = 20 },
                new Value() { ValueId = 25, EntityId = 13, AttributeId = 7, LookupEntityId = 4 },
                new Value() { ValueId = 26, EntityId = 14, AttributeId = 3, BoolValue = true },
                new Value() { ValueId = 27, EntityId = 14, AttributeId = 4, IntValue = 30 },
                new Value() { ValueId = 28, EntityId = 14, AttributeId = 7, LookupEntityId = 6 }
                );            
        }                     
                              
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<EntityDefinition> EntityDefinitions { get; set; }
    }
}
