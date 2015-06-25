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
    public partial interface INetworkSecurityGroupsOperations
    {
        /// <summary>
        /// The Delete NetworkSecurityGroup operation deletes the specifed
        /// network security group
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkSecurityGroupName'>
        /// The name of the network security group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string networkSecurityGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Delete NetworkSecurityGroup operation deletes the specifed
        /// network security group
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkSecurityGroupName'>
        /// The name of the network security group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, string networkSecurityGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Get NetworkSecurityGroups operation retrieves information
        /// about the specified network security group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkSecurityGroupName'>
        /// The name of the network security group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkSecurityGroup>> GetWithOperationResponseAsync(string resourceGroupName, string networkSecurityGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put NetworkSecurityGroup operation creates/updates a network
        /// security groupin the specified resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkSecurityGroupName'>
        /// The name of the network security group.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create/update Network Security Group
        /// operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkSecurityGroup>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string networkSecurityGroupName, NetworkSecurityGroup parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put NetworkSecurityGroup operation creates/updates a network
        /// security groupin the specified resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkSecurityGroupName'>
        /// The name of the network security group.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create/update Network Security Group
        /// operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkSecurityGroup>> BeginCreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string networkSecurityGroupName, NetworkSecurityGroup parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The list NetworkSecurityGroups returns all network security groups
        /// in a subscription
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkSecurityGroupListResponse>> ListAllWithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The list NetworkSecurityGroups returns all network security groups
        /// in a resource group
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkSecurityGroupListResponse>> ListWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The list NetworkSecurityGroups returns all network security groups
        /// in a subscription
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkSecurityGroupListResponse>> ListAllNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The list NetworkSecurityGroups returns all network security groups
        /// in a resource group
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<NetworkSecurityGroupListResponse>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
