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

            modelBuilder.Entity<EntityDefinition>().HasData(
                new EntityDefinition() { EntityDefinitionId = 1, Name = "Gadget" },
                new EntityDefinition() { EntityDefinitionId = 2, Name = "Widget" }
                );

            modelBuilder.Entity<Attribute>().HasData(
                new Attribute() { AttributeId = 1, EntityDefinitionId = 1, Name = "GadgetField1", DataType = DataType.Number },
                new Attribute() { AttributeId = 2, EntityDefinitionId = 1, Name = "GadgetField2", DataType = DataType.DateTime },
                new Attribute() { AttributeId = 3, EntityDefinitionId = 2, Name = "WidgetField1", DataType = DataType.Boolean },
                new Attribute() { AttributeId = 4, EntityDefinitionId = 2, Name = "WidgetField2", DataType = DataType.Integer }
            );
        }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<EntityDefinition> EntityDefinitions { get; set; }
    }
}
