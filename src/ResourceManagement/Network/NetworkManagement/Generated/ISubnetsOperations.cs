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
    public partial interface ISubnetsOperations
    {
        /// <summary>
        /// The delete subnet operation deletes the specified subnet.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkName'>
        /// The name of the virtual network.
        /// </param>
        /// <param name='subnetName'>
        /// The name of the subnet.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The delete subnet operation deletes the specified subnet.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkName'>
        /// The name of the virtual network.
        /// </param>
        /// <param name='subnetName'>
        /// The name of the subnet.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Get subnet operation retreives information about the specified
        /// subnet.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkName'>
        /// The name of the virtual network.
        /// </param>
        /// <param name='subnetName'>
        /// The name of the subnet.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<Subnet>> GetWithOperationResponseAsync(string resourceGroupName, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put Subnet operation creates/updates a subnet in thespecified
        /// virtual network
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkName'>
        /// The name of the virtual network.
        /// </param>
        /// <param name='subnetName'>
        /// The name of the subnet.
        /// </param>
        /// <param name='subnetParameters'>
        /// Parameters supplied to the create/update Subnet operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<Subnet>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string virtualNetworkName, string subnetName, Subnet subnetParameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put Subnet operation creates/updates a subnet in thespecified
        /// virtual network
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkName'>
        /// The name of the virtual network.
        /// </param>
        /// <param name='subnetName'>
        /// The name of the subnet.
        /// </param>
        /// <param name='subnetParameters'>
        /// Parameters supplied to the create/update Subnet operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<Subnet>> BeginCreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string virtualNetworkName, string subnetName, Subnet subnetParameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List subnets opertion retrieves all the subnets in a virtual
        /// network.
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
        Task<AzureOperationResponse<SubnetListResponse>> ListWithOperationResponseAsync(string resourceGroupName, string virtualNetworkName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List subnets opertion retrieves all the subnets in a virtual
        /// network.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<SubnetListResponse>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
