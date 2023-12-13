using Bookify.Application.Abstractions.Email;

namespace Bookify.Inferastructure.Email
{
	internal sealed class EmailService : IEmailService
	{
		public Task SendAsync(Domain.Users.Email receipient, string subject, string body)
		{
			return Task.CompletedTask;
		}
	}
}
