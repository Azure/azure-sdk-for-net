// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Search.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Search.Tests
{
    public class SearchManagementTestBase : ManagementRecordedTestBase<SearchManagementTestEnvironment>
    {
        private readonly HashSet<ResourceIdentifier> _createdServices = new HashSet<ResourceIdentifier>();

        protected ArmClient Client { get; private set; }

        public AzureLocation DefaultLocation => TestEnvironment.GetSearchLocation();

        public SubscriptionResource DefaultLSubscription { get; set; }

        protected SearchManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$.value.[*].key");
            JsonPathSanitizers.Add("$..key");

            UriRegexSanitizers.Add(new UriRegexSanitizer("deleteQueryKey/(?<key>[^/]+)\\?api-version")
            {
                GroupForReplace = "key",
                Value = "{sanitized-query-key}"
            });
        }

        protected SearchManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            JsonPathSanitizers.Add("$.value.[*].key");
            JsonPathSanitizers.Add("$..key");

            UriRegexSanitizers.Add(new UriRegexSanitizer("deleteQueryKey/(?<key>[^/]+)\\?api-version")
            {
                GroupForReplace = "key",
                Value = "{sanitized-query-key}"
            });
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            _createdServices.Clear();
            Client = GetArmClient();
            DefaultLSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string existingGroup = TestEnvironment.ExistingResourceGroup;
            if (existingGroup is not null)
            {
                ResourceIdentifier id = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, existingGroup);
                return (await Client.GetResourceGroupResource(id).GetAsync()).Value;
            }

            string rgName = Recording.GenerateAssetName("SSS3PT_Search-SDK-Test");
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultLSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected string GenerateSearchServiceName(string prefix = "search")
        {
            // Preserve the random sequence and names used by older recordings.
            string legacyName = Recording.GenerateAssetName(prefix);
            string defaultName = Mode == RecordedTestMode.Playback ? null : $"{prefix}-{Guid.NewGuid():N}";
            return Recording.GetVariable($"SERVICE_NAME_{legacyName}", defaultName) ?? legacyName;
        }

        protected async Task<ArmOperation<SearchServiceResource>> CreateSearchServiceAsync(
            SearchServiceCollection collection, string name, SearchServiceData data)
        {
            string existingGroup = TestEnvironment.ExistingResourceGroup;
            if (existingGroup is not null)
            {
                Assert.AreEqual(existingGroup, collection.Id.ResourceGroupName, "Only the configured existing resource group may be used.");
                ResourceIdentifier id = SearchServiceResource.CreateResourceIdentifier(
                    TestEnvironment.SubscriptionId, existingGroup, name);
                if (!_createdServices.Contains(id))
                {
                    Assert.IsFalse((await collection.ExistsAsync(name)).Value, $"Refusing to overwrite existing service {id}.");
                    _createdServices.Add(id);
                    TestContext.Progress.WriteLine($"Creating temporary service: {id}");
                }
            }

            return await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data, new SearchManagementRequestOptions());
        }

        [TearDown]
        public async Task CleanupCreatedServicesAsync()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }

            using (Recording.DisableRecording())
            {
                await Task.WhenAll(_createdServices.Select(async id =>
                {
                    try
                    {
                        TestContext.Progress.WriteLine($"Deleting temporary service: {id}");
                        await Client.GetSearchServiceResource(id).DeleteAsync(WaitUntil.Completed);
                    }
                    catch (RequestFailedException exception) when (exception.Status == 404)
                    {
                        TestContext.Progress.WriteLine($"Temporary service already absent: {id}");
                    }
                }));
            }
        }
    }
}
