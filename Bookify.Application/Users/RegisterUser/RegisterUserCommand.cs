using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Users.RegisterUser
{
	public sealed class RegisterUserCommand(
		string Email,
		string FirstName,
		string LastName,
		string Password) : ICommand<Guid>;
}
