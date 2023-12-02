using Attendance.Server.Data;
using Attendance.Shared.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Attendance.Server.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly ILogger _logger;
    protected readonly DbSet<T> _entities;
    public RepositoryBase(AppDbContext context, IUnitOfWork unitOfWork, ILogger logger)
    {
        _context = context;
        _unitOfWork = unitOfWork;
        _logger = logger;
        _entities = _context.Set<T>();
    }

    public async Task<T?> AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
        return entity;
    }

    public async Task<T?> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        ArgumentNullException.ThrowIfNull(entity);
        _entities.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var entity = await _entities.FindAsync(id);
        return entity;
    }

    public async Task<T?> UpdateAsync(T entity)
    {
        _entities.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}