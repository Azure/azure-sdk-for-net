namespace Microsoft.Azure.Management.Network
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    public static partial class VirtualNetworkGatewayConnectionsOperationsExtensions
    {
            /// <summary>
            /// The Put VirtualNetworkGatewayConnection operation creates/updates a
            /// virtual network gateway connection in the specified resource group
            /// through Network resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway conenction.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Begin Create or update Virtual Network Gateway
            /// connection operation through Network resource provider.
            /// </param>
            public static VirtualNetworkGatewayConnectionPutResponse CreateOrUpdate(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, VirtualNetworkGatewayConnection parameters)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworkGatewayConnectionsOperations)s).CreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayConnectionName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put VirtualNetworkGatewayConnection operation creates/updates a
            /// virtual network gateway connection in the specified resource group
            /// through Network resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway conenction.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Begin Create or update Virtual Network Gateway
            /// connection operation through Network resource provider.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualNetworkGatewayConnectionPutResponse> CreateOrUpdateAsync( this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, VirtualNetworkGatewayConnection parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualNetworkGatewayConnectionPutResponse> result = await operations.CreateOrUpdateWithOperationResponseAsync(resourceGroupName, virtualNetworkGatewayConnectionName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Get VirtualNetworkGatewayConnection operation retrieves information
            /// about the specified virtual network gateway connection through Network
            /// resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            public static VirtualNetworkGatewayConnection Get(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworkGatewayConnectionsOperations)s).GetAsync(resourceGroupName, virtualNetworkGatewayConnectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Get VirtualNetworkGatewayConnection operation retrieves information
            /// about the specified virtual network gateway connection through Network
            /// resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualNetworkGatewayConnection> GetAsync( this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualNetworkGatewayConnection> result = await operations.GetWithOperationResponseAsync(resourceGroupName, virtualNetworkGatewayConnectionName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Delete VirtualNetworkGatewayConnection operation deletes the specifed
            /// virtual network Gateway connection through Network resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            public static void Delete(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName)
            {
                Task.Factory.StartNew(s => ((IVirtualNetworkGatewayConnectionsOperations)s).DeleteAsync(resourceGroupName, virtualNetworkGatewayConnectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Delete VirtualNetworkGatewayConnection operation deletes the specifed
            /// virtual network Gateway connection through Network resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The name of the virtual network gateway connection.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAsync( this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithOperationResponseAsync(resourceGroupName, virtualNetworkGatewayConnectionName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The Get VirtualNetworkGatewayConnectionSharedKey operation retrieves
            /// information about the specified virtual network gateway connection shared
            /// key through Network resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='connectionSharedKeyName'>
            /// The virtual network gateway connection shared key name.
            /// </param>
            public static string GetSharedKey(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string connectionSharedKeyName)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworkGatewayConnectionsOperations)s).GetSharedKeyAsync(resourceGroupName, connectionSharedKeyName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Get VirtualNetworkGatewayConnectionSharedKey operation retrieves
            /// information about the specified virtual network gateway connection shared
            /// key through Network resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='connectionSharedKeyName'>
            /// The virtual network gateway connection shared key name.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<string> GetSharedKeyAsync( this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string connectionSharedKeyName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<string> result = await operations.GetSharedKeyWithOperationResponseAsync(resourceGroupName, connectionSharedKeyName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List VirtualNetworkGatewayConnections operation retrieves all the
            /// virtual network gateways connections created.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            public static VirtualNetworkGatewayConnectionListResponse List(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworkGatewayConnectionsOperations)s).ListAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List VirtualNetworkGatewayConnections operation retrieves all the
            /// virtual network gateways connections created.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualNetworkGatewayConnectionListResponse> ListAsync( this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualNetworkGatewayConnectionListResponse> result = await operations.ListWithOperationResponseAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The VirtualNetworkGatewayConnectionResetSharedKey operation resets the
            /// virtual network gateway connection shared key for passed virtual network
            /// gateway connection in the specified resource group through Network
            /// resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection reset shared key Name.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Begin Reset Virtual Network Gateway connection
            /// shared key operation through Network resource provider.
            /// </param>
            public static ConnectionResetSharedKeyPutResponse ResetSharedKey(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, ConnectionResetSharedKey parameters)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworkGatewayConnectionsOperations)s).ResetSharedKeyAsync(resourceGroupName, virtualNetworkGatewayConnectionName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The VirtualNetworkGatewayConnectionResetSharedKey operation resets the
            /// virtual network gateway connection shared key for passed virtual network
            /// gateway connection in the specified resource group through Network
            /// resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection reset shared key Name.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Begin Reset Virtual Network Gateway connection
            /// shared key operation through Network resource provider.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ConnectionResetSharedKeyPutResponse> ResetSharedKeyAsync( this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, ConnectionResetSharedKey parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ConnectionResetSharedKeyPutResponse> result = await operations.ResetSharedKeyWithOperationResponseAsync(resourceGroupName, virtualNetworkGatewayConnectionName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Put VirtualNetworkGatewayConnectionSharedKey operation sets the
            /// virtual network gateway connection shared key for passed virtual network
            /// gateway connection in the specified resource group through Network
            /// resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection name.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Begin Set Virtual Network Gateway conection
            /// Shared key operation throughNetwork resource provider.
            /// </param>
            public static ConnectionSharedKeyPutResponse SetSharedKey(this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, ConnectionSharedKey parameters)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworkGatewayConnectionsOperations)s).SetSharedKeyAsync(resourceGroupName, virtualNetworkGatewayConnectionName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put VirtualNetworkGatewayConnectionSharedKey operation sets the
            /// virtual network gateway connection shared key for passed virtual network
            /// gateway connection in the specified resource group through Network
            /// resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkGatewayConnectionName'>
            /// The virtual network gateway connection name.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Begin Set Virtual Network Gateway conection
            /// Shared key operation throughNetwork resource provider.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ConnectionSharedKeyPutResponse> SetSharedKeyAsync( this IVirtualNetworkGatewayConnectionsOperations operations, string resourceGroupName, string virtualNetworkGatewayConnectionName, ConnectionSharedKey parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ConnectionSharedKeyPutResponse> result = await operations.SetSharedKeyWithOperationResponseAsync(resourceGroupName, virtualNetworkGatewayConnectionName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List VirtualNetworkGatewayConnections operation retrieves all the
            /// virtual network gateways connections created.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static VirtualNetworkGatewayConnectionListResponse ListNext(this IVirtualNetworkGatewayConnectionsOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworkGatewayConnectionsOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List VirtualNetworkGatewayConnections operation retrieves all the
            /// virtual network gateways connections created.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualNetworkGatewayConnectionListResponse> ListNextAsync( this IVirtualNetworkGatewayConnectionsOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualNetworkGatewayConnectionListResponse> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
