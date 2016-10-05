// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Redis.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    /// <summary>
    /// Entry point for Redis Caches management API.
    /// </summary>
    public interface IRedisCaches  :
        ISupportsCreating<IBlank>,
        ISupportsListing<IRedisCache>,
        ISupportsListingByGroup<IRedisCache>,
        ISupportsGettingByGroup<IRedisCache>,
        ISupportsGettingById<IRedisCache>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<IRedisCache>
    {
    }
}