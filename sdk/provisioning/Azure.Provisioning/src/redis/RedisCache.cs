// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.Redis;
using Azure.ResourceManager.Redis.Models;

namespace Azure.Provisioning.Redis
{
    /// <summary>
    /// Represents a RedisCache.
    /// </summary>
    public class RedisCache : Resource<RedisData>
    {
        private const string ResourceTypeName = "Microsoft.Cache/Redis";
        private static readonly Func<string, RedisData> Empty = (name) => ArmRedisModelFactory.RedisData(updateChannel: null);

        /// <summary>
        /// Creates a new instance of the <see cref="RedisCache"/> class.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="sku"></param>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        public RedisCache(IConstruct scope, RedisSku? sku = default, ResourceGroup? parent = default, string name = "redis", AzureLocation? location = default)
            : this(scope, sku, parent, name, false, (name) => ArmRedisModelFactory.RedisData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                enableNonSslPort: false,
                minimumTlsVersion: "1.2",
                sku: sku ?? new RedisSku(RedisSkuName.Basic, RedisSkuFamily.BasicOrStandard, 1),
                // necessary to disambiguate between the model factory overloads
                updateChannel: null))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private RedisCache(IConstruct scope, RedisSku? sku = default, ResourceGroup? parent = default, string name = "redis", bool isExisting = false, Func<string, RedisData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, "2020-06-01", creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Gets the connection string for the <see cref="RedisCache"/>.
        /// </summary>
        public RedisCacheConnectionString GetConnectionString(bool useSecondary = false)
            => new RedisCacheConnectionString(this, useSecondary);

        /// <summary>
        /// Creates a new instance of the <see cref="RedisCache"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static RedisCache FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new RedisCache(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
