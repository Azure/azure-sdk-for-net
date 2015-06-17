namespace Microsoft.Azure.Subscriptions
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface ISubscriptionsOperations
    {
        /// <summary>
        /// Gets details about particular subscription.
        /// </summary>
        /// <param name='subscriptionId'>
        /// Id of the subscription.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<Subscription>> GetWithOperationResponseAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of the subscriptionIds.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<SubscriptionListResult>> ListWithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of the subscriptionIds.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<SubscriptionListResult>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
