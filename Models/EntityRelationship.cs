using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EntityRelationship
    {
        public int EntityRelationshipId { get; set; }

        public Entity Parent { get; set; }
        public int ParentId { get; set; }

        public Entity Child { get; set; }
        public int ChildId { get; set; }
        public int EntityDefinitionRelationshipId { get; set; }
    }

    public class EntityRelationshipConfiguration : EntityTypeConfiguration<EntityRelationship>
    {
        public EntityRelationshipConfiguration()
        {
            HasKey(d => d.EntityRelationshipId);

            Property(d => d.EntityRelationshipId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(d => d.Parent).WithMany().HasForeignKey(d => d.ParentId).WillCascadeOnDelete(false);

            Property(d => d.ParentId).IsRequired();

            HasRequired(d => d.Child).WithMany().HasForeignKey(d => d.ChildId).WillCascadeOnDelete(false);

            Property(d => d.ChildId).IsRequired();
        }
    }
}
