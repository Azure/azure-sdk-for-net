namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq.Expressions;
    using Microsoft.Azure;
    using Models;

    public static partial class ProvidersOperationsExtensions
    {
            /// <summary>
            /// Unregisters provider from a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
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
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Provider> UnregisterAsync( this IProvidersOperations operations, string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Provider> result = await operations.UnregisterWithOperationResponseAsync(resourceProviderNamespace, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Registers provider to be used with a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
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
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Provider> RegisterAsync( this IProvidersOperations operations, string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Provider> result = await operations.RegisterWithOperationResponseAsync(resourceProviderNamespace, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of resource providers.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns all deployments.
            /// </param>
            public static ProviderListResult List(this IProvidersOperations operations, int? top = default(int?))
            {
                return Task.Factory.StartNew(s => ((IProvidersOperations)s).ListAsync(top), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of resource providers.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='top'>
            /// Query parameters. If null is passed returns all deployments.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ProviderListResult> ListAsync( this IProvidersOperations operations, int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ProviderListResult> result = await operations.ListWithOperationResponseAsync(top, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
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
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Provider> GetAsync( this IProvidersOperations operations, string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Provider> result = await operations.GetWithOperationResponseAsync(resourceProviderNamespace, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of resource providers.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static ProviderListResult ListNext(this IProvidersOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IProvidersOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of resource providers.
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
            public static async Task<ProviderListResult> ListNextAsync( this IProvidersOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ProviderListResult> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
