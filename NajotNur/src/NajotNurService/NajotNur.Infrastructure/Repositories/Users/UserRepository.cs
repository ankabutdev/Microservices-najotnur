using Microsoft.EntityFrameworkCore;
using NajotNur.Application.Data;
using NajotNur.Application.Interfaces.Users;
using NajotNur.Domain.Entities.Users;

namespace NajotNur.Application.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly NurDbContext _dbContext;

    public UserRepository(NurDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<int> CreateAsnyc(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<int> DeleteAsnyc(int id)
    {
        var entity = await _dbContext
        .Users
        .FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null)
            return 0;

        _dbContext.Users.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<IEnumerable<User>> GetAllAsnyc()
        => await _dbContext.Users.ToListAsync();

    public async ValueTask<int> UpdateAsnyc(User user)
    {
        _dbContext.Users.Update(user);

        return await _dbContext.SaveChangesAsync();
    }
}
