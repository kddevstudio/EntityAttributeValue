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
            builder.HasKey(a => a.AttributeId);

            builder.Property(a => a.AttributeId).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasMaxLength(100);

            builder.HasIndex(a => new { a.EntityDefinitionId, a.Name }).IsUnique();

            builder.HasOne(a => a.EntityDefinition).WithMany(ed => ed.Attributes).HasForeignKey(a => a.EntityDefinitionId).OnDelete(DeleteBehavior.Restrict);
        }
    }

}
