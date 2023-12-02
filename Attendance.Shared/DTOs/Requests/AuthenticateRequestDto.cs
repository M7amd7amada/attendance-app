namespace Attendance.Shared.DTOs.Requests;

public record AuthenticateRequestDto
{
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}