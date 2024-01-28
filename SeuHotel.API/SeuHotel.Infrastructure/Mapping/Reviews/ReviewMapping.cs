using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeuHotel.Infrastructure.Entities;
using Shared.Core.Classes;

namespace SeuHotel.Infrastructure.Mapping.Reviews;

public class ReviewMapping : BaseModelMapping<Review>
{
    public override void Configure(EntityTypeBuilder<Review> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Rating)
                  .IsRequired();

        builder.Property(x => x.Comment)
               .HasMaxLength(500);

        builder.HasOne(x => x.Hotel)
               .WithMany(h => h.Reviews)
               .HasForeignKey(x => x.HotelId)
               .IsRequired();

        builder.HasOne(x => x.Person)
               .WithMany(h => h.Reviews)
               .HasForeignKey(x => x.PersonId)
               .IsRequired();
    }
}