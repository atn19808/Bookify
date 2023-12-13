﻿using Bookify.Api.Middleware;
using Bookify.Inferastructure;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Api.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static void ApplyMigration(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();

			using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

			dbContext.Database.Migrate();
		}
	}

	public static void UseCustomeExceptionHandler(this IApplicationBuilder app)
	{
		app.UseMiddleware<ExceptionHandlingMiddleware>();
	}
}
