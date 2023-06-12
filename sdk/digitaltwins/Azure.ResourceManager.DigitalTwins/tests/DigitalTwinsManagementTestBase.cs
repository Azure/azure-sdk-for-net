// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DigitalTwins.Tests
{
    public class DigitalTwinsManagementTestBase : ManagementRecordedTestBase<DigitalTwinsManagementTestEnvironment>
    {
        protected AzureLocation Location { get; private set; } = AzureLocation.WestCentralUS;

        protected ArmClient Client { get; private set; }

        protected SubscriptionResource Subscription { get; private set; }

        protected ResourceGroupResource ResourceGroup { get; private set; }

        protected DigitalTwinsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected DigitalTwinsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonTestResources()
        {
            Client = GetArmClient();
            Subscription = await Client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId).ConfigureAwait(false);
            ResourceGroup = await CreateResourceGroup(Subscription, "digitaltwins-sdk-tests", Location).ConfigureAwait(false);
        }

        [TearDown]
        public async Task DeleteCommonTestResources()
        {
            await ResourceGroup.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
