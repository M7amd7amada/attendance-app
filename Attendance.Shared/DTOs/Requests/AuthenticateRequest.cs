namespace Attendance.Shared.DTOs.Requests;

public record AuthenticateRequest
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
}