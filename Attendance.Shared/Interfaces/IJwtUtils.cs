using Attendance.Shared.Models;

namespace Attendance.Shared.Interfaces;

public interface IJwtUtils
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}