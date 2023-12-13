using Bookify.Domain.Apartments;

namespace Bookify.Inferastructure.Repositories
{
	internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
	{
		public ApartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
