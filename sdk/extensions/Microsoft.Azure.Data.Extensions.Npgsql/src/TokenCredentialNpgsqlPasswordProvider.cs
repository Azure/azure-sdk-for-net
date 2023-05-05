// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Npgsql;
using System.Threading.Tasks;
using System.Threading;
using System;
using Azure.Core;
using Microsoft.Azure.Data.Extensions.Common;

namespace Microsoft.Azure.Data.Extensions.Npgsql
{
    /// <summary>
    /// Provides implementations for Npgsql delegates to get passwords that can be used with Azure Database for Postgresql
    /// Passwords provided are access tokens issued by Azure AD.
    /// </summary>
    public class TokenCredentialNpgsqlPasswordProvider : TokenCredentialBaseAuthenticationProvider
    {
        /// <summary>
        /// Token credential provided by the caller that will be used to retrieve AAD access tokens.
        /// </summary>
        /// <param name="credential">TokenCredential to use to retrieve AAD access tokens</param>
        public TokenCredentialNpgsqlPasswordProvider(TokenCredential credential):base(credential)
        { }

        /// <summary>
        /// Method that implements NpgsqlDbContextOptionsBuilder.ProvidePasswordCallback delegate signature.
        /// It can used in Entity Framework DbContext configuration
        /// </summary>
        /// <param name="host">Just part of the delegate signature. It is ignored</param>
        /// <param name="port">Just part of the delegate signature. It is ignored</param>
        /// <param name="database">Just part of the delegate signature. It is ignored</param>
        /// <param name="username">Just part of the delegate signature. It is ignored</param>
        /// <returns></returns>
        public string ProvidePasswordCallback(string host, int port, string database, string username)
        {
            return GetAuthenticationToken();
        }

        /// <summary>
        /// Method that implements NpgsqlDataSourceBuilder.UsePeriodicPasswordProvider delegate signature.
        /// <see href="https://www.npgsql.org/doc/security.html?tabs=tabid-1#auth-token-rotation-and-dynamic-password"/>
        /// </summary>
        /// <param name="settings">ConnectionString settings</param>
        /// <param name="cancellationToken">token to propagate cancellation</param>
        /// <returns>AAD issued access token that can be used as password for Azure Database for Postgresql</returns>
        private ValueTask<string> PeriodicPasswordProvider(NpgsqlConnectionStringBuilder settings, CancellationToken cancellationToken=default)
        {
            return GetAuthenticationTokenAsync(cancellationToken);
        }

        /// <summary>
        /// Property that holds an implementation of NpgsqlDataSourceBuilder.UsePeriodicPasswordProvider delegate signature.
        /// </summary>
        public Func<NpgsqlConnectionStringBuilder, CancellationToken, ValueTask<string>> PasswordProvider
        {
            get { return PeriodicPasswordProvider; }
        }
    }
}
