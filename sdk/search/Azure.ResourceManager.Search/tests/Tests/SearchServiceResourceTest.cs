// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Search.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Search.Tests.Tests
{
    public class SearchServiceResourceTest : SearchManagementTestBase
    {
        public SearchServiceResourceTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
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
                SearchSkuName = SearchServiceSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var result = (await SearchResource.GetAsync()).Value;

            Assert.IsNotNull(result);
            Assert.That(result.Data.Name, Is.EqualTo(name));
            Assert.That(result.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(result.Data.SearchSkuName, Is.EqualTo(SearchServiceSkuName.Standard));
            Assert.That(result.Data.PartitionCount, Is.EqualTo(1));
            Assert.That(result.Data.ReplicaCount, Is.EqualTo(1));
            Assert.That(result.Data.HostingMode, Is.EqualTo(SearchServiceHostingMode.Default));
        }

        [Test]
        public async Task DeleteAsyncTest()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SearchSkuName = SearchServiceSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            await SearchResource.DeleteAsync(WaitUntil.Completed);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await SearchCollection.GetAsync(name));
            Assert.IsNotNull(exception);
            Assert.IsNotNull(exception.Message);
            Assert.That(exception.Status, Is.EqualTo(404));
        }

        [Test]
        public async Task UpdateAsyncTest()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SearchSkuName = SearchServiceSkuName.Standard,
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
            Assert.That(item.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(item.Data.Name, Is.EqualTo(name));
            Assert.That(item.Data.SearchSkuName, Is.EqualTo(SearchServiceSkuName.Standard));
            Assert.That(item.Data.PartitionCount, Is.EqualTo(2));
            Assert.That(item.Data.ReplicaCount, Is.EqualTo(3));
            Assert.That(item.Data.HostingMode, Is.EqualTo(SearchServiceHostingMode.Default));
        }

        [Test]
        public async Task GetAdminKeyAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SearchSkuName = SearchServiceSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var result = await SearchResource.GetAdminKeyAsync();
            Assert.That(result, Is.Not.Null);

            var value = result.Value;
            Assert.That(value, Is.Not.Null);
            Assert.That(value is SearchServiceAdminKeyResult, Is.True);
            Assert.That(value.PrimaryKey, Is.Not.Null);
            Assert.That(value.SecondaryKey, Is.Not.Null);
        }
        [Test]
        public async Task RegenerateAdminKeyAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SearchSkuName = SearchServiceSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;

            var originalAdminKey = (await SearchResource.GetAdminKeyAsync()).Value;
            var regenAdminPrimaryKey = (await SearchResource.RegenerateAdminKeyAsync(SearchServiceAdminKeyKind.Primary)).Value;
            var regenAdminSecondaryKey = (await SearchResource.RegenerateAdminKeyAsync(SearchServiceAdminKeyKind.Secondary)).Value;
            Assert.That(regenAdminPrimaryKey, Is.Not.Null);
            Assert.That(regenAdminSecondaryKey, Is.Not.Null);
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
                SearchSkuName = SearchServiceSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var queryName = Recording.GenerateAssetName("queryKey-");
            var result = (await SearchResource.CreateQueryKeyAsync(queryName)).Value;
            Assert.That(result, Is.Not.Null);
            Assert.That(result is SearchServiceQueryKey, Is.True);
            Assert.That(result.Key, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(queryName));
        }
        [Test]
        public async Task DeleteQueryKeyAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SearchSkuName = SearchServiceSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var queryName = Recording.GenerateAssetName("queryKey-");
            var key = SearchResource.CreateQueryKeyAsync(queryName).Result.Value.Key;
            var result = Mode == RecordedTestMode.Playback ? await SearchResource.DeleteQueryKeyAsync("Sanitized") : await SearchResource.DeleteQueryKeyAsync(key);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsError, Is.False);
            Assert.That(result.ReasonPhrase, Is.Not.Null);
            Assert.That(result.Status == 204 || result.Status == 200, Is.True);
        }
        [Test]
        public async Task GetQueryKeysBySearchServiceAsyncTest()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SearchSkuName = SearchServiceSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var queryName = Recording.GenerateAssetName("queryKey-");
            var originKey = (await SearchResource.CreateQueryKeyAsync(queryName)).Value;
            var list = await SearchResource.GetQueryKeysBySearchServiceAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.That(list.First(item => item.Name == queryName).Name, Is.EqualTo(queryName));
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
                SearchSkuName = SearchServiceSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            await SearchResource.AddTagAsync("key1", "value1");
            var result = (await SearchResource.GetAsync()).Value;
            KeyValuePair<string, string> tag = result.Data.Tags.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.That(tag, Is.Not.Null);
            Assert.That(tag.Key, Is.EqualTo("key1"));
            Assert.That(tag.Value, Is.EqualTo("value1"));
        }

        [Test]
        public async Task SetTagsAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SearchSkuName = SearchServiceSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            Dictionary<string, string> tags = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };
            var result = (await SearchResource.SetTagsAsync(tags)).Value;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Tags.Count, Is.EqualTo(2));
            Assert.That(result.Data.Tags["key1"], Is.EqualTo("value1"));
            Assert.That(result.Data.Tags["key2"], Is.EqualTo("value2"));
        }
        [Test]
        public async Task RemoveTagAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SearchSkuName = SearchServiceSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            Dictionary<string, string> tags = new Dictionary<string, string> { { "key1", "Value1" }, { "key2", "vaule2" } };
            await SearchResource.SetTagsAsync(tags);
            await SearchResource.RemoveTagAsync("key1");
            var result = (await SearchResource.GetAsync()).Value;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Tags.ContainsKey("key1"), Is.False);
            Assert.That(result.Data.Tags.ContainsKey("key2"), Is.True);
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
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.IsLocalAuthDisabled, Is.True);

            data.IsLocalAuthDisabled = false;
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            result = (await SearchResource.GetAsync()).Value;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.IsLocalAuthDisabled, Is.False);

            data.AuthOptions = new SearchAadAuthDataPlaneAuthOptions
            {
                ApiKeyOnly = BinaryData.FromObjectAsJson(new { })
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            result = (await SearchResource.GetAsync()).Value;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.IsLocalAuthDisabled, Is.False);
            Assert.IsNotNull(result.Data.AuthOptions);
            Assert.That(result.Data.AuthOptions.AadOrApiKey, Is.Null);
            Assert.IsNotNull(result.Data.AuthOptions.ApiKeyOnly);

            data.AuthOptions = new SearchAadAuthDataPlaneAuthOptions
            {
                AadOrApiKey = new DataPlaneAadOrApiKeyAuthOption(SearchAadAuthFailureMode.Http401WithBearerChallenge, null)
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            result = (await SearchResource.GetAsync()).Value;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.IsLocalAuthDisabled, Is.False);
            Assert.IsNotNull(result.Data.AuthOptions);
            Assert.That(result.Data.AuthOptions.ApiKeyOnly, Is.Null);
            Assert.IsNotNull(result.Data.AuthOptions.AadOrApiKey);
            Assert.That(result.Data.AuthOptions.AadOrApiKey.AadAuthFailureMode, Is.EqualTo(SearchAadAuthFailureMode.Http401WithBearerChallenge));

            data.AuthOptions = new SearchAadAuthDataPlaneAuthOptions
            {
                AadOrApiKey = new DataPlaneAadOrApiKeyAuthOption(SearchAadAuthFailureMode.Http403, null)
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            result = (await SearchResource.GetAsync()).Value;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.IsLocalAuthDisabled, Is.False);
            Assert.IsNotNull(result.Data.AuthOptions);
            Assert.That(result.Data.AuthOptions.ApiKeyOnly, Is.Null);
            Assert.IsNotNull(result.Data.AuthOptions.AadOrApiKey);
            Assert.That(result.Data.AuthOptions.AadOrApiKey.AadAuthFailureMode, Is.EqualTo(SearchAadAuthFailureMode.Http403));
        }

        [Test]
        public async Task DisableAndEnableSemanticSearchAsync()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(AzureLocation.WestCentralUS)
            {
                SearchSkuName = SearchServiceSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                SemanticSearch = SearchSemanticSearch.Disabled
            };
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var result = (await SearchResource.GetAsync()).Value;
            Assert.That(result, Is.Not.Null);
            Assert.That(SearchSemanticSearch.Disabled, Is.EqualTo(result.Data.SemanticSearch));

            data.SemanticSearch = SearchSemanticSearch.Free;
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            result = (await SearchResource.GetAsync()).Value;
            Assert.That(result, Is.Not.Null);
            Assert.That(SearchSemanticSearch.Free, Is.EqualTo(result.Data.SemanticSearch));

            data.SemanticSearch = SearchSemanticSearch.Standard;
            SearchResource = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            result = (await SearchResource.GetAsync()).Value;
            Assert.That(result, Is.Not.Null);
            Assert.That(SearchSemanticSearch.Standard, Is.EqualTo(result.Data.SemanticSearch));
        }

        [Test]
        public async Task UpgradeAsyncTest()
        {
            await setResourceGroup();
            var name = Recording.GenerateAssetName("search");
            var data = new SearchServiceData(DefaultLocation)
            {
                SearchSkuName = SearchServiceSkuName.Standard,
                PartitionCount = 1,
                ReplicaCount = 1,
                HostingMode = SearchServiceHostingMode.Default
            };
            var searchService = (await SearchCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
            var upgradedService = (await searchService.UpgradeAsync(WaitUntil.Completed)).Value;

            Assert.IsNotNull(upgradedService);
            Assert.That(upgradedService.Data.ProvisioningState, Is.EqualTo(SearchServiceProvisioningState.Succeeded));
        }
    }
}
