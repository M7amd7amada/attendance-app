using Attendance.Server.Data;
using Attendance.Shared.Data;
using Attendance.Shared.Interfaces;
using Attendance.Shared.Models;

namespace Attendance.Server.Repositories;

public class UserRepostiory(
    AppDbContext context,
    IUnitOfWork unitOfWork,
    ILogger logger,
    IJwtUtils jwtUtils) : RepositoryBase<User>(context, unitOfWork, logger), IUserRepository
{
    private readonly IJwtUtils _jwtUtils = jwtUtils;
    public PageRdesult<User> GetUsers(string? name, int page)
    {
        throw new NotImplementedException();
    }
}