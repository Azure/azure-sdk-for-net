// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Search.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Search.Tests
{
    public class SearchServiceCollectionTests : SearchManagementTestBase
    {
        public SearchServiceCollectionTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public SearchServiceCollection SearchCollection { get; set; }

        public async Task SetCollection()
        {
            var rg = await CreateResourceGroupAsync();
            SearchCollection = rg.GetSearchServices();
        }

        [Test]
        public async Task CreateOrUpdateTest()
        {
            await SetCollection();

            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            var result = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            Assert.IsNotNull(result);
            Assert.AreEqual(name, result.Data.Name);
            Assert.AreEqual(DefaultLocation, result.Data.Location);
            Assert.AreEqual(SearchSkuName.Standard, result.Data.Sku.Name);
            Assert.AreEqual(1, result.Data.PartitionCount);
            Assert.AreEqual(1, result.Data.ReplicaCount);
            Assert.AreEqual(SearchServiceHostingMode.Default, result.Data.HostingMode);
        }

        [Test]
        public async Task GetAsyncTest()
        {
            await SetCollection();

            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            var result = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;

            result = (await SearchCollection.GetAsync(name)).Value;
            Assert.IsNotNull(result);
            Assert.AreEqual(name, result.Data.Name);
            Assert.AreEqual(DefaultLocation, result.Data.Location);
            Assert.AreEqual(SearchSkuName.Standard, result.Data.Sku.Name);
            Assert.AreEqual(1, result.Data.PartitionCount);
            Assert.AreEqual(1, result.Data.ReplicaCount);
            Assert.AreEqual(SearchServiceHostingMode.Default, result.Data.HostingMode);
        }

        [Test]
        public async Task GetAllAsyncTest()
        {
            await SetCollection();

            var name1 = Recording.GenerateAssetName("search1");
            var data1 = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };

            var name2 = Recording.GenerateAssetName("search2");
            var data2 = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name1, data1);
            await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name2, data2);

            List<SearchServiceResource> searchServices = await SearchCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(2, searchServices.Count);
            Assert.IsTrue(searchServices.First(x => x.Data.Name == name1).Data.SkuName == SearchSkuName.Standard);
            Assert.IsTrue(searchServices.First(x => x.Data.Name == name1).Data.PartitionCount == 1);
            Assert.IsTrue(searchServices.First(x => x.Data.Name == name1).Data.ReplicaCount == 1);
            Assert.IsTrue(searchServices.First(x => x.Data.Name == name1).Data.HostingMode == SearchServiceHostingMode.Default);
        }
        [Test]
        public async Task ExistsAsync()
        {
            await SetCollection();

            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            var result = (await SearchCollection.ExistsAsync(name)).Value;
            Assert.NotNull(result);
            Assert.IsTrue(result == true);
        }
    }
}
