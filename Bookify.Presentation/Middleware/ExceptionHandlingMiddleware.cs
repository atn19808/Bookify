namespace Bookify.Api.Middleware
{
	public class ExceptionHandlingMiddleware
	{
		public readonly RequestDelegate _next;
		public readonly ILogger<ExceptionHandlingMiddleware> _logger;

		public ExceptionHandlingMiddleware(
			RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, "Exception occured: {Message}", exception.Message);

				var exceptionDetails = GetExceptionDetails(exception);

				var problemDetails = new ProblemDetailsContext
				{
					Status = exceptionDetails.Status,
					Type = exceptionDetails.Type,
					Title = exceptionDetails.Title,
					Detail = exceptionDetails.Detail
				};

				if (exceptionDetails.Errors is not null)
				{
					problemDetails.Extensions["errors"] = exceptionDetails.Errors;
				}

				context.Response.StatusCode = exceptionDetails.Status;

				await context.Response.WriteAsJsonAsync(problemDetails);

			}
		}

		public static ExceptionDetails GetException(Exception exception)
		{
			return exception switch
			{
				ValidateException validationException => new ExceptionDetails(
					StatusCodes.Status400BadRequest,
					"ValidationFailure",
					"Validation error",
					"One or more validation errors has occurred",
					validationException.Errors),
				_ => new ExceptionDetails(
					StatusCodes.Status500InternalServerError,
					"ServerError",
					"Server error",
					"An unexpected error has occurred",
					null)
			};

		}

		internal record ExceptionDetails(
			int Status,
			string Type,
			string Title,
			string Detail,
			IEnumerable<object>? Errors
			);
	}
}
