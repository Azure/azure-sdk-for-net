// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Fluent.Redis
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Redis.RedisCache.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
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
        ISupportsDeletingByGroup
    /* ,
    //TODO Uncomment this after supporting ISupportsBatchCreation in C#
    ISupportsBatchCreation<IRedisCache>*/
    {
    }
}