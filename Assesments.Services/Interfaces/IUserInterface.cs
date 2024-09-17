using Assesments.Data;

namespace Assesments.Services;

public interface IUserInterface
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task AddUserAsync(User user);
}
