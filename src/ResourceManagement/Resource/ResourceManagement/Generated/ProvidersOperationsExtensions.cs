namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq.Expressions;
    using Microsoft.Rest.Azure;
    using Models;

    public static partial class ProvidersOperationsExtensions
    {
            /// <summary>
            /// Unregisters provider from a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            public static Provider Unregister(this IProvidersOperations operations, string resourceProviderNamespace)
            {
                return Task.Factory.StartNew(s => ((IProvidersOperations)s).UnregisterAsync(resourceProviderNamespace), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Unregisters provider from a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Provider> UnregisterAsync( this IProvidersOperations operations, string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Provider> result = await operations.UnregisterWithHttpMessagesAsync(resourceProviderNamespace, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Registers provider to be used with a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            public static Provider Register(this IProvidersOperations operations, string resourceProviderNamespace)
            {
                return Task.Factory.StartNew(s => ((IProvidersOperations)s).RegisterAsync(resourceProviderNamespace), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Registers provider to be used with a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Provider> RegisterAsync( this IProvidersOperations operations, string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Provider> result = await operations.RegisterWithHttpMessagesAsync(resourceProviderNamespace, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of resource providers.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns all deployments.
            /// </param>
            public static Page<Provider> List(this IProvidersOperations operations, int? top = default(int?))
            {
                return Task.Factory.StartNew(s => ((IProvidersOperations)s).ListAsync(top), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of resource providers.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns all deployments.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Page<Provider>> ListAsync( this IProvidersOperations operations, int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Page<Provider>> result = await operations.ListWithHttpMessagesAsync(top, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            public static Provider Get(this IProvidersOperations operations, string resourceProviderNamespace)
            {
                return Task.Factory.StartNew(s => ((IProvidersOperations)s).GetAsync(resourceProviderNamespace), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Provider> GetAsync( this IProvidersOperations operations, string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Provider> result = await operations.GetWithHttpMessagesAsync(resourceProviderNamespace, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of resource providers.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static Page<Provider> ListNext(this IProvidersOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((IProvidersOperations)s).ListNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of resource providers.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Page<Provider>> ListNextAsync( this IProvidersOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Page<Provider>> result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
