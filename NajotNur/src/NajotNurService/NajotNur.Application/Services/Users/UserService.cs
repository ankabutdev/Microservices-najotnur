using NajotNur.Application.Interfaces.Users;
using NajotNur.Domain.Entities.Users;

namespace NajotNur.Application.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async ValueTask<bool> CreateAsnyc(User user)
    {
        if (user is null)
            return false;

        var users = new User()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };

        var result = await _userRepository.CreateAsnyc(users);
        return result > 0;
    }

    public async ValueTask<bool> DeleteAsnyc(int id)
    {
        if (id < 0) return false;

        var result = await _userRepository.DeleteAsnyc(id);

        return result > 0;
    }

    public async ValueTask<IEnumerable<User>> GetAllAsnyc()
        => await _userRepository.GetAllAsnyc();

    public async ValueTask<bool> UpdateAsnyc(int userId, User user)
    {
        var result = await _userRepository.UpdateAsnyc(user);

        return result > 0;
    }
}