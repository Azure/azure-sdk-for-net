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
    public partial interface ILocalNetworkGatewaysOperations
    {
        /// <summary>
        /// The Put LocalNetworkGateway operation creates/updates a local
        /// network gateway in the specified resource group through Network
        /// resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='localNetworkGatewayName'>
        /// The name of the local network gateway.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Begin Create or update Local Network
        /// Gateway operation through Network resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LocalNetworkGateway>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string localNetworkGatewayName, LocalNetworkGateway parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put LocalNetworkGateway operation creates/updates a local
        /// network gateway in the specified resource group through Network
        /// resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='localNetworkGatewayName'>
        /// The name of the local network gateway.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Begin Create or update Local Network
        /// Gateway operation through Network resource provider.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LocalNetworkGateway>> BeginCreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string localNetworkGatewayName, LocalNetworkGateway parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Get LocalNetworkGateway operation retrieves information about
        /// the specified local network gateway through Network resource
        /// provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='localNetworkGatewayName'>
        /// The name of the local network gateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LocalNetworkGateway>> GetWithOperationResponseAsync(string resourceGroupName, string localNetworkGatewayName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Delete LocalNetworkGateway operation deletes the specifed
        /// local network Gateway through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='localNetworkGatewayName'>
        /// The name of the local network gateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string localNetworkGatewayName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Delete LocalNetworkGateway operation deletes the specifed
        /// local network Gateway through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='localNetworkGatewayName'>
        /// The name of the local network gateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, string localNetworkGatewayName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List LocalNetworkGateways opertion retrieves all the local
        /// network gateways stored.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LocalNetworkGatewayListResult>> ListWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List LocalNetworkGateways opertion retrieves all the local
        /// network gateways stored.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LocalNetworkGatewayListResult>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
