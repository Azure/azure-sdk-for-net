namespace Microsoft.Azure.Subscriptions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    public static partial class TenantsOperationsExtensions
    {
            /// <summary>
            /// Gets a list of the tenantIds.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            public static TenantListResult List(this ITenantsOperations operations)
            {
                return Task.Factory.StartNew(s => ((ITenantsOperations)s).ListAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of the tenantIds.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<TenantListResult> ListAsync( this ITenantsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<TenantListResult> result = await operations.ListWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of the tenantIds.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static TenantListResult ListNext(this ITenantsOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((ITenantsOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of the tenantIds.
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
            public static async Task<TenantListResult> ListNextAsync( this ITenantsOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<TenantListResult> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
