using NajotNur.Domain.Entities.Users;

namespace NajotNur.Application.Interfaces.Users;

public interface IUserRepository
{
    public ValueTask<int> CreateAsnyc(User user);

    public ValueTask<int> UpdateAsnyc(User user);

    public ValueTask<int> DeleteAsnyc(int id);

    public ValueTask<IEnumerable<User>> GetAllAsnyc();
}
