using System.ComponentModel.DataAnnotations;

namespace Attendance.Shared.DTOs.Requests;

public record UserRequestDto
{
    [Required]
    public string FirstName { get; set; } = default!;

    [Required]
    public string LastName { get; set; } = default!;

    [Required]
    public string Usrename { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}