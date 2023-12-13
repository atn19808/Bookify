﻿using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Inferastructure.Configuration
{
	internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("users");

			builder.HasKey(user => user.Id);

			builder.Property(user => user.FirstName)
				.HasMaxLength(20)
				.HasConversion(firstName => firstName.Value, value => new FirstName(value));

			builder.Property(user => user.LastName)
				.HasMaxLength(20)
				.HasConversion(lastName => lastName.Value, value => new LastName(value));

			builder.Property(user => user.Email)
				.HasMaxLength(20)
				.HasConversion(email => email.Value, value => new Domain.Users.Email(value));

			builder.HasIndex(user => user.Email).IsUnique();
		}
	}
}
