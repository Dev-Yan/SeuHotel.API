using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeuHotel.Infrastructure.Entities;
using Shared.Core.Classes;

namespace SeuHotel.Infrastructure.Mapping;

public class ReservationMapping : BaseModelMapping<Reservation>
{
    public override void Configure(EntityTypeBuilder<Reservation> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.CheckIn)
               .IsRequired();

        builder.Property(x => x.CheckOut)
               .IsRequired();

        builder.Property(x => x.NumberOfGuests)
               .HasDefaultValue(null);

        builder.HasOne(r => r.Person)
               .WithMany(p => p.Reservations)
               .HasForeignKey(r => r.PersonId)
               .IsRequired();

        builder.HasOne(r => r.Hotel)
               .WithMany(h => h.Reservations)
               .HasForeignKey(r => r.HotelId)
               .IsRequired();
    }
}
