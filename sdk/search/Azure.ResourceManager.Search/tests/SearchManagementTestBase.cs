// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Search.Tests
{
    public class SearchManagementTestBase : ManagementRecordedTestBase<SearchManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        public AzureLocation DefaultLocation => "westus";

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
            Client = GetArmClient();
            DefaultLSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string rgName = Recording.GenerateAssetName("Search-SDK-Test");
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultLSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
