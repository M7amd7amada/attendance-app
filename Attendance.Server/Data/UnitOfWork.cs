using Attendance.Server.Repositories;
using Attendance.Shared.Interfaces;

using Microsoft.Extensions.Logging;

namespace Attendance.Server.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly ILogger _logger;
    private readonly IJwtUtils _jwtUtils;

    public UnitOfWork(
        AppDbContext context,
        ILoggerFactory loggerFactory,
        IJwtUtils jwtUtils
    )
    {
        _context = context;
        _logger = loggerFactory.CreateLogger("db_logs");
        _jwtUtils = jwtUtils;

        Users = new UserRepostiory(_context, this, _logger, _jwtUtils);
    }

    public IUserRepository Users { get; private set; }

    public Task<bool> CompleteAsync()
    {
        throw new NotImplementedException();
    }
}