namespace Microsoft.Azure.Management.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface IVirtualNetworkGatewayConnectionsOperations
    {
        /// <summary>
        /// The Put VirtualNetworkGatewayConnection operation creates/updates
        /// a virtual network gateway connection in the specified resource
        /// group through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayConnectionName'>
        /// The name of the virtual network gateway conenction.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Begin Create or update Virtual Network
        /// Gateway connection operation through Network resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualNetworkGatewayConnection>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string virtualNetworkGatewayConnectionName, VirtualNetworkGatewayConnection parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put VirtualNetworkGatewayConnection operation creates/updates
        /// a virtual network gateway connection in the specified resource
        /// group through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayConnectionName'>
        /// The name of the virtual network gateway conenction.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Begin Create or update Virtual Network
        /// Gateway connection operation through Network resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualNetworkGatewayConnection>> BeginCreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string virtualNetworkGatewayConnectionName, VirtualNetworkGatewayConnection parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Get VirtualNetworkGatewayConnection operation retrieves
        /// information about the specified virtual network gateway
        /// connection through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayConnectionName'>
        /// The name of the virtual network gateway connection.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualNetworkGatewayConnection>> GetWithOperationResponseAsync(string resourceGroupName, string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Delete VirtualNetworkGatewayConnection operation deletes the
        /// specifed virtual network Gateway connection through Network
        /// resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayConnectionName'>
        /// The name of the virtual network gateway connection.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Delete VirtualNetworkGatewayConnection operation deletes the
        /// specifed virtual network Gateway connection through Network
        /// resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayConnectionName'>
        /// The name of the virtual network gateway connection.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Get VirtualNetworkGatewayConnectionSharedKey operation
        /// retrieves information about the specified virtual network gateway
        /// connection shared key through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayConnectionName'>
        /// The virtual network gateway connection shared key name.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ConnectionSharedKey>> GetSharedKeyWithOperationResponseAsync(string resourceGroupName, string virtualNetworkGatewayConnectionName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put VirtualNetworkGatewayConnectionSharedKey operation sets
        /// the virtual network gateway connection shared key for passed
        /// virtual network gateway connection in the specified resource
        /// group through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayConnectionName'>
        /// The virtual network gateway connection name.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Begin Set Virtual Network Gateway
        /// conection Shared key operation throughNetwork resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ConnectionSharedKey>> SetSharedKeyWithOperationResponseAsync(string resourceGroupName, string virtualNetworkGatewayConnectionName, ConnectionSharedKey parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put VirtualNetworkGatewayConnectionSharedKey operation sets
        /// the virtual network gateway connection shared key for passed
        /// virtual network gateway connection in the specified resource
        /// group through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayConnectionName'>
        /// The virtual network gateway connection name.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Begin Set Virtual Network Gateway
        /// conection Shared key operation throughNetwork resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ConnectionSharedKey>> BeginSetSharedKeyWithOperationResponseAsync(string resourceGroupName, string virtualNetworkGatewayConnectionName, ConnectionSharedKey parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List VirtualNetworkGatewayConnections operation retrieves all
        /// the virtual network gateways connections created.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualNetworkGatewayConnectionListResponse>> ListWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The VirtualNetworkGatewayConnectionResetSharedKey operation resets
        /// the virtual network gateway connection shared key for passed
        /// virtual network gateway connection in the specified resource
        /// group through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayConnectionName'>
        /// The virtual network gateway connection reset shared key Name.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Begin Reset Virtual Network Gateway
        /// connection shared key operation through Network resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ConnectionResetSharedKey>> ResetSharedKeyWithOperationResponseAsync(string resourceGroupName, string virtualNetworkGatewayConnectionName, ConnectionResetSharedKey parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The VirtualNetworkGatewayConnectionResetSharedKey operation resets
        /// the virtual network gateway connection shared key for passed
        /// virtual network gateway connection in the specified resource
        /// group through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayConnectionName'>
        /// The virtual network gateway connection reset shared key Name.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Begin Reset Virtual Network Gateway
        /// connection shared key operation through Network resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ConnectionResetSharedKey>> BeginResetSharedKeyWithOperationResponseAsync(string resourceGroupName, string virtualNetworkGatewayConnectionName, ConnectionResetSharedKey parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List VirtualNetworkGatewayConnections operation retrieves all
        /// the virtual network gateways connections created.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualNetworkGatewayConnectionListResponse>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
