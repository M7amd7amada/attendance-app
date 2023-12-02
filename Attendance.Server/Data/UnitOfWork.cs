using Attendance.Server.Repositories;
using Attendance.Shared.Interfaces;

using Microsoft.Extensions.Logging;

namespace Attendance.Server.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IJwtUtils _jwtUtils;

    public UnitOfWork(
        AppDbContext context,
        IJwtUtils jwtUtils
    )
    {
        _context = context;
        _jwtUtils = jwtUtils;

        Users = new UserRepostiory(_context, this, _jwtUtils);
    }

    public IUserRepository Users { get; private set; }

    public Task<bool> CompleteAsync()
    {
        throw new NotImplementedException();
    }
}