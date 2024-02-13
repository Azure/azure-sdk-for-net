// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Search.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.ResourceManager.Search.Tests.Tests
{
    public class SearchServiceResourceTest : SearchManagementTestBase
    {
        public SearchServiceResourceTest(bool isAsync) : base(isAsync)// RecordedTestMode.Record)
        {
        }
        public SearchServiceCollection SearchCollection { get; set; }
        public SearchServiceResource SearchResource { get; set; }

        public async Task setResourceGroup()
        {
            var rg = await CreateResourceGroupAsync();
            SearchCollection = rg.GetSearchServices();
        }

        [Test]
        public async Task GetAsyncTest()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var result = (await SearchResource.GetAsync()).Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(name, result.Data.Name);
            Assert.AreEqual(DefaultLocation, result.Data.Location);
            Assert.AreEqual(SearchSkuName.Standard, result.Data.Sku.Name);
            Assert.AreEqual(1, result.Data.PartitionCount);
            Assert.AreEqual(1, result.Data.ReplicaCount);
            Assert.AreEqual(SearchServiceHostingMode.Default, result.Data.HostingMode);
        }

        [Test]
        public async Task DeleteAsyncTest()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            await SearchResource.DeleteAsync(WaitUntil.Completed);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await SearchCollection.GetAsync(name));
            Assert.IsNotNull(exception);
            Assert.IsNotNull(exception.Message);
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public async Task UpdateAsyncTest()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            SearchServicePatch patch = new SearchServicePatch(DefaultLocation)
            {
                PartitionCount = 2,
                ReplicaCount = 3,
            };
            SearchServiceResource item = (await SearchResource.UpdateAsync(patch)).Value;
            Assert.IsNotNull(item);
            Assert.IsTrue(item.Data.Location == DefaultLocation);
            Assert.AreEqual(name, item.Data.Name);
            Assert.AreEqual(SearchSkuName.Standard, item.Data.Sku.Name);
            Assert.AreEqual(2, item.Data.PartitionCount);
            Assert.AreEqual(3, item.Data.ReplicaCount);
            Assert.AreEqual(SearchServiceHostingMode.Default, item.Data.HostingMode);
        }

        [Test]
        public async Task GetAdminKeyAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var result = await SearchResource.GetAdminKeyAsync();
            Assert.NotNull(result);

            var value = result.Value;
            Assert.NotNull(value);
            Assert.IsTrue(value is SearchServiceAdminKeyResult);
            Assert.NotNull(value.PrimaryKey);
            Assert.NotNull(value.SecondaryKey);
        }
        [Test]
        public async Task RegenerateAdminKeyAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;

            var originalAdminKey = (await SearchResource.GetAdminKeyAsync()).Value;
            var regenAdminPrimaryKey = (await SearchResource.RegenerateAdminKeyAsync(SearchServiceAdminKeyKind.Primary)).Value;
            var regenAdminSecondaryKey = (await SearchResource.RegenerateAdminKeyAsync(SearchServiceAdminKeyKind.Secondary)).Value;
            Assert.NotNull(regenAdminPrimaryKey);
            Assert.NotNull(regenAdminSecondaryKey);
            //Assert.AreNotEqual(originalAdminKey.PrimaryKey, regenAdminPrimaryKey.PrimaryKey);
            //Assert.AreEqual(originalAdminKey.SecondaryKey, regenAdminPrimaryKey.SecondaryKey);
            //Assert.AreNotEqual(originalAdminKey.PrimaryKey, regenAdminSecondaryKey.PrimaryKey);
            //Assert.AreNotEqual(originalAdminKey.SecondaryKey, regenAdminSecondaryKey.SecondaryKey);
        }
        [Test]
        public async Task CreateQueryKeyAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var queryName = Recording.GenerateAssetName("queryKey-");
            var result = (await SearchResource.CreateQueryKeyAsync(queryName)).Value;
            Assert.NotNull(result);
            Assert.IsTrue(result is SearchServiceQueryKey);
            Assert.NotNull(result.Key);
            Assert.AreEqual(queryName, result.Name);
        }
        [Test]
        public async Task DeleteQueryKeyAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var queryName = Recording.GenerateAssetName("queryKey-");
            var key = SearchResource.CreateQueryKeyAsync(queryName).Result.Value.Key;
            var result = Mode == RecordedTestMode.Playback ? await SearchResource.DeleteQueryKeyAsync("Sanitized") : await SearchResource.DeleteQueryKeyAsync(key);
            Assert.NotNull(result);
            Assert.IsFalse(result.IsError);
            Assert.NotNull(result.ReasonPhrase);
            Assert.IsTrue(result.Status == 204);
        }
        [Test]
        public async Task GetQueryKeysBySearchServiceAsyncTest()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var queryName = Recording.GenerateAssetName("queryKey-");
            var originKey = (await SearchResource.CreateQueryKeyAsync(queryName)).Value;
            var list = await SearchResource.GetQueryKeysBySearchServiceAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(queryName,list.First(item => item.Name == queryName).Name);
            Assert.IsNotNull(list.First(item => item.Name == queryName).Key);
            Assert.IsNotEmpty(list.First(item => item.Name == queryName).Key);
        }
        [Test]
        public async Task AddTagAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            await SearchResource.AddTagAsync("key1", "value1");
            var result = (await SearchResource.GetAsync()).Value;
            KeyValuePair<string, string> tag = result.Data.Tags.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.NotNull(tag);
            Assert.AreEqual("key1", tag.Key);
            Assert.AreEqual("value1", tag.Value);
        }

        [Test]
        public async Task SetTagsAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            Dictionary<string, string> tags = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };
            var result = (await SearchResource.SetTagsAsync(tags)).Value;
            Assert.NotNull(result);
            Assert.IsTrue(result.Data.Tags.Count == 2);
            Assert.AreEqual("value1", result.Data.Tags["key1"]);
            Assert.AreEqual("value2", result.Data.Tags["key2"]);
        }
        [Test]
        public async Task RemoveTagAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            Dictionary<string, string> tags = new Dictionary<string, string> { { "key1", "Value1" }, { "key2", "vaule2" } };
            await SearchResource.SetTagsAsync(tags);
            await SearchResource.RemoveTagAsync("key1");
            var result = (await SearchResource.GetAsync()).Value;
            Assert.NotNull(result);
            Assert.IsFalse(result.Data.Tags.ContainsKey("key1"));
            Assert.IsTrue(result.Data.Tags.ContainsKey("key2"));
        }

        [Test]
        public async Task DisableAndEnableLocalAuthAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SkuName = SearchSkuName.Basic,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default,
                IsLocalAuthDisabled = true
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var result = (await SearchResource.GetAsync()).Value;
            Assert.NotNull(result);
            Assert.IsTrue(result.Data.IsLocalAuthDisabled);

            data.IsLocalAuthDisabled = false;
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            result = (await SearchResource.GetAsync()).Value;
            Assert.NotNull(result);
            Assert.IsFalse(result.Data.IsLocalAuthDisabled);

            data.AuthOptions = new SearchAadAuthDataPlaneAuthOptions
            {
                ApiKeyOnly = BinaryData.FromObjectAsJson(new { })
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            result = (await SearchResource.GetAsync()).Value;
            Assert.NotNull(result);
            Assert.IsFalse(result.Data.IsLocalAuthDisabled);
            Assert.IsNotNull(result.Data.AuthOptions);
            Assert.IsNull(result.Data.AuthOptions.AadOrApiKey);
            Assert.IsNotNull(result.Data.AuthOptions.ApiKeyOnly);

            data.AuthOptions = new SearchAadAuthDataPlaneAuthOptions
            {
                AadOrApiKey = new DataPlaneAadOrApiKeyAuthOption(SearchAadAuthFailureMode.Http401WithBearerChallenge, null)
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            result = (await SearchResource.GetAsync()).Value;
            Assert.NotNull(result);
            Assert.IsFalse(result.Data.IsLocalAuthDisabled);
            Assert.IsNotNull(result.Data.AuthOptions);
            Assert.IsNull(result.Data.AuthOptions.ApiKeyOnly);
            Assert.IsNotNull(result.Data.AuthOptions.AadOrApiKey);
            Assert.AreEqual(SearchAadAuthFailureMode.Http401WithBearerChallenge, result.Data.AuthOptions.AadOrApiKey.AadAuthFailureMode);

            data.AuthOptions = new SearchAadAuthDataPlaneAuthOptions
            {
                AadOrApiKey = new DataPlaneAadOrApiKeyAuthOption(SearchAadAuthFailureMode.Http403, null)
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            result = (await SearchResource.GetAsync()).Value;
            Assert.NotNull(result);
            Assert.IsFalse(result.Data.IsLocalAuthDisabled);
            Assert.IsNotNull(result.Data.AuthOptions);
            Assert.IsNull(result.Data.AuthOptions.ApiKeyOnly);
            Assert.IsNotNull(result.Data.AuthOptions.AadOrApiKey);
            Assert.AreEqual(SearchAadAuthFailureMode.Http403, result.Data.AuthOptions.AadOrApiKey.AadAuthFailureMode);
        }

        [Test]
        public async Task DisableAndEnableSemanticSearchAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(AzureLocation.WestCentralUS)
            {
                SkuName = SearchSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                SemanticSearch = SearchSemanticSearch.Disabled
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var result = (await SearchResource.GetAsync()).Value;
            Assert.NotNull(result);
            Assert.AreEqual(result.Data.SemanticSearch, SearchSemanticSearch.Disabled);

            data.SemanticSearch = SearchSemanticSearch.Free;
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            result = (await SearchResource.GetAsync()).Value;
            Assert.NotNull(result);
            Assert.AreEqual(result.Data.SemanticSearch, SearchSemanticSearch.Free);

            data.SemanticSearch = SearchSemanticSearch.Standard;
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            result = (await SearchResource.GetAsync()).Value;
            Assert.NotNull(result);
            Assert.AreEqual(result.Data.SemanticSearch, SearchSemanticSearch.Standard);
        }
    }
}
