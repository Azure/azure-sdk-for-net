// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Redis.Mocking;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis.Mocking
{
    //The MPG emitter ignores @@clientName on listBySubscription when naming the
    // SubscriptionResource extension method (it emits GetRedis / GetRedisAsync instead of
    // GetAllRedis / GetAllRedisAsync). Suppress the mis-named generated methods and re-add the
    // long-name versions to maintain API parity with the baseline.
    // Tracked: https://github.com/Azure/azure-sdk-for-net/issues/58692
    // TODO: remove this customization once the emitter fix lands.
    [CodeGenSuppress("GetRedisAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetRedis", typeof(CancellationToken))]
    public partial class MockableRedisSubscriptionResource
    {
        /// <summary>
        /// Gets all Redis caches in the specified subscription.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RedisResource"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<RedisResource> GetAllRedisAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<RedisData, RedisResource>(new RedisResourcesGetAllRedisAsyncCollectionResultOfT(RedisResourcesRestClient, Guid.Parse(Id.SubscriptionId), context, "MockableRedisSubscriptionResource.GetAllRedis"), data => new RedisResource(Client, data));
        }

        /// <summary>
        /// Gets all Redis caches in the specified subscription.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RedisResource"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual Pageable<RedisResource> GetAllRedis(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<RedisData, RedisResource>(new RedisResourcesGetAllRedisCollectionResultOfT(RedisResourcesRestClient, Guid.Parse(Id.SubscriptionId), context, "MockableRedisSubscriptionResource.GetAllRedis"), data => new RedisResource(Client, data));
        }
    }
}
