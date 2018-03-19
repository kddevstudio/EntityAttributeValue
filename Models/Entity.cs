using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Entity
    {
        public int EntityId { get; set; }

        public int EntityDefinitionId { get; set; }

        public EntityDefinition EntityDefinition { get; set; }

        public List<Value> Values { get; set; }

        public List<EntityRelationship> EntityRelationships { get; set; }
    }

    public class EntityConfiguration : EntityTypeConfiguration<Entity>
    {
        public EntityConfiguration()
        {
            HasKey(o => o.EntityId);

            Property(o => o.EntityId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(o => o.EntityDefinition).WithMany().HasForeignKey(o => o.EntityDefinitionId).WillCascadeOnDelete(false);
        }
    }

}
