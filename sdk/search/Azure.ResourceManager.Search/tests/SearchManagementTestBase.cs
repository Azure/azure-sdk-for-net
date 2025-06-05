// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Search.Tests
{
    public class SearchManagementTestBase : ManagementRecordedTestBase<SearchManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        public AzureLocation DefaultLocation => "eastus2euap";

        public SubscriptionResource DefaultLSubscription { get; set; }

        protected SearchManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$.value.[*].key");
        }

        protected SearchManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            JsonPathSanitizers.Add("$.value.[*].key");
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultLSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string rgName = Recording.GenerateAssetName("sdk-test");
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultLSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
