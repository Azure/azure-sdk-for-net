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
    public partial interface IPublicIpAddressesOperations
    {
        /// <summary>
        /// The delete publicIpAddress operation deletes the specified
        /// publicIpAddress.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='publicIpAddressName'>
        /// The name of the subnet.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string publicIpAddressName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The delete publicIpAddress operation deletes the specified
        /// publicIpAddress.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='publicIpAddressName'>
        /// The name of the subnet.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, string publicIpAddressName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Get publicIpAddress operation retreives information about the
        /// specified pubicIpAddress
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='publicIpAddressName'>
        /// The name of the subnet.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<PublicIpAddress>> GetWithOperationResponseAsync(string resourceGroupName, string publicIpAddressName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put PublicIPAddress operation creates/updates a stable/dynamic
        /// PublicIP address
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='publicIpAddressName'>
        /// The name of the publicIpAddress.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create/update PublicIPAddress operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<PublicIpAddress>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string publicIpAddressName, PublicIpAddress parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put PublicIPAddress operation creates/updates a stable/dynamic
        /// PublicIP address
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='publicIpAddressName'>
        /// The name of the publicIpAddress.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create/update PublicIPAddress operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<PublicIpAddress>> BeginCreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string publicIpAddressName, PublicIpAddress parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List publicIpAddress opertion retrieves all the
        /// publicIpAddresses in a subscription.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<PublicIpAddressListResponse>> ListAllWithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List publicIpAddress opertion retrieves all the
        /// publicIpAddresses in a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<PublicIpAddressListResponse>> ListWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List publicIpAddress opertion retrieves all the
        /// publicIpAddresses in a subscription.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<PublicIpAddressListResponse>> ListAllNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List publicIpAddress opertion retrieves all the
        /// publicIpAddresses in a resource group.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<PublicIpAddressListResponse>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
