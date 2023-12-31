﻿using Bookify.Application.Abstractions.Data;
using Bookify.Domain.Abstractions;
using Dapper;

namespace Bookify.Application.Bookings.GetBooking
{
	internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
	{
		private readonly ISqlConnectionFactory _sqlConnectionFactory;

		public GetBookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
		{
			_sqlConnectionFactory = sqlConnectionFactory;
		}

		public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
		{
			using var connection = _sqlConnectionFactory.CreateConnection();

			const string sql = """
				SELECT
				""";

			var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
				sql,
				new
				{
					request.BookingId
				}
				);
			return booking;
		}

	}
}
