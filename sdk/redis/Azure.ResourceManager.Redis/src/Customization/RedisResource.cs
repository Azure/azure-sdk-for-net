// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Redis.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Redis
{
    /// <summary>
    /// A Class representing a Redis along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="RedisResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetRedisResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetRedis method.
    /// </summary>
    public partial class RedisResource : ArmResource
    {
        /// <summary>
        /// Update an existing Redis cache.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/redis/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Redis_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Parameters supplied to the Update Redis operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release. Please use another long-running operation with same method name instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<RedisResource>> UpdateAsync(RedisPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _redisRedisResourcesClientDiagnostics.CreateScope("RedisResource.Update");
            scope.Start();
            try
            {
                var response = await _redisRedisResourcesRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, cancellationToken).ConfigureAwait(false);
                var operation = new RedisArmOperation<RedisResource>(new RedisOperationSource(Client), _redisRedisResourcesClientDiagnostics, Pipeline, _redisRedisResourcesRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch).Request, response, OperationFinalStateVia.Location);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update an existing Redis cache.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/redis/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Redis_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Parameters supplied to the Update Redis operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release. Please use another long-running operation with same method name instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<RedisResource> Update(RedisPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _redisRedisResourcesClientDiagnostics.CreateScope("RedisResource.Update");
            scope.Start();
            try
            {
                var response = _redisRedisResourcesRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, cancellationToken);
                var operation = new RedisArmOperation<RedisResource>(new RedisOperationSource(Client), _redisRedisResourcesClientDiagnostics, Pipeline, _redisRedisResourcesRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch).Request, response, OperationFinalStateVia.Location);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
