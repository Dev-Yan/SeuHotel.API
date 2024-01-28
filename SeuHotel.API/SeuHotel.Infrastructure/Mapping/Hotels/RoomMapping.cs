using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeuHotel.Infrastructure.Entities;
using Shared.Core.Classes;

namespace SeuHotel.Infrastructure.Mapping.Hotels;

public class RoomMapping : BaseModelMapping<Room>
{
    public override void Configure(EntityTypeBuilder<Room> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.Description)
               .HasMaxLength(200);

        builder.Property(x => x.RoomSize)
               .HasMaxLength(50);

        builder.Property(x => x.MaxOccupancy)
               .IsRequired();

        builder.Property(x => x.Price)
               .IsRequired();

        builder.HasOne(r => r.Hotel)
               .WithMany(h => h.Rooms)
               .HasForeignKey(r => r.HotelId)
               .IsRequired();
    }
}