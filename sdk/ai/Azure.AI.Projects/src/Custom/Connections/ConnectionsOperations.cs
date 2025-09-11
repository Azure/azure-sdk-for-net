// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects
{
    public partial class ConnectionsOperations
    {
        /// <summary>
        /// Get a connection by name.
        /// </summary>
        /// <param name="connectionName">The name of the connection. Required.</param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <returns>A <see cref="ConnectionProperties"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public virtual ConnectionProperties GetConnection(string connectionName, bool includeCredentials = false, string clientRequestId = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
            {
                throw new ArgumentException("Connection name cannot be null or empty.", nameof(connectionName));
            }

            // Use the instance method instead of incorrectly calling it as static
            if (includeCredentials)
            {
                return GetConnectionWithCredentials(connectionName, clientRequestId, cancellationToken);
            }

            return GetConnection(connectionName, clientRequestId, cancellationToken);
        }

        /// <summary>
        /// Get a connection by name.
        /// </summary>
        /// <param name="connectionName">The name of the connection. Required.</param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <returns>A <see cref="ConnectionProperties"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public virtual async Task<ClientResult<ConnectionProperties>> GetConnectionAsync(string connectionName, bool includeCredentials = false, string clientRequestId = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
            {
                throw new ArgumentException("Connection name cannot be null or empty.", nameof(connectionName));
            }

            // Use the instance method instead of incorrectly calling it as static
            if (includeCredentials)
            {
                return await GetConnectionWithCredentialsAsync(connectionName, clientRequestId, cancellationToken).ConfigureAwait(false);
            }

            return await GetConnectionAsync(connectionName, clientRequestId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the default connection.
        /// </summary>
        /// <param name="connectionType"> List connections of this specific type. </param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <returns>A <see cref="ConnectionProperties"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public virtual ConnectionProperties GetDefaultConnection(ConnectionType? connectionType = null, bool includeCredentials = false)
        {
            foreach (var connection in GetConnections(connectionType))
            {
                if (connection.IsDefault)
                {
                    return GetConnection(connection.Name, includeCredentials);
                }
            }
            throw new RequestFailedException("No connections found.");
        }

        /// <summary>
        /// Get the default connection.
        /// </summary>
        /// <param name="connectionType"> List connections of this specific type. </param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <returns>A <see cref="ConnectionProperties"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public virtual async Task<ConnectionProperties> GetDefaultConnectionAsync(ConnectionType? connectionType = null, bool includeCredentials = false)
        {
            await foreach (var connection in GetConnectionsAsync(connectionType).ConfigureAwait(false))
            {
                if (connection.IsDefault)
                {
                    return await GetConnectionAsync(connection.Name, includeCredentials).ConfigureAwait(false);
                }
            }
            throw new RequestFailedException("No connections found.");
        }
    }
}
