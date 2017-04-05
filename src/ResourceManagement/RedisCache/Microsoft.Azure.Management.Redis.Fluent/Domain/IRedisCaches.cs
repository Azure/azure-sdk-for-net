// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Redis.Fluent
{

    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    /// <summary>
    /// Entry point for Redis Caches management API.
    /// </summary>
    public interface IRedisCaches  :
        ISupportsCreating<RedisCache.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>,
        ISupportsGettingById<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>,
        IHasManager<IRedisManager>,
        IHasInner<IRedisOperations>
    {
    }
}