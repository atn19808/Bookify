using Bookify.Application.Abstractions.Clock;

namespace Bookify.Inferastructure.Clock
{
	internal sealed class DateTimeProvider : IDateTimeProvider
	{
		public DateTime UtcNow => DateTime.UtcNow;
	}
}
