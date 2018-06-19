using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Attribute
    {
        public int AttributeId { get; set; }

        [Required]
        [Display(Name = "Field Name")]
        public string Name { get; set; }

        [Required]
        [Range(1, 16)]
        public DataType DataType { get; set; }

        /// <summary>
        /// The EntityDefinitionId that corresponds to this items values
        /// </summary>
        public int? LookupEntityDefinitionId { get; set; }

        /// <summary>
        /// The EntityDefinition this Attribute belongs to
        /// </summary>
        public int EntityDefinitionId { get; set; }

        public EntityDefinition EntityDefinition { get; set; }
    }

    public class AttributeConfiguration : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
            builder.HasKey(t => t.AttributeId);

            builder.Property(g => g.AttributeId).ValueGeneratedOnAdd();
            builder.Property(g => g.Name).HasMaxLength(100);

            builder.HasIndex(t => new { t.EntityDefinitionId, t.Name }).IsUnique();

            builder.HasOne(o => o.EntityDefinition).WithMany(t => t.Attributes).HasForeignKey(f => f.EntityDefinitionId).OnDelete(DeleteBehavior.Restrict);
        }
    }

}
