// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ResourceGraph.Tests
{
    public class ResourceGraphManagementTestBase : ManagementRecordedTestBase<ResourceGraphManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        public AzureLocation AzureLocation = AzureLocation.EastUS;
        public string DefaultRgnamePrefix = "Test";
        public SubscriptionResource DefaultSubscription { get; private set; }

        protected ResourceGraphManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ResourceGraphManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription)
        {
            string rgName = Recording.GenerateAssetName(DefaultRgnamePrefix);
            ResourceGroupData input = new ResourceGroupData(AzureLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
