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
    public partial interface INetworkInterfacesOperations
    {
        /// <summary>
        /// The delete netwokInterface operation deletes the specified
        /// netwokInterface.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkInterfaceName'>
        /// The name of the network interface.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The delete netwokInterface operation deletes the specified
        /// netwokInterface.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkInterfaceName'>
        /// The name of the network interface.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Get ntework interface operation retreives information about
        /// the specified network interface.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkInterfaceName'>
        /// The name of the network interface.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkInterface>> GetWithOperationResponseAsync(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put NetworkInterface operation creates/updates a
        /// networkInterface
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkInterfaceName'>
        /// The name of the network interface.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create/update NetworkInterface operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkInterface>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string networkInterfaceName, NetworkInterface parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put NetworkInterface operation creates/updates a
        /// networkInterface
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkInterfaceName'>
        /// The name of the network interface.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create/update NetworkInterface operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkInterface>> BeginCreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string networkInterfaceName, NetworkInterface parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List networkInterfaces opertion retrieves all the
        /// networkInterfaces in a subscription.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkInterfaceListResult>> ListAllWithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List networkInterfaces opertion retrieves all the
        /// networkInterfaces in a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkInterfaceListResult>> ListWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List networkInterfaces opertion retrieves all the
        /// networkInterfaces in a subscription.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkInterfaceListResult>> ListAllNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List networkInterfaces opertion retrieves all the
        /// networkInterfaces in a resource group.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkInterfaceListResult>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
