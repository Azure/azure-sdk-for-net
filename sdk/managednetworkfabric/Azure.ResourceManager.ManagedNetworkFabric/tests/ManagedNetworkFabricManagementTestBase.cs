// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests
{
    public class ManagedNetworkFabricManagementTestBase : ManagementRecordedTestBase<ManagedNetworkFabricManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected ResourceGroupResource ResourceGroupResource { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected ManagedNetworkFabricManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ManagedNetworkFabricManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            Client = GetArmClient();

            var subscriptionId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            TestContext.Out.WriteLine($"Provided subscription-Id : {subscriptionId.SubscriptionId}");

            string resourceGroupName = TestEnvironment.ResourceGroupName;

            TestContext.Out.WriteLine($"Provided ResourceGroup: {resourceGroupName}");
            DefaultSubscription = Client.GetSubscriptionResource(subscriptionId);
            var resourceGroupId = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName);
            ResourceGroupResource = Client.GetResourceGroupResource(resourceGroupId);
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
