using iot.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iot.Data.Configurations
{
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Date)
               .IsRequired();
            builder.Property(i => i.ButtonState)
               .IsRequired();
            builder.Property(i => i.Led)
               .IsRequired();
            builder.Property(i => i.Tone)
               .IsRequired();
        }
    }
}
