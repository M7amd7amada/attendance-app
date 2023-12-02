using Attendance.Shared.Interfaces;

namespace Attendance.Server.Authorization;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(
        HttpContext context,
        IUserRepository userRepository,
        IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        ArgumentNullException.ThrowIfNull(token);
        var userId = jwtUtils.ValidateToken(token);

        if (userId is not null)
        {
            context.Items["User"] = await userRepository.GetByIdAsync(userId.Value);
        }

        await _next(context);
    }
}