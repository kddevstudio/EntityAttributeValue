using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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

        public bool? BoolValue { get; set; }

        public double? NumberValue { get; set; }

        public int? IntValue { get; set; }

        public int? LookupEntityId { get; set; }

        public Entity LookupEntity { get; set; }

    }

    public class ValuesConfiguration : IEntityTypeConfiguration<Value>
    {
        public ValuesConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Value> builder)
        {
            builder.HasKey(v => v.ValueId);

            builder.Property(v => v.ValueId).ValueGeneratedOnAdd();

            builder.HasOne(v => v.Attribute).WithMany().HasForeignKey(v => v.AttributeId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(v => v.EntityId).IsRequired();

            builder.HasOne(v => v.Entity).WithMany(e=> e.Values).HasForeignKey(v => v.EntityId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.LookupEntity).WithMany(e => e.LookupEntityValues).HasForeignKey(v => v.LookupEntityId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
