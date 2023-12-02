namespace Attendance.Shared.DTOs.Responses;

public record AuthenticateResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Token { get; set; } = default!;
}