namespace Bookify.Domain.Bookings
{
	public interface IBookingRepository
	{
		Task<Booking?> GetByIdAsync(Guid bookingId, CancellationToken cancellationToken = default);

		Task<bool> IsOverlappingAsync(Apartments apartment, DateRange duration, CancellationToken cancellationToken = default);

		void Add(Booking booking);
	}
}
