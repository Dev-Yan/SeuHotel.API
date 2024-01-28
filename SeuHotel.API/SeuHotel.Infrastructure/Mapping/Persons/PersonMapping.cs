using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeuHotel.Infrastructure.Entities;
using Shared.Core.Classes;

namespace SeuHotel.Infrastructure.Mapping.Persons;

public class PersonMapping : BaseModelMapping<Person>
{
    public override void Configure(EntityTypeBuilder<Person> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(30);

        builder.Property(x => x.Address)
            .HasMaxLength(200);

        builder.Property(x => x.DateOfBirth)
            .IsRequired();

        builder.Property(x => x.UserType)
                 .IsRequired();

        builder.Property(x => x.Gender)
            .IsRequired();

        builder.Property(x => x.Nationality)
            .IsRequired();

        builder.HasMany(x => x.Reviews)
               .WithOne()
               .HasForeignKey(x => x.PersonId);

        builder.HasMany(x => x.Reservations)
            .WithOne()
            .HasForeignKey(x => x.PersonId);

        builder.HasMany(x => x.Hotels)
            .WithOne()
            .HasForeignKey(x => x.OwnerId);
    }
}