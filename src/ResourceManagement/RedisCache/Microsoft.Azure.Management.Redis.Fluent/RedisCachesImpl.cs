// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Fluent.Redis
{
    using Microsoft.Azure.Management.Fluent.Redis.Models;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation of RedisCaches and its parent interfaces.
    /// </summary>
    internal partial class RedisCachesImpl  :
        GroupableResources<IRedisCache,
            RedisCacheImpl,
            RedisResourceInner, 
            IRedisOperations, 
            RedisManager>,
        IRedisCaches
    {
        private IPatchSchedulesOperations pathcSchedulesClient;

        internal RedisCachesImpl (IRedisOperations client, IPatchSchedulesOperations patchClient, RedisManager redisManager) 
            : base(client, redisManager)
        {
            pathcSchedulesClient = patchClient;
        }

        public PagedList<IRedisCache> List()
        {
            IEnumerable<RedisResourceInner> redisResources = InnerCollection.List();
            var pagedList = new PagedList<RedisResourceInner>(redisResources);
            return WrapList(pagedList);
        }

        public PagedList<IRedisCache> ListByGroup (string groupName)
        {
            IEnumerable<RedisResourceInner> redisResources = InnerCollection.ListByResourceGroup(groupName);
            var pagedList = new PagedList<RedisResourceInner>(redisResources);
            return WrapList(pagedList);
        }

        public void Delete (string id)
        {
            Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete (string groupName, string name)
        {
            this.InnerCollection.Delete(groupName, name);
        }

        public RedisCacheImpl Define (string name)
        {
            return WrapModel(name);
        }

        protected override RedisCacheImpl WrapModel (string name)
        {
            return new RedisCacheImpl(
                name,
                new RedisResourceInner(),
                this.pathcSchedulesClient,
                this.InnerCollection,
                this.Manager);
        }

        protected override IRedisCache WrapModel (RedisResourceInner redisResourceInner)
        {
            return new RedisCacheImpl(
                redisResourceInner.Name,
                redisResourceInner,
                this.pathcSchedulesClient,
                this.InnerCollection,
                this.Manager);
        }

    }
}