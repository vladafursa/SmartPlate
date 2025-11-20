using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPlate.Models;
using SmartPlate.Models.Enums;

/*
namespace SmartPlate.Data.Configurations
{
    public class PlateConfiguration : IEntityTypeConfiguration<Plate>
    {
        public void Configure(EntityTypeBuilder<Plate> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.RegistrationNumber)
                  .IsUnique();

            builder.HasOne<User>()
                  .WithMany()
                  .HasForeignKey(p => p.CurrentOwnerId)
                  .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.OwnershipHistory)
                  .WithOne()
                  .HasForeignKey(r => r.PlateId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.BidHistory)
                  .WithOne()
                  .HasForeignKey(b => b.PlateId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Categories)
                  .HasConversion(
                      v => string.Join(",", v),
                      v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(c => Enum.Parse<PlateCategory>(c))
                            .ToList()
                  );
        }
    }
}
*/