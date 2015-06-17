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

    public static partial class SubscriptionsOperationsExtensions
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
            public static Subscription Get(this ISubscriptionsOperations operations, string subscriptionId)
            {
                return Task.Factory.StartNew(s => ((ISubscriptionsOperations)s).GetAsync(subscriptionId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            public static async Task<Subscription> GetAsync( this ISubscriptionsOperations operations, string subscriptionId, CancellationToken cancellationToken = default(CancellationToken))
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
            public static SubscriptionListResult List(this ISubscriptionsOperations operations)
            {
                return Task.Factory.StartNew(s => ((ISubscriptionsOperations)s).ListAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            public static async Task<SubscriptionListResult> ListAsync( this ISubscriptionsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<SubscriptionListResult> result = await operations.ListWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of the subscriptionIds.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='nextLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static SubscriptionListResult ListNext(this ISubscriptionsOperations operations, string nextLink)
            {
                return Task.Factory.StartNew(s => ((ISubscriptionsOperations)s).ListNextAsync(nextLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of the subscriptionIds.
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
            public static async Task<SubscriptionListResult> ListNextAsync( this ISubscriptionsOperations operations, string nextLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<SubscriptionListResult> result = await operations.ListNextWithOperationResponseAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
