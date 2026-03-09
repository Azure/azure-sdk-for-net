// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Redis.Mocking;

namespace Azure.ResourceManager.Redis.Mocking
{
    public partial class MockableRedisSubscriptionResource
    {
        /// <summary>
        /// Gets all Redis caches in the specified subscription.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RedisResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<RedisResource> GetAllRedisAsync(CancellationToken cancellationToken = default)
        {
            return GetRedisAsync(cancellationToken);
        }

        /// <summary>
        /// Gets all Redis caches in the specified subscription.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RedisResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<RedisResource> GetAllRedis(CancellationToken cancellationToken = default)
        {
            return GetRedis(cancellationToken);
        }
    }
}
