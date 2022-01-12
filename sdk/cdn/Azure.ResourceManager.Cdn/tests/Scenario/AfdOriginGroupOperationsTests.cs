// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdOriginGroupOperationsTests : CdnManagementTestBase
    {
        public AfdOriginGroupOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroup afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            await afdOriginGroupInstance.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdOriginGroupInstance.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroup afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            AfdOriginGroupUpdateOptions updateOptions = new AfdOriginGroupUpdateOptions
            {
                LoadBalancingSettings = new LoadBalancingSettingsParameters
                {
                    SampleSize = 10,
                    SuccessfulSamplesRequired = 5,
                    AdditionalLatencyInMilliseconds = 500
                }
            };
            var lro = await afdOriginGroupInstance.UpdateAsync(updateOptions);
            AfdOriginGroup updatedAfdOriginGroupInstance = lro.Value;
            ResourceDataHelper.AssertAfdOriginGroupUpdate(updatedAfdOriginGroupInstance, updateOptions);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceUsage()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroup afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            int count = 0;
            await foreach (var tempUsage in afdOriginGroupInstance.GetResourceUsageAsync())
            {
                count++;
                Assert.AreEqual(tempUsage.Unit, UsageUnit.Count);
                Assert.AreEqual(tempUsage.CurrentValue, 0);
            }
            Assert.AreEqual(count, 1);
        }
    }
}
