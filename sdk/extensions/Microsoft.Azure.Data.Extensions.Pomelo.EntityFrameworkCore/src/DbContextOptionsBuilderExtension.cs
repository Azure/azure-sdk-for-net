// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Azure.Data.Extensions.MySqlConnector;
using Microsoft.Azure.Data.Extensions.Pomelo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Microsoft.EntityFrameworkCore;

/// <summary>
/// Provides extension methods that simplifies the configuration to use Azure AD authentication to access to Azure Database for MySQL when using Entity Framework with Pomelo
/// </summary>
public static class DbContextOptionsBuilderExtension
{
    /// <summary>
    /// Configures DbContext to use AAD issued tokens as passwords to access to Azure Database for MySQL, providing the TokenCredential to be used to retrieve access tokens
    /// </summary>
    /// <param name="optionsBuilder">DbContextOptionsBuilder to configure with AAD authentication</param>
    /// <param name="credential">TokenCredential provided by the call to retrieve AAD tokens</param>
    /// <returns>DbContextOptionsBuilder configured with AAD authentication</returns>
    public static DbContextOptionsBuilder UseAzureADAuthentication(this DbContextOptionsBuilder optionsBuilder, TokenCredential credential)
    {
        // see: https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/issues/1643
        return optionsBuilder.AddInterceptors(new TokenCredentialMysqlPasswordProviderInterceptor(credential));
    }
}