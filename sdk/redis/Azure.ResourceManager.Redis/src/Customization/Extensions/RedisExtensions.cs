// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Redis.Mocking;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis
{
    // The spec already renames the listBySubscription op via
    //   @@clientName(RedisResources.listBySubscription, "getAllRedis", "csharp")
    // (client.tsp:227). The MPG emitter honors this rename for the inner
    // RedisResourcesGetAllRedisCollectionResultOfT helper class but **not** for the public
    // extension-method name on SubscriptionResource - it still emits GetRedis / GetRedisAsync.
    // We suppress the mis-named generated methods and re-add the long-name versions for API
    // parity with the baseline (GetAllRedis / GetAllRedisAsync). Same workaround exists in
    // Azure.ResourceManager.CognitiveServices and Azure.ResourceManager.FrontDoor.
    // Tracked: https://github.com/Azure/azure-sdk-for-net/issues/58692
    // TODO: remove this customization once the emitter fix lands.
    [CodeGenSuppress("GetRedisAsync", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetRedis", typeof(SubscriptionResource), typeof(CancellationToken))]
    public static partial class RedisExtensions
    {
        /// <summary>
        /// Gets all Redis caches in the specified subscription.
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RedisResource"/> that may take multiple service requests to iterate over. </returns>
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
        public static Pageable<RedisResource> GetAllRedis(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableRedisSubscriptionResource(subscriptionResource).GetAllRedis(cancellationToken);
        }
    }
}
