using Assesments.Data;

namespace Assesments.Services;

public class UserServices
{
    private readonly IUserRepository _userRepository;

    public UserServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetUsersAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task AddUserAsync(User user)
    {
        try
        {
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
}
