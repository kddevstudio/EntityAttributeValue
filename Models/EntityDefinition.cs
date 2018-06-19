using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class EntityDefinition
    {
        public int EntityDefinitionId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IList<Attribute> Attributes { get; set; }

        public virtual IList<EntityDefinition> EntityDefinitionParents { get; set; }

        public virtual IList<EntityDefinition> EntityDefinitionChildren { get; set; }
    }

    public class EntityDefinitionConfiguration : IEntityTypeConfiguration<EntityDefinition>
    {
        public void Configure(EntityTypeBuilder<EntityDefinition> builder)
        {
            builder.HasKey(t => t.EntityDefinitionId);
            builder.Property(g => g.EntityDefinitionId).ValueGeneratedOnAdd();
        }
    }
}
