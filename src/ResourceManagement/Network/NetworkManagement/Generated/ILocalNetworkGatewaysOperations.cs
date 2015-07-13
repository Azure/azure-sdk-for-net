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
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LocalNetworkGateway>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string localNetworkGatewayName, LocalNetworkGateway parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LocalNetworkGateway>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string localNetworkGatewayName, LocalNetworkGateway parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LocalNetworkGateway>> GetWithHttpMessagesAsync(string resourceGroupName, string localNetworkGatewayName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string localNetworkGatewayName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string localNetworkGatewayName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List LocalNetworkGateways opertion retrieves all the local
        /// network gateways stored.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LocalNetworkGatewayListResult>> ListWithHttpMessagesAsync(string resourceGroupName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List LocalNetworkGateways opertion retrieves all the local
        /// network gateways stored.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<LocalNetworkGatewayListResult>> ListNextWithHttpMessagesAsync(string nextLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
