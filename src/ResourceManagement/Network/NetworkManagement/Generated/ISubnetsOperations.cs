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
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string virtualNetworkName, string subnetName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string virtualNetworkName, string subnetName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<Subnet>> GetWithHttpMessagesAsync(string resourceGroupName, string virtualNetworkName, string subnetName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<Subnet>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string virtualNetworkName, string subnetName, Subnet subnetParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<Subnet>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string virtualNetworkName, string subnetName, Subnet subnetParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<SubnetListResult>> ListWithHttpMessagesAsync(string resourceGroupName, string virtualNetworkName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List subnets opertion retrieves all the subnets in a virtual
        /// network.
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
        Task<AzureOperationResponse<SubnetListResult>> ListNextWithHttpMessagesAsync(string nextLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
