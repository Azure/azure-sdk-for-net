// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.DigitalTwins
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for PrivateEndpointConnectionsOperations.
    /// </summary>
    public static partial class PrivateEndpointConnectionsOperationsExtensions
    {
            /// <summary>
            /// Update the status of a private endpoint connection with the given name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the DigitalTwinsInstance.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the DigitalTwinsInstance.
            /// </param>
            /// <param name='privateEndpointConnectionName'>
            /// The name of the private endpoint connection.
            /// </param>
            /// <param name='properties'>
            /// The connection properties.
            /// </param>
            public static PrivateEndpointConnection CreateOrUpdate(this IPrivateEndpointConnectionsOperations operations, string resourceGroupName, string resourceName, string privateEndpointConnectionName, PrivateEndpointConnectionProperties properties)
            {
                return operations.CreateOrUpdateAsync(resourceGroupName, resourceName, privateEndpointConnectionName, properties).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update the status of a private endpoint connection with the given name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the DigitalTwinsInstance.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the DigitalTwinsInstance.
            /// </param>
            /// <param name='privateEndpointConnectionName'>
            /// The name of the private endpoint connection.
            /// </param>
            /// <param name='properties'>
            /// The connection properties.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PrivateEndpointConnection> CreateOrUpdateAsync(this IPrivateEndpointConnectionsOperations operations, string resourceGroupName, string resourceName, string privateEndpointConnectionName, PrivateEndpointConnectionProperties properties, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, resourceName, privateEndpointConnectionName, properties, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update the status of a private endpoint connection with the given name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the DigitalTwinsInstance.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the DigitalTwinsInstance.
            /// </param>
            /// <param name='privateEndpointConnectionName'>
            /// The name of the private endpoint connection.
            /// </param>
            /// <param name='properties'>
            /// The connection properties.
            /// </param>
            public static PrivateEndpointConnection BeginCreateOrUpdate(this IPrivateEndpointConnectionsOperations operations, string resourceGroupName, string resourceName, string privateEndpointConnectionName, PrivateEndpointConnectionProperties properties)
            {
                return operations.BeginCreateOrUpdateAsync(resourceGroupName, resourceName, privateEndpointConnectionName, properties).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update the status of a private endpoint connection with the given name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the DigitalTwinsInstance.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the DigitalTwinsInstance.
            /// </param>
            /// <param name='privateEndpointConnectionName'>
            /// The name of the private endpoint connection.
            /// </param>
            /// <param name='properties'>
            /// The connection properties.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PrivateEndpointConnection> BeginCreateOrUpdateAsync(this IPrivateEndpointConnectionsOperations operations, string resourceGroupName, string resourceName, string privateEndpointConnectionName, PrivateEndpointConnectionProperties properties, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, resourceName, privateEndpointConnectionName, properties, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
