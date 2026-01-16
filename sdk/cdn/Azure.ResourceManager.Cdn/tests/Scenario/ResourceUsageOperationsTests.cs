// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class ResourceUsageOperationsTests : CdnManagementTestBase
    {
        public ResourceUsageOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceUsage()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            _ = await CreateCdnProfile(rg, profileName, CdnSkuName.StandardVerizon);
            int count = 0;
            await foreach (var tempResourceUsage in subscription.GetResourceUsagesAsync())
            {
                count++;
                if (tempResourceUsage.ResourceType.Equals("profile"))
                {
                    Assert.That(tempResourceUsage.CurrentValue, Is.GreaterThan(0));
                    Assert.That(tempResourceUsage.Limit, Is.EqualTo(200));
                }
            }
            Assert.That(count, Is.EqualTo(2));
        }
    }
}
