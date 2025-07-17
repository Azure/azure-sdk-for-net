// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Threading.Tasks;

namespace Azure.AI.Projects
{
    public partial class Connections
    {
        /// <summary>
        /// Get a connection by name.
        /// </summary>
        /// <param name="connectionName">The name of the connection. Required.</param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <returns>A <see cref="ConnectionProperties"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public ConnectionProperties GetConnection(string connectionName, bool includeCredentials = false)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
            {
                throw new ArgumentException("Connection name cannot be null or empty.", nameof(connectionName));
            }

            // Use the instance method instead of incorrectly calling it as static
            if (includeCredentials)
            {
                return GetWithCredentials(connectionName);
            }

            return Get(connectionName);
        }

        /// <summary>
        /// Get a connection by name.
        /// </summary>
        /// <param name="connectionName">The name of the connection. Required.</param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <returns>A <see cref="ConnectionProperties"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public async Task<ClientResult<ConnectionProperties>> GetConnectionAsync(string connectionName, bool includeCredentials = false)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
            {
                throw new ArgumentException("Connection name cannot be null or empty.", nameof(connectionName));
            }

            // Use the instance method instead of incorrectly calling it as static
            if (includeCredentials)
            {
                return await GetWithCredentialsAsync(connectionName).ConfigureAwait(false);
            }

            return await GetAsync(connectionName).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the default connection.
        /// </summary>
        /// <param name="connectionType"> List connections of this specific type. </param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <returns>A <see cref="ConnectionProperties"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public ConnectionProperties GetDefault(ConnectionType? connectionType = null, bool includeCredentials = false)
        {
            foreach (var connection in Get(connectionType))
            {
                // Use the instance method instead of incorrectly calling it as static
                if (includeCredentials)
                {
                    return GetWithCredentials(connection.Name);
                }

                return GetConnection(connection.Name);
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
        public async Task<ConnectionProperties> GetDefaultAsync(ConnectionType? connectionType = null, bool includeCredentials = false)
        {
            await foreach (var connection in GetAsync(connectionType).ConfigureAwait(false))
            {
                // Use the instance method instead of incorrectly calling it as static
                if (includeCredentials)
                {
                    return await GetWithCredentialsAsync(connection.Name).ConfigureAwait(false);
                }

                return await GetConnectionAsync(connection.Name).ConfigureAwait(false);
            }
            throw new RequestFailedException("No connections found.");
        }

        /// <summary>
        /// List all connections in the project.
        /// </summary>
        /// <param name="connectionType">List connections of this specific type.</param>
        /// <returns>An enumerable of <see cref="ConnectionProperties"/> objects.</returns>
        public CollectionResult<ConnectionProperties> GetConnections(ConnectionType? connectionType = null)
        {
            return Get(connectionType);
        }

        /// <summary>
        /// List all connections in the project.
        /// </summary>
        /// <param name="connectionType">List connections of this specific type.</param>
        /// <returns>An async enumerable of <see cref="ConnectionProperties"/> objects.</returns>
        public AsyncCollectionResult<ConnectionProperties> GetConnectionsAsync(ConnectionType? connectionType = null)
        {
            return GetAsync(connectionType);
        }
    }
}
