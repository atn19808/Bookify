namespace Bookify.Application.Abstractions.Authentication
{
	public interface IAuthenticationService
	{
		Task<string> RegisterAsync(Users user, string password, CancellationToken cancellationToken);
	}
}
