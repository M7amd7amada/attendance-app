using Attendance.Shared.Data;

namespace Attendance.Shared.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    public Task<T?> GetByIdAsync(int id);
    public Task<T?> AddAsync(T entity);
    public Task<T?> DeleteAsync(int id);
    public Task<T?> UpdateAsync(T entity);
    public Task<IEnumerable<T>> GetAllAsync();
}