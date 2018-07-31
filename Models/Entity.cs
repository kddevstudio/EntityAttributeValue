using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Models
{
    public class Entity
    {
        public int EntityId { get; set; }

        public int EntityDefinitionId { get; set; }

        public EntityDefinition EntityDefinition { get; set; }

        public List<Value> Values { get; set; }

        public List<Value> LookupEntityValues { get; set; }
    }

    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.HasKey(e => e.EntityId);

            builder.Property(e => e.EntityId).ValueGeneratedOnAdd();

            builder.HasOne(e => e.EntityDefinition).WithMany().HasForeignKey(e => e.EntityDefinitionId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
