using System.ComponentModel.DataAnnotations;

namespace Attendance.Client.Shared;

public class Login
{
    [Required]
    public required string UserName { get; set; }

    [Required]
    public required string Password { get; set; }
}