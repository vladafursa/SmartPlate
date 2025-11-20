using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPlate.Models;

namespace SmartPlate.Data.Configurations
{
    public class PlateOwnershipRecordConfiguration : IEntityTypeConfiguration<PlateOwnershipRecord>
    {
        public void Configure(EntityTypeBuilder<PlateOwnershipRecord> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasIndex(r => new { r.PlateId, r.OwnerId, r.Start })
                   .IsUnique();

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(r => r.OwnerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}