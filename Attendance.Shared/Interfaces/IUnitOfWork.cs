namespace Attendance.Shared.Interfaces;

public interface IUnitOfWork
{
    public IUserRepository Users { get; }
    public Task<bool> CompleteAsync();
}