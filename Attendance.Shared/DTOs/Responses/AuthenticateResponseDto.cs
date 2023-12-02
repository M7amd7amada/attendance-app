namespace Attendance.Shared.DTOs.Responses;

public record AuthenticateResponseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Token { get; set; } = default!;
}