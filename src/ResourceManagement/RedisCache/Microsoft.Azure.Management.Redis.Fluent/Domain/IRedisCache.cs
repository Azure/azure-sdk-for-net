// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Redis.Fluent
{

    using Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using System.Collections.Generic;
    /// <summary>
    /// An immutable client-side representation of an Azure Redis Cache.
    /// </summary>
    public interface IRedisCache  :
        IGroupableResource,
        IRefreshable<IRedisCache>,
        IUpdatable<IUpdate>,
        IWrapper<RedisResourceInner>
    {
        /// <returns>exposes features available only to Premium Sku Redis Cache instances.</returns>
        IRedisCachePremium AsPremium ();

        /// <returns>returns true if current Redis Cache instance has Premium Sku.</returns>
        bool IsPremium { get; }

        /// <returns>the provisioningState value</returns>
        string ProvisioningState { get; }

        /// <returns>the hostName value</returns>
        string HostName { get; }

        /// <returns>the port value</returns>
        int? Port { get; }

        /// <returns>the sslPort value</returns>
        int? SslPort { get; }

        /// <returns>the Redis version value</returns>
        string RedisVersion { get; }

        /// <returns>the sku value</returns>
        Sku Sku { get; }

        /// <returns>the Redis configuration value</returns>
        IDictionary<string,string> RedisConfiguration { get; }

        /// <returns>true if non SSL port is enabled, false otherwise</returns>
        bool? NonSslPort { get; }

        /// <returns>the shardCount value</returns>
        int? ShardCount { get; }

        /// <returns>the subnetId value</returns>
        string SubnetId { get; }

        /// <returns>the staticIP value</returns>
        string StaticIP { get; }

        /// <returns>a Redis Cache's access keys. This operation requires write permission to the Cache resource.</returns>
        IRedisAccessKeys Keys ();

        /// <summary>
        /// Fetch the up-to-date access keys from Azure for this Redis Cache.
        /// </summary>
        /// <returns>the access keys for this Redis Cache</returns>
        IRedisAccessKeys RefreshKeys ();

        /// <summary>
        /// Regenerates the access keys for this Redis Cache.
        /// </summary>
        /// <param name="keyType">keyType key type to regenerate</param>
        /// <returns>the generated access keys for this Redis Cache</returns>
        IRedisAccessKeys RegenerateKey (RedisKeyType keyType);

    }
}