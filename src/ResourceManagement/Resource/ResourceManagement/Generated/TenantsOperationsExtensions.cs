using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure;
using Microsoft.Azure.Subscriptions.Models;

namespace Microsoft.Azure.Subscriptions
{
    public static partial class TenantsOperationsExtensions
    {
            /// <summary>
            /// Gets a list of the tenantIds.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            public static IList<TenantIdDescription> List(this ITenantsOperations operations)
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
            public static async Task<IList<TenantIdDescription>> ListAsync( this ITenantsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<IList<TenantIdDescription>> result = await operations.ListWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
