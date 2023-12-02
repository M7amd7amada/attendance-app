using Attendance.Shared.Data;
using Attendance.Shared.DTOs.Requests;
using Attendance.Shared.DTOs.Responses;
using Attendance.Shared.Models;

namespace Attendance.Shared.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    public AuthenticateResponseDto Authenticate(AuthenticateRequestDto request);
    public PageRdesult<User> GetUsers(string? name, int page);
    public Task<User?> GetUser(int id);
    public Task<User> CreateUser(User user);
    public Task<User?> UpdateUser(User user);
    public Task<User?> DeleteUser(int id);
}