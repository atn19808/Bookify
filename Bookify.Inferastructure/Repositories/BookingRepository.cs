using Bookify.Domain.Apartments;
using Bookify.Domain.Booking;
using Bookify.Domain.Bookings;

namespace Bookify.Inferastructure.Repositories
{
	internal sealed class BookingRepository : Repository<Booking>, IBookingRepository
	{
		private static readonly BookingStatus[] ActiveBookingStatuses =
		{
			BookingStatus.Reserved,
			BookingStatus.Confirmed,
			BookingStatus.Rejected
		};

		public BookingRepository(ApplicationDbContext dbContext) : base(dbContext) { }

		public async Task<bool> IsOverlappingAsync(
			Apartment apartment,
			DateRange duration,
			CancellationToken cancellationToken = default
			)
		{
			return await DbContext
				.Set<Booking>()
				.AddAsync(
				booking =>
					booking.ApartmentId == apartment.Id &&
					booking.Duration.Start <= duration.End &&
					booking.Duration.End >= duration.Start &&
					ActiveBookingStatuses.Contains(booking.Status),
				cancellationToken);
		}
	}
}
