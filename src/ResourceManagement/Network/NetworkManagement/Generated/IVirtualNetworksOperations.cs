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
    public partial interface IVirtualNetworksOperations
    {
        /// <summary>
        /// The Delete VirtualNetwork operation deletes the specifed virtual
        /// network
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkName'>
        /// The name of the virtual network.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string virtualNetworkName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Delete VirtualNetwork operation deletes the specifed virtual
        /// network
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkName'>
        /// The name of the virtual network.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, string virtualNetworkName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Get VirtualNetwork operation retrieves information about the
        /// specified virtual network.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkName'>
        /// The name of the virtual network.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualNetwork>> GetWithOperationResponseAsync(string resourceGroupName, string virtualNetworkName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put VirtualNetwork operation creates/updates a virtual network
        /// in the specified resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkName'>
        /// The name of the virtual network.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create/update Virtual Network operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualNetwork>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string virtualNetworkName, VirtualNetwork parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put VirtualNetwork operation creates/updates a virtual network
        /// in the specified resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkName'>
        /// The name of the virtual network.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create/update Virtual Network operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualNetwork>> BeginCreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string virtualNetworkName, VirtualNetwork parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The list VirtualNetwork returns all Virtual Networks in a
        /// subscription
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualNetworkListResult>> ListAllWithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The list VirtualNetwork returns all Virtual Networks in a resource
        /// group
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualNetworkListResult>> ListWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The list VirtualNetwork returns all Virtual Networks in a
        /// subscription
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualNetworkListResult>> ListAllNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The list VirtualNetwork returns all Virtual Networks in a resource
        /// group
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualNetworkListResult>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
