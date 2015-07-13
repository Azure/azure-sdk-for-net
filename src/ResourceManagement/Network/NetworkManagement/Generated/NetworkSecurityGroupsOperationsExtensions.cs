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

    public static partial class NetworkSecurityGroupsOperationsExtensions
    {
            /// <summary>
            /// The Delete NetworkSecurityGroup operation deletes the specifed network
            /// security group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkSecurityGroupName'>
            /// The name of the network security group.
            /// </param>
            public static void Delete(this INetworkSecurityGroupsOperations operations, string resourceGroupName, string networkSecurityGroupName)
            {
                Task.Factory.StartNew(s => ((INetworkSecurityGroupsOperations)s).DeleteAsync(resourceGroupName, networkSecurityGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Delete NetworkSecurityGroup operation deletes the specifed network
            /// security group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkSecurityGroupName'>
            /// The name of the network security group.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAsync( this INetworkSecurityGroupsOperations operations, string resourceGroupName, string networkSecurityGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(resourceGroupName, networkSecurityGroupName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The Delete NetworkSecurityGroup operation deletes the specifed network
            /// security group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkSecurityGroupName'>
            /// The name of the network security group.
            /// </param>
            public static void BeginDelete(this INetworkSecurityGroupsOperations operations, string resourceGroupName, string networkSecurityGroupName)
            {
                Task.Factory.StartNew(s => ((INetworkSecurityGroupsOperations)s).BeginDeleteAsync(resourceGroupName, networkSecurityGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Delete NetworkSecurityGroup operation deletes the specifed network
            /// security group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkSecurityGroupName'>
            /// The name of the network security group.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync( this INetworkSecurityGroupsOperations operations, string resourceGroupName, string networkSecurityGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, networkSecurityGroupName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The Get NetworkSecurityGroups operation retrieves information about the
            /// specified network security group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkSecurityGroupName'>
            /// The name of the network security group.
            /// </param>
            public static NetworkSecurityGroup Get(this INetworkSecurityGroupsOperations operations, string resourceGroupName, string networkSecurityGroupName)
            {
                return Task.Factory.StartNew(s => ((INetworkSecurityGroupsOperations)s).GetAsync(resourceGroupName, networkSecurityGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Get NetworkSecurityGroups operation retrieves information about the
            /// specified network security group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkSecurityGroupName'>
            /// The name of the network security group.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<NetworkSecurityGroup> GetAsync( this INetworkSecurityGroupsOperations operations, string resourceGroupName, string networkSecurityGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkSecurityGroup> result = await operations.GetWithHttpMessagesAsync(resourceGroupName, networkSecurityGroupName, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Put NetworkSecurityGroup operation creates/updates a network security
            /// groupin the specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkSecurityGroupName'>
            /// The name of the network security group.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create/update Network Security Group operation
            /// </param>
            public static NetworkSecurityGroup CreateOrUpdate(this INetworkSecurityGroupsOperations operations, string resourceGroupName, string networkSecurityGroupName, NetworkSecurityGroup parameters)
            {
                return Task.Factory.StartNew(s => ((INetworkSecurityGroupsOperations)s).CreateOrUpdateAsync(resourceGroupName, networkSecurityGroupName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put NetworkSecurityGroup operation creates/updates a network security
            /// groupin the specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkSecurityGroupName'>
            /// The name of the network security group.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create/update Network Security Group operation
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<NetworkSecurityGroup> CreateOrUpdateAsync( this INetworkSecurityGroupsOperations operations, string resourceGroupName, string networkSecurityGroupName, NetworkSecurityGroup parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkSecurityGroup> result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, networkSecurityGroupName, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Put NetworkSecurityGroup operation creates/updates a network security
            /// groupin the specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkSecurityGroupName'>
            /// The name of the network security group.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create/update Network Security Group operation
            /// </param>
            public static NetworkSecurityGroup BeginCreateOrUpdate(this INetworkSecurityGroupsOperations operations, string resourceGroupName, string networkSecurityGroupName, NetworkSecurityGroup parameters)
            {
                return Task.Factory.StartNew(s => ((INetworkSecurityGroupsOperations)s).BeginCreateOrUpdateAsync(resourceGroupName, networkSecurityGroupName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put NetworkSecurityGroup operation creates/updates a network security
            /// groupin the specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkSecurityGroupName'>
            /// The name of the network security group.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create/update Network Security Group operation
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<NetworkSecurityGroup> BeginCreateOrUpdateAsync( this INetworkSecurityGroupsOperations operations, string resourceGroupName, string networkSecurityGroupName, NetworkSecurityGroup parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkSecurityGroup> result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, networkSecurityGroupName, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The list NetworkSecurityGroups returns all network security groups in a
            /// subscription
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            public static NetworkSecurityGroupListResult ListAll(this INetworkSecurityGroupsOperations operations)
            {
                return Task.Factory.StartNew(s => ((INetworkSecurityGroupsOperations)s).ListAllAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The list NetworkSecurityGroups returns all network security groups in a
            /// subscription
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<NetworkSecurityGroupListResult> ListAllAsync( this INetworkSecurityGroupsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkSecurityGroupListResult> result = await operations.ListAllWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The list NetworkSecurityGroups returns all network security groups in a
            /// resource group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            public static NetworkSecurityGroupListResult List(this INetworkSecurityGroupsOperations operations, string resourceGroupName)
            {
                return Task.Factory.StartNew(s => ((INetworkSecurityGroupsOperations)s).ListAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The list NetworkSecurityGroups returns all network security groups in a
            /// resource group
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
            public static async Task<NetworkSecurityGroupListResult> ListAsync( this INetworkSecurityGroupsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkSecurityGroupListResult> result = await operations.ListWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The list NetworkSecurityGroups returns all network security groups in a
            /// subscription
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static NetworkSecurityGroupListResult ListAllNext(this INetworkSecurityGroupsOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((INetworkSecurityGroupsOperations)s).ListAllNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The list NetworkSecurityGroups returns all network security groups in a
            /// subscription
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
            public static async Task<NetworkSecurityGroupListResult> ListAllNextAsync( this INetworkSecurityGroupsOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkSecurityGroupListResult> result = await operations.ListAllNextWithHttpMessagesAsync(nextLink, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The list NetworkSecurityGroups returns all network security groups in a
            /// resource group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static NetworkSecurityGroupListResult ListNext(this INetworkSecurityGroupsOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((INetworkSecurityGroupsOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The list NetworkSecurityGroups returns all network security groups in a
            /// resource group
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
            public static async Task<NetworkSecurityGroupListResult> ListNextAsync( this INetworkSecurityGroupsOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkSecurityGroupListResult> result = await operations.ListNextWithHttpMessagesAsync(nextLink, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
