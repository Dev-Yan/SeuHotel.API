using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Shared.Core.Classes;
using SeuHotel.Infrastructure.Mapping.Persons;

namespace SeuHotel.Infrastructure.Context;

public class SeuHotelContext : DbContext
{
    public SeuHotelContext(DbContextOptions<SeuHotelContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonMapping).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        foreach (var entity in ChangeTracker.Entries<BaseEntity>().Where(E => E.State == EntityState.Modified).ToList())
        {
            var isDeleted = entity.Property(x => x.IsDeleted).CurrentValue;
            if (isDeleted) entity.Property(x => x.DeletedAt).CurrentValue = DateTime.UtcNow;
            entity.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
            entity.Property(x => x.CreatedAt).IsModified = false;
        }
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}