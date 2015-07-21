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
            /// The operations group for this extension method.
            /// </param>
            public static Page<TenantIdDescription> List(this ITenantsOperations operations)
            {
                return Task.Factory.StartNew(s => ((ITenantsOperations)s).ListAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of the tenantIds.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Page<TenantIdDescription>> ListAsync( this ITenantsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Page<TenantIdDescription>> result = await operations.ListWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of the tenantIds.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static Page<TenantIdDescription> ListNext(this ITenantsOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((ITenantsOperations)s).ListNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of the tenantIds.
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
            public static async Task<Page<TenantIdDescription>> ListNextAsync( this ITenantsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Page<TenantIdDescription>> result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
