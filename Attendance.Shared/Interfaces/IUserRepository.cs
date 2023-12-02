using Attendance.Shared.Data;
using Attendance.Shared.Models;

namespace Attendance.Shared.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    public PageRdesult<User> GetUsers(string? name, int page);
}