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
                await operations.DeleteWithOperationResponseAsync(resourceGroupName, publicIpAddressName, cancellationToken).ConfigureAwait(false);
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
                AzureOperationResponse<PublicIpAddress> result = await operations.GetWithOperationResponseAsync(resourceGroupName, publicIpAddressName, cancellationToken).ConfigureAwait(false);
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
            public static PublicIpAddressPutResponse CreateOrUpdate(this IPublicIpAddressesOperations operations, string resourceGroupName, string publicIpAddressName, PublicIpAddress parameters)
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
            public static async Task<PublicIpAddressPutResponse> CreateOrUpdateAsync( this IPublicIpAddressesOperations operations, string resourceGroupName, string publicIpAddressName, PublicIpAddress parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<PublicIpAddressPutResponse> result = await operations.CreateOrUpdateWithOperationResponseAsync(resourceGroupName, publicIpAddressName, parameters, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// The List publicIpAddress opertion retrieves all the publicIpAddresses in a
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            public static PublicIpAddressListResponse ListAll(this IPublicIpAddressesOperations operations)
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
            public static async Task<PublicIpAddressListResponse> ListAllAsync( this IPublicIpAddressesOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<PublicIpAddressListResponse> result = await operations.ListAllWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
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
            public static PublicIpAddressListResponse List(this IPublicIpAddressesOperations operations, string resourceGroupName)
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
            public static async Task<PublicIpAddressListResponse> ListAsync( this IPublicIpAddressesOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<PublicIpAddressListResponse> result = await operations.ListWithOperationResponseAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
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
            public static PublicIpAddressListResponse ListAllNext(this IPublicIpAddressesOperations operations, string nextLink)
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
            public static async Task<PublicIpAddressListResponse> ListAllNextAsync( this IPublicIpAddressesOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<PublicIpAddressListResponse> result = await operations.ListAllNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
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
            public static PublicIpAddressListResponse ListNext(this IPublicIpAddressesOperations operations, string nextLink)
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
            public static async Task<PublicIpAddressListResponse> ListNextAsync( this IPublicIpAddressesOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<PublicIpAddressListResponse> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
