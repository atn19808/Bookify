using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Event
{
	public record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;

}
