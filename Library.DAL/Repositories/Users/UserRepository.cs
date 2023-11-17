using Library.DAL.DbContexts;
using Library.DAL.Models;
using Library.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories.Users
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(LibraryDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<User>()
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

    }
}