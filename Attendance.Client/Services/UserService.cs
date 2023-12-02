using Attendance.Client.Shared;
using Attendance.Shared.Data;
using Attendance.Shared.Models;

namespace Attendance.Client.Services;

public class UserService : IUserService
{
    public User User => throw new NotImplementedException();

    public Task<User> GetUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Task AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PageRdesult<User>> GetUsers(string? name, string page)
    {
        throw new NotImplementedException();
    }

    public Task Initiatlize()
    {
        throw new NotImplementedException();
    }

    public Task Login(Login model)
    {
        throw new NotImplementedException();
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }

    public Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}