// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Azure.Data.Extensions.Npgsql;
using System;

namespace Npgsql
{
    /// <summary>
    /// NpgsqlDataSourceBuilder extensions that simplify the configuration to use AAD authentication when connecting to Azure Database for Postgresql
    /// </summary>
    public static partial class NpgsqlDataSourceBuilderExtensions
    {
        /// <summary>
        /// Configures NpgsqlDataSourceBuilder to use AAD authentication to connect to Azure Database for Postgresql using the provided TokenCredential
        /// </summary>
        /// <param name="builder">NpgsqlDataSourceBuilder to be configured with AAD authentication</param>
        /// <param name="credential">TokenCredential that will be used to retrieve AAD access tokens</param>
        /// <returns>NpgsqlDataSourceBuilder configured with AAD authentication</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="builder"/> or <paramref name="credential"/> are null</exception>
        public static NpgsqlDataSourceBuilder UseAzureADAuthentication(this NpgsqlDataSourceBuilder builder, TokenCredential credential)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (credential == null)
                throw new ArgumentNullException(nameof(credential));
            var passwordProvider = new TokenCredentialNpgsqlPasswordProvider(credential);
            return builder.UsePeriodicPasswordProvider(passwordProvider.PasswordProvider, TimeSpan.FromMinutes(29), TimeSpan.FromSeconds(5));
        }
    }
}