// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.Redis;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.Search;
using Azure.ResourceManager.Search.Models;

namespace Azure.Provisioning.search
{
    /// <summary>
    /// Represents a search service resource.
    /// </summary>
    public class SearchService : Resource<SearchServiceData>
    {
        private const string ResourceTypeName = "Microsoft.Search/searchServices";
        private static readonly Func<string, SearchServiceData> Empty = (name) => ArmSearchModelFactory.SearchServiceData();
        internal const string DefaultVersion = "2023-11-01";

        /// <summary>
        /// Creates a new instance of the <see cref="SearchService"/> class.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="sku"></param>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="location"></param>
        public SearchService(IConstruct scope, SearchSkuName? sku = default, ResourceGroup? parent = default, string name = "search", string version = DefaultVersion, AzureLocation? location = default)
            : this(scope, sku, parent, name, version, false, (name) => ArmSearchModelFactory.SearchServiceData(
                name: name,
                location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS,
                skuName: sku ?? SearchSkuName.Free))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private SearchService(IConstruct scope, SearchSkuName? sku = default, ResourceGroup? parent = default, string name = "search", string version = DefaultVersion, bool isExisting = false, Func<string, SearchServiceData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RedisCache"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The KeyVault instance.</returns>
        public static SearchService FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new SearchService(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override string GetAzureName(IConstruct scope, string resourceName) => GetGloballyUniqueName(resourceName);
    }
}
