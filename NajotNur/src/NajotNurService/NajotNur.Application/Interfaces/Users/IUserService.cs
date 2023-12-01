using NajotNur.Domain.Entities.Users;

namespace NajotNur.Application.Interfaces.Users;

public interface IUserService
{
    public ValueTask<bool> CreateAsnyc(User user);

    public ValueTask<bool> UpdateAsnyc(int userId, User user);

    public ValueTask<bool> DeleteAsnyc(int id);

    public ValueTask<IEnumerable<User>> GetAllAsnyc();
}
