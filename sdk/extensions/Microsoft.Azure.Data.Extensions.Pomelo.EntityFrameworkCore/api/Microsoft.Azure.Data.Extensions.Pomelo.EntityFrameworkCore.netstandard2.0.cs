using Azure.Core;
using Microsoft.Azure.Data.Extensions.Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using System;


namespace Microsoft.EntityFrameworkCore;

/// <summary>
/// Provides extension methods that simplifies the configuration to use Azure AD authentication to access to Azure Database for Postgresql with Npgsql Entity Framework
/// </summary>
public static partial class DbContextOptionsBuilderExtension
{
    /// <summary>
    /// Configures NpgsqlDbContextOptionsBuilder to use AAD authentication with a given TokenCredential.
    /// </summary>
    /// <param name="optionsBuilder">NpgsqlDbContextOptionsBuilder to be configured</param>
    /// <param name="credential">TokenCredential that will be used to retrieve AAD access tokens</param>
    /// <returns>NpgsqlDbContextOptionsBuilder configured with AAD authentication</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="optionsBuilder"/> or <paramref name="credential"/> are null</exception>
    public static partial NpgsqlDbContextOptionsBuilder UseAzureADAuthentication(this NpgsqlDbContextOptionsBuilder optionsBuilder, TokenCredential credential) { }
}
