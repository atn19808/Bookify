namespace Bookify.Application.Exception
{
	public sealed record ValidationError(string PropertyName, string ErrorMessage);
}
