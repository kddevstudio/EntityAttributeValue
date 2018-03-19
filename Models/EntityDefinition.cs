using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class EntityDefinitionConfiguration : EntityTypeConfiguration<EntityDefinition>
    {
        public EntityDefinitionConfiguration()
        {
            HasKey(t => t.EntityDefinitionId);
            Property(g => g.EntityDefinitionId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
