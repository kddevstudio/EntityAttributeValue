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
    }

    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.HasKey(o => o.EntityId);

            builder.Property(o => o.EntityId).ValueGeneratedOnAdd();

            builder.HasOne(o => o.EntityDefinition).WithMany().HasForeignKey(o => o.EntityDefinitionId).OnDelete(DeleteBehavior.Restrict);
        }
    }

}
