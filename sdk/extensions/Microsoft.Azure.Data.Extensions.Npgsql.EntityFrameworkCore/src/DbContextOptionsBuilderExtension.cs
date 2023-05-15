// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Azure.Data.Extensions.Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using System;

namespace Microsoft.EntityFrameworkCore;

/// <summary>
/// Provides extension methods that simplifies the configuration to use Azure AD authentication to access to Azure Database for Postgresql with Npgsql Entity Framework
/// </summary>
public static class DbContextOptionsBuilderExtension
{
    /// <summary>
    /// Configures NpgsqlDbContextOptionsBuilder to use AAD authentication with a given TokenCredential.
    /// </summary>
    /// <param name="optionsBuilder">NpgsqlDbContextOptionsBuilder to be configured</param>
    /// <param name="credential">TokenCredential that will be used to retrieve AAD access tokens</param>
    /// <returns>NpgsqlDbContextOptionsBuilder configured with AAD authentication</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="optionsBuilder"/> or <paramref name="credential"/> are null</exception>
    public static NpgsqlDbContextOptionsBuilder UseAzureADAuthentication(this NpgsqlDbContextOptionsBuilder optionsBuilder, TokenCredential credential)
    {
        if (optionsBuilder == null)
            throw new ArgumentNullException(nameof(optionsBuilder));
        if (credential == null)
            throw new ArgumentNullException(nameof(credential));
        TokenCredentialNpgsqlPasswordProvider passwordProvider = new TokenCredentialNpgsqlPasswordProvider(credential);
        return optionsBuilder.ProvidePasswordCallback(passwordProvider.ProvidePasswordCallback);
    }
}
