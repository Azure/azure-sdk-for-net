// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdRuleSetOperationsTests : CdnManagementTestBase
    {
        public AfdRuleSetOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            FrontDoorRuleSetResource afdRuleSet = await CreateAfdRuleSet(afdProfileResource, afdRuleSetName);
            await afdRuleSet.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdRuleSet.GetAsync());
            Assert.That(ex.Status, Is.EqualTo(404));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceUsage()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            FrontDoorRuleSetResource afdRuleSet = await CreateAfdRuleSet(afdProfileResource, afdRuleSetName);
            int count = 0;
            await foreach (var tempUsage in afdRuleSet.GetResourceUsagesAsync())
            {
                count++;
                Assert.Multiple(() =>
                {
                    Assert.That(FrontDoorUsageUnit.Count, Is.EqualTo(tempUsage.Unit));
                    Assert.That(tempUsage.CurrentValue, Is.EqualTo(0));
                });
            }
            Assert.That(count, Is.EqualTo(1));
        }
    }
}
