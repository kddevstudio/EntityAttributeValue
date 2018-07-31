using Microsoft.EntityFrameworkCore;

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
                new Attribute() { AttributeId = 5, EntityDefinitionId = 3, Name = "Name", DataType = DataType.String }
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
        }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<EntityDefinition> EntityDefinitions { get; set; }
    }
}
