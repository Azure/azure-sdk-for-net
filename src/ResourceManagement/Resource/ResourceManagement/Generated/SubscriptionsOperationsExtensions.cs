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
            /// The operations group for this extension method.
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
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// Id of the subscription.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Subscription> GetAsync( this ISubscriptionsOperations operations, string subscriptionId, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Subscription> result = await operations.GetWithHttpMessagesAsync(subscriptionId, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of the subscriptionIds.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static Page<Subscription> List(this ISubscriptionsOperations operations)
            {
                return Task.Factory.StartNew(s => ((ISubscriptionsOperations)s).ListAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of the subscriptionIds.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<Page<Subscription>> ListAsync( this ISubscriptionsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Page<Subscription>> result = await operations.ListWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of the subscriptionIds.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// NextLink from the previous successful call to List operation.
            /// </param>
            public static Page<Subscription> ListNext(this ISubscriptionsOperations operations, string nextPageLink)
            {
                return Task.Factory.StartNew(s => ((ISubscriptionsOperations)s).ListNextAsync(nextPageLink), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of the subscriptionIds.
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
            public static async Task<Page<Subscription>> ListNextAsync( this ISubscriptionsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<Page<Subscription>> result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
