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

        public bool BoolValue { get; set; }

        public double NumberValue { get; set; }

        public int IntValue { get; set; }

    }

    public class ValuesConfiguration : IEntityTypeConfiguration<Value>
    {
        public ValuesConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Value> builder)
        {
            builder.HasKey(d => d.ValueId);

            builder.Property(d => d.ValueId).ValueGeneratedOnAdd();

            builder.HasOne(d => d.Attribute).WithMany().HasForeignKey(d => d.AttributeId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.EntityId).IsRequired();

            builder.HasOne(d => d.Entity).WithMany(o => o.Values).HasForeignKey(d => d.EntityId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
