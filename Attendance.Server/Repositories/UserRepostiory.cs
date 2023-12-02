using Attendance.Server.Data;
using Attendance.Server.Helpers;
using Attendance.Shared.Data;
using Attendance.Shared.DTOs.Requests;
using Attendance.Shared.DTOs.Responses;
using Attendance.Shared.Interfaces;
using Attendance.Shared.Models;

using Microsoft.EntityFrameworkCore;

namespace Attendance.Server.Repositories;

public class UserRepostiory(
    AppDbContext context,
    IUnitOfWork unitOfWork,
    IJwtUtils jwtUtils) : RepositoryBase<User>(context, unitOfWork), IUserRepository
{
    private readonly IJwtUtils _jwtUtils = jwtUtils;

    public AuthenticateResponseDto Authenticate(AuthenticateRequestDto request)
    {
        throw new NotImplementedException();
    }

    // public async AuthenticateResponseDto Authenticate(AuthenticateRequestDto request)
    // {
    //     var user = await _entities.SingleOrDefaultAsync(u => u.Username == request.Username);

    //     if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
    //     {
    //         throw new AppException("Username or password is incorrect");
    //     }

    //        // Todo ADD Mapping here
    //     return default!;
    // }

    public async Task<User> CreateUser(User user)
    {
        if (await _entities.AnyAsync(u => u.Username == user.Username))
        {
            throw new AppException($"Username: '{user.Username}' is already taken.");
        }
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
        Console.WriteLine($"{user.Password} ==> {user.PasswordHash}");
        user.Password = "**********";

        var result = await AddAsync(user);
        return user;
    }

    public async Task<User?> DeleteUser(int id)
    {
        var result = await GetByIdAsync(id);
        if (result is null)
        {
            throw new KeyNotFoundException("User not found");
        }
        if (result.Username == "admin")
        {
            throw new AppException("Admin can not be deleted.");
        }

        _entities.Remove(result);
        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<User?> GetUser(int id)
    {
        var result = await _entities.FirstOrDefaultAsync(u => u.Id == id);

        if (result is null)
        {
            throw new KeyNotFoundException("User not found.");
        }
        return result;
    }

    public PageRdesult<User> GetUsers(string? name, int page)
    {
        int pageSize = 5; // ! Fixed Info Should by dynamic

        if (name is not null)
        {
            return _entities
                .Where(u => u.FirstName.Contains(name, StringComparison.CurrentCultureIgnoreCase)
                    || u.LastName.Contains(name, StringComparison.CurrentCultureIgnoreCase)
                    || u.Username.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(u => u.Username)
                .GetPaged(page, pageSize);
        }
        else
        {
            return _entities
                .OrderBy(u => u.Username)
                .GetPaged(page, pageSize);
        }
    }

    public async Task<User?> UpdateUser(User user)
    {
        var result = await _entities.FirstOrDefaultAsync(u => u.Id == user.Id);

        if (result is null)
            throw new KeyNotFoundException("User not found");

        if (result.Username == "admin")
            throw new AppException("Admin may not be updated");

        // validate unique
        if (user.Username != result.Username && _entities.Any(u => u.Username == user.Username))
            throw new AppException("Username '" + user.Username + "' is already taken");

        // hash password if entered
        if (!string.IsNullOrEmpty(user.Password) && user.Password != result.Password)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = "**********";
        }

        if (result != null)
        {
            // Update existing user
            _context.Entry(result).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException("User not found");
        }
        return result;
    }

}