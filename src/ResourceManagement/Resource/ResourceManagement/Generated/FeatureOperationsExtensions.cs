using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Management.Resources
{
    public static partial class FeatureOperationsExtensions
    {
            /// <summary>
            /// Gets a list of previewed features for all the providers in the current
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            public static FeatureOperationsListResult ListAll(this IFeatureOperations operations)
            {
                return Task.Factory.StartNew(s => ((IFeatureOperations)s).ListAllAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of previewed features for all the providers in the current
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<FeatureOperationsListResult> ListAllAsync( this IFeatureOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<FeatureOperationsListResult> result = await operations.ListAllWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of previewed features of a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static FeatureOperationsListResult ListAllNext(this IFeatureOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((IFeatureOperations)s).ListAllNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of previewed features of a subscription.
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
            public static async Task<FeatureOperationsListResult> ListAllNextAsync( this IFeatureOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<FeatureOperationsListResult> result = await operations.ListAllNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of previewed features of a resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// The namespace of the resource provider.
            /// </param>
            public static FeatureOperationsListResult List(this IFeatureOperations operations, string resourceProviderNamespace)
            {
                return Task.Factory.StartNew(s => ((IFeatureOperations)s).ListAsync(resourceProviderNamespace), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of previewed features of a resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// The namespace of the resource provider.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<FeatureOperationsListResult> ListAsync( this IFeatureOperations operations, string resourceProviderNamespace, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<FeatureOperationsListResult> result = await operations.ListWithOperationResponseAsync(resourceProviderNamespace, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Get all features under the subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            /// <param name='featureName'>
            /// Previewed feature name in the resource provider.
            /// </param>
            public static FeatureResponse Get(this IFeatureOperations operations, string resourceProviderNamespace, string featureName)
            {
                return Task.Factory.StartNew(s => ((IFeatureOperations)s).GetAsync(resourceProviderNamespace, featureName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get all features under the subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            /// <param name='featureName'>
            /// Previewed feature name in the resource provider.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<FeatureResponse> GetAsync( this IFeatureOperations operations, string resourceProviderNamespace, string featureName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<FeatureResponse> result = await operations.GetWithOperationResponseAsync(resourceProviderNamespace, featureName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Registers for a previewed feature of a resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            /// <param name='featureName'>
            /// Previewed feature name in the resource provider.
            /// </param>
            public static FeatureResponse Register(this IFeatureOperations operations, string resourceProviderNamespace, string featureName)
            {
                return Task.Factory.StartNew(s => ((IFeatureOperations)s).RegisterAsync(resourceProviderNamespace, featureName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Registers for a previewed feature of a resource provider.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            /// <param name='featureName'>
            /// Previewed feature name in the resource provider.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<FeatureResponse> RegisterAsync( this IFeatureOperations operations, string resourceProviderNamespace, string featureName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<FeatureResponse> result = await operations.RegisterWithOperationResponseAsync(resourceProviderNamespace, featureName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
