// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Azure.Data.Extensions.MySqlConnector;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MySqlConnector;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.Extensions.Pomelo.EntityFrameworkCore
{
    /// <summary>
    /// DBConnectionInterceptor that assigns ProvidePasswordCallback to MySqlConnection just before opening.
    /// </summary>
    internal class TokenCredentialMysqlPasswordProviderInterceptor : DbConnectionInterceptor
    {
        private readonly TokenCredentialMysqlPasswordProvider _passwordProvider;

        /// <summary>
        /// Constructor that allows specify TokenCredential to be used to retrieve AAD access tokens
        /// </summary>
        /// <param name="credential">TokenCredential to be used to retrieve AAD access tokens</param>
        public TokenCredentialMysqlPasswordProviderInterceptor(TokenCredential credential)
        {
            _passwordProvider = new TokenCredentialMysqlPasswordProvider(credential);
        }

        /// <summary>
        /// Method that is called synchronously just before the physical connection is opened
        /// </summary>
        /// <param name="connection">DbConnection. It should be of type MySqlConnection</param>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override InterceptionResult ConnectionOpening(DbConnection connection, ConnectionEventData eventData, InterceptionResult result)
        {
            var mysqlConnection = (MySqlConnection)connection;
            mysqlConnection.ProvidePasswordCallback = _passwordProvider.ProvidePassword;
            return result;
        }

        /// <summary>
        /// Method that is called asynchronously just before the physical connection is opened
        /// </summary>
        /// <param name="connection">DbConnection. It should be of type MySqlConnection</param>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override ValueTask<InterceptionResult> ConnectionOpeningAsync(DbConnection connection, ConnectionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
        {
            var mysqlConnection = (MySqlConnection)connection;
            mysqlConnection.ProvidePasswordCallback = _passwordProvider.ProvidePassword;
            return ValueTask.FromResult(result);
        }
    }
}