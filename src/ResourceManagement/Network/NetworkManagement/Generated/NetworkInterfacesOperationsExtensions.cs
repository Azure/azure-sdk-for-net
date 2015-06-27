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

    public static partial class NetworkInterfacesOperationsExtensions
    {
            /// <summary>
            /// The delete netwokInterface operation deletes the specified netwokInterface.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkInterfaceName'>
            /// The name of the network interface.
            /// </param>
            public static void Delete(this INetworkInterfacesOperations operations, string resourceGroupName, string networkInterfaceName)
            {
                Task.Factory.StartNew(s => ((INetworkInterfacesOperations)s).DeleteAsync(resourceGroupName, networkInterfaceName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The delete netwokInterface operation deletes the specified netwokInterface.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkInterfaceName'>
            /// The name of the network interface.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAsync( this INetworkInterfacesOperations operations, string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithOperationResponseAsync(resourceGroupName, networkInterfaceName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The delete netwokInterface operation deletes the specified netwokInterface.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkInterfaceName'>
            /// The name of the network interface.
            /// </param>
            public static void BeginDelete(this INetworkInterfacesOperations operations, string resourceGroupName, string networkInterfaceName)
            {
                Task.Factory.StartNew(s => ((INetworkInterfacesOperations)s).BeginDeleteAsync(resourceGroupName, networkInterfaceName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The delete netwokInterface operation deletes the specified netwokInterface.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkInterfaceName'>
            /// The name of the network interface.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync( this INetworkInterfacesOperations operations, string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithOperationResponseAsync(resourceGroupName, networkInterfaceName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The Get ntework interface operation retreives information about the
            /// specified network interface.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkInterfaceName'>
            /// The name of the network interface.
            /// </param>
            public static NetworkInterface Get(this INetworkInterfacesOperations operations, string resourceGroupName, string networkInterfaceName)
            {
                return Task.Factory.StartNew(s => ((INetworkInterfacesOperations)s).GetAsync(resourceGroupName, networkInterfaceName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Get ntework interface operation retreives information about the
            /// specified network interface.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkInterfaceName'>
            /// The name of the network interface.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<NetworkInterface> GetAsync( this INetworkInterfacesOperations operations, string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkInterface> result = await operations.GetWithOperationResponseAsync(resourceGroupName, networkInterfaceName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Put NetworkInterface operation creates/updates a networkInterface
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkInterfaceName'>
            /// The name of the network interface.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create/update NetworkInterface operation
            /// </param>
            public static NetworkInterface CreateOrUpdate(this INetworkInterfacesOperations operations, string resourceGroupName, string networkInterfaceName, NetworkInterface parameters)
            {
                return Task.Factory.StartNew(s => ((INetworkInterfacesOperations)s).CreateOrUpdateAsync(resourceGroupName, networkInterfaceName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put NetworkInterface operation creates/updates a networkInterface
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static async Task<NetworkInterface> CreateOrUpdateAsync( this INetworkInterfacesOperations operations, string resourceGroupName, string networkInterfaceName, NetworkInterface parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkInterface> result = await operations.CreateOrUpdateWithOperationResponseAsync(resourceGroupName, networkInterfaceName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Put NetworkInterface operation creates/updates a networkInterface
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='networkInterfaceName'>
            /// The name of the network interface.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create/update NetworkInterface operation
            /// </param>
            public static NetworkInterface BeginCreateOrUpdate(this INetworkInterfacesOperations operations, string resourceGroupName, string networkInterfaceName, NetworkInterface parameters)
            {
                return Task.Factory.StartNew(s => ((INetworkInterfacesOperations)s).BeginCreateOrUpdateAsync(resourceGroupName, networkInterfaceName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put NetworkInterface operation creates/updates a networkInterface
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static async Task<NetworkInterface> BeginCreateOrUpdateAsync( this INetworkInterfacesOperations operations, string resourceGroupName, string networkInterfaceName, NetworkInterface parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkInterface> result = await operations.BeginCreateOrUpdateWithOperationResponseAsync(resourceGroupName, networkInterfaceName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List networkInterfaces opertion retrieves all the networkInterfaces in
            /// a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            public static NetworkInterfaceListResult ListAll(this INetworkInterfacesOperations operations)
            {
                return Task.Factory.StartNew(s => ((INetworkInterfacesOperations)s).ListAllAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List networkInterfaces opertion retrieves all the networkInterfaces in
            /// a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<NetworkInterfaceListResult> ListAllAsync( this INetworkInterfacesOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkInterfaceListResult> result = await operations.ListAllWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List networkInterfaces opertion retrieves all the networkInterfaces in
            /// a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            public static NetworkInterfaceListResult List(this INetworkInterfacesOperations operations, string resourceGroupName)
            {
                return Task.Factory.StartNew(s => ((INetworkInterfacesOperations)s).ListAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List networkInterfaces opertion retrieves all the networkInterfaces in
            /// a resource group.
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
            public static async Task<NetworkInterfaceListResult> ListAsync( this INetworkInterfacesOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkInterfaceListResult> result = await operations.ListWithOperationResponseAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List networkInterfaces opertion retrieves all the networkInterfaces in
            /// a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static NetworkInterfaceListResult ListAllNext(this INetworkInterfacesOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((INetworkInterfacesOperations)s).ListAllNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List networkInterfaces opertion retrieves all the networkInterfaces in
            /// a subscription.
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
            public static async Task<NetworkInterfaceListResult> ListAllNextAsync( this INetworkInterfacesOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkInterfaceListResult> result = await operations.ListAllNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List networkInterfaces opertion retrieves all the networkInterfaces in
            /// a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static NetworkInterfaceListResult ListNext(this INetworkInterfacesOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((INetworkInterfacesOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List networkInterfaces opertion retrieves all the networkInterfaces in
            /// a resource group.
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
            public static async Task<NetworkInterfaceListResult> ListNextAsync( this INetworkInterfacesOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<NetworkInterfaceListResult> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
