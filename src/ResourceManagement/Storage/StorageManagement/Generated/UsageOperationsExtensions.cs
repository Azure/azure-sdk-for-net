namespace Microsoft.Azure.Management.Storage
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    public static partial class UsageOperationsExtensions
    {
            /// <summary>
            /// Gets the current usage count and the limit for the resources under the
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static UsageListResult List(this IUsageOperations operations)
            {
                return Task.Factory.StartNew(s => ((IUsageOperations)s).ListAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the current usage count and the limit for the resources under the
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<UsageListResult> ListAsync( this IUsageOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<UsageListResult> result = await operations.ListWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
