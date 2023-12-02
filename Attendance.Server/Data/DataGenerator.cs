using Attendance.Shared.Models;

using Bogus;

namespace Attendance.Server.Data;

public class DataGenerator
{
    public static async Task Initialize(AppDbContext appDbContext)
    {
        Randomizer.Seed = new Random(32321);
        appDbContext.Database.EnsureDeleted();
        appDbContext.Database.EnsureCreated();

        if (!appDbContext.Users.Any())
        {
            var testUsers = new Faker<User>()
                .RuleFor(u => u.FirstName, u => u.Name.FirstName())
                .RuleFor(u => u.LastName, u => u.Name.LastName())
                .RuleFor(u => u.Username, u => u.Internet.UserName())
                .RuleFor(u => u.Password, u => u.Internet.Password());
            var users = testUsers.Generate(4);

            User customUser = new User()
            {
                FirstName = "Mohammed",
                LastName = "Hamada",
                Username = "admin",
                Password = "admin"
            };

            users.Add(customUser);

            foreach (User u in users)
            {
                u.PasswordHash = BCrypt.Net.BCrypt.HashPassword(u.Password);
                u.Password = "**********";
                await appDbContext.Users.AddAsync(u);
            }
            await appDbContext.SaveChangesAsync();
        }
    }
}