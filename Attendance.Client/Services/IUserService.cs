using Attendance.Client.Shared;
using Attendance.Shared.Data;
using Attendance.Shared.Models;

namespace Attendance.Client.Services;

public interface IUserService
{
    public User User { get; }
    public Task Initiatlize();
    public Task Login(Login model);
    public Task Logout();
    public Task<PageRdesult<User>> GetUsers(string? name, string page);
    public Task<User> GetUser { get; set; }
    public Task DeleteUser(int id);
    public Task AddUser(User user);
    public Task UpdateUser(User user);
}