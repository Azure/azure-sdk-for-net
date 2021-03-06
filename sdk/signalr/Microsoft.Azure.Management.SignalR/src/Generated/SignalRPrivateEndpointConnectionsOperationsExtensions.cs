// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.SignalR
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for SignalRPrivateEndpointConnectionsOperations.
    /// </summary>
    public static partial class SignalRPrivateEndpointConnectionsOperationsExtensions
    {
            /// <summary>
            /// List private endpoint connections
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the resource.
            /// </param>
            public static IPage<PrivateEndpointConnection> List(this ISignalRPrivateEndpointConnectionsOperations operations, string resourceGroupName, string resourceName)
            {
                return operations.ListAsync(resourceGroupName, resourceName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// List private endpoint connections
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the resource.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<PrivateEndpointConnection>> ListAsync(this ISignalRPrivateEndpointConnectionsOperations operations, string resourceGroupName, string resourceName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, resourceName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get the specified private endpoint connection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='privateEndpointConnectionName'>
            /// The name of the private endpoint connection
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the resource.
            /// </param>
            public static PrivateEndpointConnection Get(this ISignalRPrivateEndpointConnectionsOperations operations, string privateEndpointConnectionName, string resourceGroupName, string resourceName)
            {
                return operations.GetAsync(privateEndpointConnectionName, resourceGroupName, resourceName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get the specified private endpoint connection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='privateEndpointConnectionName'>
            /// The name of the private endpoint connection
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the resource.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PrivateEndpointConnection> GetAsync(this ISignalRPrivateEndpointConnectionsOperations operations, string privateEndpointConnectionName, string resourceGroupName, string resourceName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(privateEndpointConnectionName, resourceGroupName, resourceName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update the state of specified private endpoint connection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='privateEndpointConnectionName'>
            /// The name of the private endpoint connection
            /// </param>
            /// <param name='parameters'>
            /// The resource of private endpoint and its properties
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the resource.
            /// </param>
            public static PrivateEndpointConnection Update(this ISignalRPrivateEndpointConnectionsOperations operations, string privateEndpointConnectionName, PrivateEndpointConnection parameters, string resourceGroupName, string resourceName)
            {
                return operations.UpdateAsync(privateEndpointConnectionName, parameters, resourceGroupName, resourceName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update the state of specified private endpoint connection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='privateEndpointConnectionName'>
            /// The name of the private endpoint connection
            /// </param>
            /// <param name='parameters'>
            /// The resource of private endpoint and its properties
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the resource.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PrivateEndpointConnection> UpdateAsync(this ISignalRPrivateEndpointConnectionsOperations operations, string privateEndpointConnectionName, PrivateEndpointConnection parameters, string resourceGroupName, string resourceName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(privateEndpointConnectionName, parameters, resourceGroupName, resourceName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete the specified private endpoint connection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='privateEndpointConnectionName'>
            /// The name of the private endpoint connection
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the resource.
            /// </param>
            public static void Delete(this ISignalRPrivateEndpointConnectionsOperations operations, string privateEndpointConnectionName, string resourceGroupName, string resourceName)
            {
                operations.DeleteAsync(privateEndpointConnectionName, resourceGroupName, resourceName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete the specified private endpoint connection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='privateEndpointConnectionName'>
            /// The name of the private endpoint connection
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the resource.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this ISignalRPrivateEndpointConnectionsOperations operations, string privateEndpointConnectionName, string resourceGroupName, string resourceName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(privateEndpointConnectionName, resourceGroupName, resourceName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Delete the specified private endpoint connection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='privateEndpointConnectionName'>
            /// The name of the private endpoint connection
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the resource.
            /// </param>
            public static void BeginDelete(this ISignalRPrivateEndpointConnectionsOperations operations, string privateEndpointConnectionName, string resourceGroupName, string resourceName)
            {
                operations.BeginDeleteAsync(privateEndpointConnectionName, resourceGroupName, resourceName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete the specified private endpoint connection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='privateEndpointConnectionName'>
            /// The name of the private endpoint connection
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group that contains the resource. You can obtain
            /// this value from the Azure Resource Manager API or the portal.
            /// </param>
            /// <param name='resourceName'>
            /// The name of the resource.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this ISignalRPrivateEndpointConnectionsOperations operations, string privateEndpointConnectionName, string resourceGroupName, string resourceName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginDeleteWithHttpMessagesAsync(privateEndpointConnectionName, resourceGroupName, resourceName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// List private endpoint connections
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<PrivateEndpointConnection> ListNext(this ISignalRPrivateEndpointConnectionsOperations operations, string nextPageLink)
            {
                return operations.ListNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// List private endpoint connections
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<PrivateEndpointConnection>> ListNextAsync(this ISignalRPrivateEndpointConnectionsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
