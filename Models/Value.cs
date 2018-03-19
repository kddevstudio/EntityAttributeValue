using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Value
    {
        public int ValueId { get; set; }

        public int EntityId { get; set; }

        public Entity Entity { get; set; }

        public int AttributeId { get; set; }

        public Attribute Attribute { get; set; }

        public string StringValue { get; set; }

        public DateTime? DateValue { get; set; }

        public bool BoolValue { get; set; }

        public double NumberValue { get; set; }

        public int IntValue { get; set; }

    }

    public class ValuesConfiguration : EntityTypeConfiguration<Value>
    {
        public ValuesConfiguration()
        {
            HasKey(d => d.ValueId);

            Property(d => d.ValueId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(d => d.Attribute).WithMany().HasForeignKey(d => d.AttributeId).WillCascadeOnDelete(false);

            Property(d => d.EntityId).IsRequired();

            HasRequired(d => d.Entity).WithMany(o => o.Values).HasForeignKey(d => d.EntityId).WillCascadeOnDelete(false);
        }
    }
}
