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
    public static partial class SubscriptionOperationsExtensions
    {
            /// <summary>
            /// Gets details about particular subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='subscriptionId'>
            /// Id of the subscription.
            /// </param>
            public static Subscription Get(this ISubscriptionOperations operations, string subscriptionId)
            {
                return Task.Factory.StartNew(s => ((ISubscriptionOperations)s).GetAsync(subscriptionId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets details about particular subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='subscriptionId'>
            /// Id of the subscription.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Subscription> GetAsync( this ISubscriptionOperations operations, string subscriptionId, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Subscription> result = await operations.GetWithOperationResponseAsync(subscriptionId, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of the subscriptionIds.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            public static IList<Subscription> List(this ISubscriptionOperations operations)
            {
                return Task.Factory.StartNew(s => ((ISubscriptionOperations)s).ListAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of the subscriptionIds.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<IList<Subscription>> ListAsync( this ISubscriptionOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<IList<Subscription>> result = await operations.ListWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
