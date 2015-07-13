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

    public static partial class ResourceProviderOperationDetailsOperationsExtensions
    {
            /// <summary>
            /// Gets a list of resource providers.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Resource identity.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            public static ResourceProviderOperationDetailListResult List(this IResourceProviderOperationDetailsOperations operations, string resourceProviderNamespace, string apiVersion)
            {
                return Task.Factory.StartNew(s => ((IResourceProviderOperationDetailsOperations)s).ListAsync(resourceProviderNamespace, apiVersion), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of resource providers.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Resource identity.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<ResourceProviderOperationDetailListResult> ListAsync( this IResourceProviderOperationDetailsOperations operations, string resourceProviderNamespace, string apiVersion, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ResourceProviderOperationDetailListResult> result = await operations.ListWithHttpMessagesAsync(resourceProviderNamespace, apiVersion, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
