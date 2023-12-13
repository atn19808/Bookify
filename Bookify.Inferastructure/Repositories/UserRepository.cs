using Bookify.Domain.Users;

namespace Bookify.Inferastructure.Repositories
{
	internal sealed class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
