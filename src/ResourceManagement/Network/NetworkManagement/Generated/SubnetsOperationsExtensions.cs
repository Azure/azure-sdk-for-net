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

    public static partial class SubnetsOperationsExtensions
    {
            /// <summary>
            /// The delete subnet operation deletes the specified subnet.
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
            /// <param name='subnetName'>
            /// The name of the subnet.
            /// </param>
            public static void Delete(this ISubnetsOperations operations, string resourceGroupName, string virtualNetworkName, string subnetName)
            {
                Task.Factory.StartNew(s => ((ISubnetsOperations)s).DeleteAsync(resourceGroupName, virtualNetworkName, subnetName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The delete subnet operation deletes the specified subnet.
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
            /// <param name='subnetName'>
            /// The name of the subnet.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAsync( this ISubnetsOperations operations, string resourceGroupName, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithOperationResponseAsync(resourceGroupName, virtualNetworkName, subnetName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The delete subnet operation deletes the specified subnet.
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
            /// <param name='subnetName'>
            /// The name of the subnet.
            /// </param>
            public static void BeginDelete(this ISubnetsOperations operations, string resourceGroupName, string virtualNetworkName, string subnetName)
            {
                Task.Factory.StartNew(s => ((ISubnetsOperations)s).BeginDeleteAsync(resourceGroupName, virtualNetworkName, subnetName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The delete subnet operation deletes the specified subnet.
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
            /// <param name='subnetName'>
            /// The name of the subnet.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync( this ISubnetsOperations operations, string resourceGroupName, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithOperationResponseAsync(resourceGroupName, virtualNetworkName, subnetName, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The Get subnet operation retreives information about the specified subnet.
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
            /// <param name='subnetName'>
            /// The name of the subnet.
            /// </param>
            public static Subnet Get(this ISubnetsOperations operations, string resourceGroupName, string virtualNetworkName, string subnetName)
            {
                return Task.Factory.StartNew(s => ((ISubnetsOperations)s).GetAsync(resourceGroupName, virtualNetworkName, subnetName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Get subnet operation retreives information about the specified subnet.
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
            /// <param name='subnetName'>
            /// The name of the subnet.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Subnet> GetAsync( this ISubnetsOperations operations, string resourceGroupName, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Subnet> result = await operations.GetWithOperationResponseAsync(resourceGroupName, virtualNetworkName, subnetName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Put Subnet operation creates/updates a subnet in thespecified virtual
            /// network
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
            /// <param name='subnetName'>
            /// The name of the subnet.
            /// </param>
            /// <param name='subnetParameters'>
            /// Parameters supplied to the create/update Subnet operation
            /// </param>
            public static Subnet CreateOrUpdate(this ISubnetsOperations operations, string resourceGroupName, string virtualNetworkName, string subnetName, Subnet subnetParameters)
            {
                return Task.Factory.StartNew(s => ((ISubnetsOperations)s).CreateOrUpdateAsync(resourceGroupName, virtualNetworkName, subnetName, subnetParameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put Subnet operation creates/updates a subnet in thespecified virtual
            /// network
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
            /// <param name='subnetName'>
            /// The name of the subnet.
            /// </param>
            /// <param name='subnetParameters'>
            /// Parameters supplied to the create/update Subnet operation
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Subnet> CreateOrUpdateAsync( this ISubnetsOperations operations, string resourceGroupName, string virtualNetworkName, string subnetName, Subnet subnetParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Subnet> result = await operations.CreateOrUpdateWithOperationResponseAsync(resourceGroupName, virtualNetworkName, subnetName, subnetParameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Put Subnet operation creates/updates a subnet in thespecified virtual
            /// network
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
            /// <param name='subnetName'>
            /// The name of the subnet.
            /// </param>
            /// <param name='subnetParameters'>
            /// Parameters supplied to the create/update Subnet operation
            /// </param>
            public static Subnet BeginCreateOrUpdate(this ISubnetsOperations operations, string resourceGroupName, string virtualNetworkName, string subnetName, Subnet subnetParameters)
            {
                return Task.Factory.StartNew(s => ((ISubnetsOperations)s).BeginCreateOrUpdateAsync(resourceGroupName, virtualNetworkName, subnetName, subnetParameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put Subnet operation creates/updates a subnet in thespecified virtual
            /// network
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
            /// <param name='subnetName'>
            /// The name of the subnet.
            /// </param>
            /// <param name='subnetParameters'>
            /// Parameters supplied to the create/update Subnet operation
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Subnet> BeginCreateOrUpdateAsync( this ISubnetsOperations operations, string resourceGroupName, string virtualNetworkName, string subnetName, Subnet subnetParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Subnet> result = await operations.BeginCreateOrUpdateWithOperationResponseAsync(resourceGroupName, virtualNetworkName, subnetName, subnetParameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List subnets opertion retrieves all the subnets in a virtual network.
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
            public static SubnetListResult List(this ISubnetsOperations operations, string resourceGroupName, string virtualNetworkName)
            {
                return Task.Factory.StartNew(s => ((ISubnetsOperations)s).ListAsync(resourceGroupName, virtualNetworkName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List subnets opertion retrieves all the subnets in a virtual network.
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
            public static async Task<SubnetListResult> ListAsync( this ISubnetsOperations operations, string resourceGroupName, string virtualNetworkName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<SubnetListResult> result = await operations.ListWithOperationResponseAsync(resourceGroupName, virtualNetworkName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List subnets opertion retrieves all the subnets in a virtual network.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static SubnetListResult ListNext(this ISubnetsOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((ISubnetsOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List subnets opertion retrieves all the subnets in a virtual network.
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
            public static async Task<SubnetListResult> ListNextAsync( this ISubnetsOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<SubnetListResult> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
