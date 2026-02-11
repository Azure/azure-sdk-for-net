// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;

namespace Azure.AI.Projects
{
    public partial class AIProjectConnectionsOperations
    {
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
