using Library.DAL.Models;
using Library.DAL.Repositories.Base;

namespace Library.DAL.Repositories.Users
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}