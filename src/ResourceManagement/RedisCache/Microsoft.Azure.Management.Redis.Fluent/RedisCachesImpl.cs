// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation of RedisCaches and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlZGlzLmltcGxlbWVudGF0aW9uLlJlZGlzQ2FjaGVzSW1wbA==
    internal partial class RedisCachesImpl :
        TopLevelModifiableResources<IRedisCache,
            RedisCacheImpl,
            RedisResourceInner,
            IRedisOperations,
            IRedisManager>,
        IRedisCaches
    {
        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:C2F15BEB23386D8534B400C08B468649:2DA21496DE2BD6513C1C418114ACEF97
        internal RedisCachesImpl(IRedisManager redisManager)
            : base(redisManager.Inner.Redis, redisManager)
        {
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public RedisCacheImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        protected async override Task<RedisResourceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        protected async override Task<IPage<RedisResourceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken);
        }

        protected async override Task<IPage<RedisResourceInner>>ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }


        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:BDFF4CB61E8A8D975417EA5FC914921A
        protected async override Task<IPage<RedisResourceInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<RedisResourceInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:4A5A2A1EDBB98E8843A388EEBC9C31D6
        protected override RedisCacheImpl WrapModel(string name)
        {
            return new RedisCacheImpl(
                name,
                new RedisResourceInner(),
                this.Manager);
        }

        ///GENMHASH:CBAFA6E0018A4E2E5B9C07BDC6094FEA:D49E5AF1C51CD53AE44C02A61286734D
        protected override IRedisCache WrapModel(RedisResourceInner redisResourceInner)
        {
            return new RedisCacheImpl(
                redisResourceInner.Name,
                redisResourceInner,
                this.Manager);
        }
    }
}
