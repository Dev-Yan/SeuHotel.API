using Microsoft.EntityFrameworkCore;
using Npgsql;
using SeuHotel.Infrastructure.Context;
using SeuHotel.Infrastructure.Services.Interfaces;
using Shared.Core.Classes.Interfaces;
using System.Linq.Expressions;
using System.Net;

namespace Shared.Core.Classes;

public abstract class BaseRepository<M> : IRepository<M>
    where M : BaseEntity
{
    protected SeuHotelContext _context;
    private readonly IUserContextValidatorService _userContextValidator;

    public BaseRepository(SeuHotelContext context, IUserContextValidatorService userContextValidator)
    {
        _userContextValidator = userContextValidator ?? throw new ArgumentNullException(nameof(userContextValidator));
        _context = context;
    }

    public virtual async Task<M?> Create(M model)
    {
        try
        {
            model.Id = 0;
            await _context.Set<M>().AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException is PostgresException)
                if (((PostgresException)ex.InnerException).Code == "23503")
                    throw new HttpRequestException($"Foreign Key {((Npgsql.PostgresException)ex.InnerException).ConstraintName} violated", ex, HttpStatusCode.Conflict);
            if (((PostgresException)ex.InnerException).Code == "23505")
                throw new HttpRequestException($"Unique index {((Npgsql.PostgresException)ex.InnerException).ConstraintName} violated", ex, HttpStatusCode.Conflict);

            throw;
        }
    }

    public virtual async Task<List<M>> GetAll()
    {
        return await _context.Set<M>().ToListAsync();
    }

    public virtual async Task<M?> GetById(long id, bool entityTracking = true)
    {
        var query = _context.Set<M>().AsQueryable();

        if (!entityTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(x => x.Id == id);

    }

    public async Task<M?> SearchOne(Expression<Func<M, bool>> expression)
    {
        return await _context.Set<M>()
            .Where(expression)
            .FirstOrDefaultAsync();
    }

    public virtual async Task<M?> Update(M model)
    {
        _context.Set<M>().Update(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public virtual async Task SoftDelete(M model)
    {
        model.IsDeleted = true;

        _context.Set<M>().Update(model);
        await _context.SaveChangesAsync();
    }

    public virtual async Task HardDelete(M model)
    {
        _context.Set<M>().Remove(model);
        await _context.SaveChangesAsync();
    }
}