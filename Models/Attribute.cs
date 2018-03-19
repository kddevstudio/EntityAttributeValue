using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Models
{
    public class Attribute
    {
        public int AttributeId { get; set; }

        public string Name { get; set; }

        [Required]
        [Range(1, 16)]
        public DataType DataType { get; set; }

        public int EntityDefinitionId { get; set; }

        public EntityDefinition EntityDefinition { get; set; }
    }

    public class AttributeConfiguration : EntityTypeConfiguration<Attribute>
    {
        public AttributeConfiguration()
        {
            HasKey(t => t.AttributeId);

            Property(g => g.AttributeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(g => g.Name).HasMaxLength(100);

            HasIndex(t => new { t.EntityDefinitionId, t.Name }).IsUnique();
            
            HasRequired(o => o.EntityDefinition).WithMany(t => t.Attributes).HasForeignKey(f => f.EntityDefinitionId).WillCascadeOnDelete(false);
        }
    }

}
