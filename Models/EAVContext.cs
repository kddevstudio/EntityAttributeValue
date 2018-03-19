using System.Data.Entity;

namespace Models
{
    public class EAVContext: DbContext
    {
        public EAVContext() : this("name=EAVContext")
        {
        }

        public EAVContext(string nameOrConnectionString): base(nameOrConnectionString) {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AttributeConfiguration());
            modelBuilder.Configurations.Add(new EntityDefinitionConfiguration());
            modelBuilder.Configurations.Add(new EntityConfiguration());
            modelBuilder.Configurations.Add(new ValuesConfiguration());
            modelBuilder.Configurations.Add(new EntityRelationshipConfiguration());
        }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<EntityDefinition> EntityDefinitions { get; set; }
        public DbSet<EntityRelationship> EntityRelationships { get; set; }
    }
}
