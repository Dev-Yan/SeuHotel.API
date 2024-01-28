using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Shared.Core.Classes;

public class BaseModelMapping<M> : IEntityTypeConfiguration<M> where M : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<M> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue<bool>(false);

        builder.Property(x => x.CreatedAt)
            .HasDefaultValue<DateTime>(DateTime.UtcNow);

        builder.Property(x => x.UpdatedAt)
            .HasDefaultValue<DateTime>(DateTime.UtcNow);

        builder.Property(x => x.DeletedAt)
            .HasDefaultValue(null);

        builder.HasQueryFilter(x => x.IsDeleted == false);
    }
}