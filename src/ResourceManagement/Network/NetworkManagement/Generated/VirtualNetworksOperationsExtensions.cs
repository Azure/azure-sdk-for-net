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

    public static partial class VirtualNetworksOperationsExtensions
    {
            /// <summary>
            /// The Delete VirtualNetwork operation deletes the specifed virtual network
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkName'>
            /// The name of the virtual network.
            /// </param>
            public static void Delete(this IVirtualNetworksOperations operations, string resourceGroupName, string virtualNetworkName)
            {
                Task.Factory.StartNew(s => ((IVirtualNetworksOperations)s).DeleteAsync(resourceGroupName, virtualNetworkName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Delete VirtualNetwork operation deletes the specifed virtual network
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkName'>
            /// The name of the virtual network.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAsync( this IVirtualNetworksOperations operations, string resourceGroupName, string virtualNetworkName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithOperationResponseAsync(resourceGroupName, virtualNetworkName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The Get VirtualNetwork operation retrieves information about the specified
            /// virtual network.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkName'>
            /// The name of the virtual network.
            /// </param>
            public static VirtualNetwork Get(this IVirtualNetworksOperations operations, string resourceGroupName, string virtualNetworkName)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworksOperations)s).GetAsync(resourceGroupName, virtualNetworkName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Get VirtualNetwork operation retrieves information about the specified
            /// virtual network.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkName'>
            /// The name of the virtual network.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualNetwork> GetAsync( this IVirtualNetworksOperations operations, string resourceGroupName, string virtualNetworkName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualNetwork> result = await operations.GetWithOperationResponseAsync(resourceGroupName, virtualNetworkName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Put VirtualNetwork operation creates/updates a virtual network in the
            /// specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='virtualNetworkName'>
            /// The name of the virtual network.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create/update Virtual Network operation
            /// </param>
            public static VirtualNetworkPutResponse CreateOrUpdate(this IVirtualNetworksOperations operations, string resourceGroupName, string virtualNetworkName, VirtualNetwork parameters)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworksOperations)s).CreateOrUpdateAsync(resourceGroupName, virtualNetworkName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put VirtualNetwork operation creates/updates a virtual network in the
            /// specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static async Task<VirtualNetworkPutResponse> CreateOrUpdateAsync( this IVirtualNetworksOperations operations, string resourceGroupName, string virtualNetworkName, VirtualNetwork parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualNetworkPutResponse> result = await operations.CreateOrUpdateWithOperationResponseAsync(resourceGroupName, virtualNetworkName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The list VirtualNetwork returns all Virtual Networks in a subscription
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            public static VirtualNetworkListResponse ListAll(this IVirtualNetworksOperations operations)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworksOperations)s).ListAllAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The list VirtualNetwork returns all Virtual Networks in a subscription
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualNetworkListResponse> ListAllAsync( this IVirtualNetworksOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualNetworkListResponse> result = await operations.ListAllWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The list VirtualNetwork returns all Virtual Networks in a resource group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            public static VirtualNetworkListResponse List(this IVirtualNetworksOperations operations, string resourceGroupName)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworksOperations)s).ListAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The list VirtualNetwork returns all Virtual Networks in a resource group
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
            public static async Task<VirtualNetworkListResponse> ListAsync( this IVirtualNetworksOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualNetworkListResponse> result = await operations.ListWithOperationResponseAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The list VirtualNetwork returns all Virtual Networks in a subscription
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static VirtualNetworkListResponse ListAllNext(this IVirtualNetworksOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworksOperations)s).ListAllNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The list VirtualNetwork returns all Virtual Networks in a subscription
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
            public static async Task<VirtualNetworkListResponse> ListAllNextAsync( this IVirtualNetworksOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualNetworkListResponse> result = await operations.ListAllNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The list VirtualNetwork returns all Virtual Networks in a resource group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static VirtualNetworkListResponse ListNext(this IVirtualNetworksOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IVirtualNetworksOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The list VirtualNetwork returns all Virtual Networks in a resource group
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
            public static async Task<VirtualNetworkListResponse> ListNextAsync( this IVirtualNetworksOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualNetworkListResponse> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
