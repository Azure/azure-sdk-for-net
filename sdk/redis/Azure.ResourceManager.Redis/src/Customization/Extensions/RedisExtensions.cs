// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Redis.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Redis
{
    public static partial class RedisExtensions
    {
        /// <summary>
        /// Gets all Redis caches in the specified subscription.
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RedisResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<RedisResource> GetAllRedisAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableRedisSubscriptionResource(subscriptionResource).GetAllRedisAsync(cancellationToken);
        }

        /// <summary>
        /// Gets all Redis caches in the specified subscription.
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RedisResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<RedisResource> GetAllRedis(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableRedisSubscriptionResource(subscriptionResource).GetAllRedis(cancellationToken);
        }
    }
}
