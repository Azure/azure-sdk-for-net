// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects
{
    [CodeGenType("AIProjectConnectionsOperations")]
    public partial class AIProjectConnectionsOperations
    {
        /// <summary>
        /// Get a connection by name.
        /// </summary>
        /// <param name="connectionName">The name of the connection. Required.</param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <returns>A <see cref="AIProjectConnection"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnection(string connectionName, bool includeCredentials, CancellationToken cancellationToken) instead.")]
        public virtual AIProjectConnection GetConnection(string connectionName, bool includeCredentials, string clientRequestId, CancellationToken cancellationToken)
        {
            return GetConnection(connectionName, includeCredentials, cancellationToken);
        }

        /// <summary>
        /// Get a connection by name.
        /// </summary>
        /// <param name="connectionName">The name of the connection. Required.</param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <returns>A <see cref="AIProjectConnection"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnectionAsync(string connectionName, bool includeCredentials, CancellationToken cancellationToken) instead.")]
        public async virtual Task<ClientResult<AIProjectConnection>> GetConnectionAsync(string connectionName, bool includeCredentials, string clientRequestId, CancellationToken cancellationToken)
        {
            return await GetConnectionAsync(connectionName, includeCredentials, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a connection by name.
        /// </summary>
        /// <param name="connectionName">The name of the connection. Required.</param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <returns>A <see cref="AIProjectConnection"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public virtual AIProjectConnection GetConnection(string connectionName, bool includeCredentials = false, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
            {
                throw new ArgumentException("Connection name cannot be null or empty.", nameof(connectionName));
            }

            // Use the instance method instead of incorrectly calling it as static
            if (includeCredentials)
            {
                return GetConnectionWithCredentials(connectionName, cancellationToken);
            }

            return GetConnection(connectionName, cancellationToken);
        }

        /// <summary>
        /// Get a connection by name.
        /// </summary>
        /// <param name="connectionName">The name of the connection. Required.</param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <returns>A <see cref="AIProjectConnection"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public async virtual Task<ClientResult<AIProjectConnection>> GetConnectionAsync(string connectionName, bool includeCredentials = false, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
            {
                throw new ArgumentException("Connection name cannot be null or empty.", nameof(connectionName));
            }

            // Use the instance method instead of incorrectly calling it as static
            if (includeCredentials)
            {
                return await GetConnectionWithCredentialsAsync(connectionName, cancellationToken).ConfigureAwait(false);
            }

            return await GetConnectionAsync(connectionName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the default connection.
        /// </summary>
        /// <param name="connectionType"> List connections of this specific type. </param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <returns>A <see cref="AIProjectConnection"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public virtual AIProjectConnection GetDefaultConnection(ConnectionType? connectionType = null, bool includeCredentials = false)
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
        /// <returns>A <see cref="AIProjectConnection"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public async virtual Task<AIProjectConnection> GetDefaultConnectionAsync(ConnectionType? connectionType = null, bool includeCredentials = false)
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
        /// <summary>
        /// [Protocol Method] List all connections in the project, without populating connection credentials
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="connectionType"> List connections of this specific type. </param>
        /// <param name="defaultConnection"> List connections that are default connections. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnections(string connectionType, bool? defaultConnection, RequestOptions options) instead.")]
        public virtual CollectionResult GetConnections(string connectionType, bool? defaultConnection, string clientRequestId, RequestOptions options)
        {
            return GetConnections(connectionType, defaultConnection, options);
        }

        /// <summary>
        /// [Protocol Method] List all connections in the project, without populating connection credentials
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="connectionType"> List connections of this specific type. </param>
        /// <param name="defaultConnection"> List connections that are default connections. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnectionsAsync(string connectionType, bool? defaultConnection, RequestOptions options) instead.")]
        public virtual AsyncCollectionResult GetConnectionsAsync(string connectionType, bool? defaultConnection, string clientRequestId, RequestOptions options)
        {
            return GetConnectionsAsync(connectionType, defaultConnection, options);
        }

        /// <summary> List all connections in the project, without populating connection credentials. </summary>
        /// <param name="connectionType"> List connections of this specific type. </param>
        /// <param name="defaultConnection"> List connections that are default connections. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnections(ConnectionType? connectionType, bool? defaultConnection, CancellationToken cancellationToken) instead.")]
        public virtual CollectionResult<AIProjectConnection> GetConnections(ConnectionType? connectionType, bool? defaultConnection, string clientRequestId, CancellationToken cancellationToken)
        {
            return GetConnections(connectionType, defaultConnection, cancellationToken);
        }

        /// <summary> List all connections in the project, without populating connection credentials. </summary>
        /// <param name="connectionType"> List connections of this specific type. </param>
        /// <param name="defaultConnection"> List connections that are default connections. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnectionsAsync(ConnectionType? connectionType, bool? defaultConnection, CancellationToken cancellationToken) instead.")]
        public virtual AsyncCollectionResult<AIProjectConnection> GetConnectionsAsync(ConnectionType? connectionType, bool? defaultConnection, string clientRequestId, CancellationToken cancellationToken)
        {
            return GetConnectionsAsync(connectionType, defaultConnection, cancellationToken);
        }
    }
}
