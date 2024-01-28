using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeuHotel.Infrastructure.Entities;
using Shared.Core.Classes;

namespace SeuHotel.Infrastructure.Mapping.Hotels;

public class HotelMapping : BaseModelMapping<Hotel>
{
    public override void Configure(EntityTypeBuilder<Hotel> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name)
                  .IsRequired()
                  .HasMaxLength(200);

        builder.Property(x => x.Description)
               .HasMaxLength(200);

        builder.Property(x => x.Address)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.Number)
               .HasMaxLength(20);

        builder.Property(x => x.City)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.PostalCode)
               .HasMaxLength(50);

        builder.Property(x => x.Country)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(x => x.Reviews)
                  .WithOne(r => r.Hotel)
                  .HasForeignKey(r => r.HotelId)
                  .IsRequired();

        builder.HasMany(x => x.Rooms)
               .WithOne(r => r.Hotel)
               .HasForeignKey(r => r.HotelId)
               .IsRequired();
    }
}