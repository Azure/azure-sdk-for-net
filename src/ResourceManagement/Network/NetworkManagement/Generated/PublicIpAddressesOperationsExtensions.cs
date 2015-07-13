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

    public static partial class PublicIpAddressesOperationsExtensions
    {
            /// <summary>
            /// The delete publicIpAddress operation deletes the specified publicIpAddress.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='publicIpAddressName'>
            /// The name of the subnet.
            /// </param>
            public static void Delete(this IPublicIpAddressesOperations operations, string resourceGroupName, string publicIpAddressName)
            {
                Task.Factory.StartNew(s => ((IPublicIpAddressesOperations)s).DeleteAsync(resourceGroupName, publicIpAddressName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The delete publicIpAddress operation deletes the specified publicIpAddress.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='publicIpAddressName'>
            /// The name of the subnet.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task DeleteAsync( this IPublicIpAddressesOperations operations, string resourceGroupName, string publicIpAddressName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(resourceGroupName, publicIpAddressName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The delete publicIpAddress operation deletes the specified publicIpAddress.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='publicIpAddressName'>
            /// The name of the subnet.
            /// </param>
            public static void BeginDelete(this IPublicIpAddressesOperations operations, string resourceGroupName, string publicIpAddressName)
            {
                Task.Factory.StartNew(s => ((IPublicIpAddressesOperations)s).BeginDeleteAsync(resourceGroupName, publicIpAddressName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The delete publicIpAddress operation deletes the specified publicIpAddress.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='publicIpAddressName'>
            /// The name of the subnet.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync( this IPublicIpAddressesOperations operations, string resourceGroupName, string publicIpAddressName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, publicIpAddressName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// The Get publicIpAddress operation retreives information about the
            /// specified pubicIpAddress
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='publicIpAddressName'>
            /// The name of the subnet.
            /// </param>
            public static PublicIpAddress Get(this IPublicIpAddressesOperations operations, string resourceGroupName, string publicIpAddressName)
            {
                return Task.Factory.StartNew(s => ((IPublicIpAddressesOperations)s).GetAsync(resourceGroupName, publicIpAddressName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Get publicIpAddress operation retreives information about the
            /// specified pubicIpAddress
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='publicIpAddressName'>
            /// The name of the subnet.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<PublicIpAddress> GetAsync( this IPublicIpAddressesOperations operations, string resourceGroupName, string publicIpAddressName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<PublicIpAddress> result = await operations.GetWithHttpMessagesAsync(resourceGroupName, publicIpAddressName, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Put PublicIPAddress operation creates/updates a stable/dynamic
            /// PublicIP address
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='publicIpAddressName'>
            /// The name of the publicIpAddress.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create/update PublicIPAddress operation
            /// </param>
            public static PublicIpAddress CreateOrUpdate(this IPublicIpAddressesOperations operations, string resourceGroupName, string publicIpAddressName, PublicIpAddress parameters)
            {
                return Task.Factory.StartNew(s => ((IPublicIpAddressesOperations)s).CreateOrUpdateAsync(resourceGroupName, publicIpAddressName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put PublicIPAddress operation creates/updates a stable/dynamic
            /// PublicIP address
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static async Task<PublicIpAddress> CreateOrUpdateAsync( this IPublicIpAddressesOperations operations, string resourceGroupName, string publicIpAddressName, PublicIpAddress parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<PublicIpAddress> result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, publicIpAddressName, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The Put PublicIPAddress operation creates/updates a stable/dynamic
            /// PublicIP address
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            /// <param name='publicIpAddressName'>
            /// The name of the publicIpAddress.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create/update PublicIPAddress operation
            /// </param>
            public static PublicIpAddress BeginCreateOrUpdate(this IPublicIpAddressesOperations operations, string resourceGroupName, string publicIpAddressName, PublicIpAddress parameters)
            {
                return Task.Factory.StartNew(s => ((IPublicIpAddressesOperations)s).BeginCreateOrUpdateAsync(resourceGroupName, publicIpAddressName, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The Put PublicIPAddress operation creates/updates a stable/dynamic
            /// PublicIP address
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static async Task<PublicIpAddress> BeginCreateOrUpdateAsync( this IPublicIpAddressesOperations operations, string resourceGroupName, string publicIpAddressName, PublicIpAddress parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<PublicIpAddress> result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, publicIpAddressName, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List publicIpAddress opertion retrieves all the publicIpAddresses in a
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            public static PublicIpAddressListResult ListAll(this IPublicIpAddressesOperations operations)
            {
                return Task.Factory.StartNew(s => ((IPublicIpAddressesOperations)s).ListAllAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List publicIpAddress opertion retrieves all the publicIpAddresses in a
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<PublicIpAddressListResult> ListAllAsync( this IPublicIpAddressesOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<PublicIpAddressListResult> result = await operations.ListAllWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List publicIpAddress opertion retrieves all the publicIpAddresses in a
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group.
            /// </param>
            public static PublicIpAddressListResult List(this IPublicIpAddressesOperations operations, string resourceGroupName)
            {
                return Task.Factory.StartNew(s => ((IPublicIpAddressesOperations)s).ListAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List publicIpAddress opertion retrieves all the publicIpAddresses in a
            /// resource group.
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
            public static async Task<PublicIpAddressListResult> ListAsync( this IPublicIpAddressesOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<PublicIpAddressListResult> result = await operations.ListWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List publicIpAddress opertion retrieves all the publicIpAddresses in a
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static PublicIpAddressListResult ListAllNext(this IPublicIpAddressesOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IPublicIpAddressesOperations)s).ListAllNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List publicIpAddress opertion retrieves all the publicIpAddresses in a
            /// subscription.
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
            public static async Task<PublicIpAddressListResult> ListAllNextAsync( this IPublicIpAddressesOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<PublicIpAddressListResult> result = await operations.ListAllNextWithHttpMessagesAsync(nextLink, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List publicIpAddress opertion retrieves all the publicIpAddresses in a
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static PublicIpAddressListResult ListNext(this IPublicIpAddressesOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IPublicIpAddressesOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// The List publicIpAddress opertion retrieves all the publicIpAddresses in a
            /// resource group.
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
            public static async Task<PublicIpAddressListResult> ListNextAsync( this IPublicIpAddressesOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<PublicIpAddressListResult> result = await operations.ListNextWithHttpMessagesAsync(nextLink, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
