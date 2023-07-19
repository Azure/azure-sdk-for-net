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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            FrontDoorOriginGroupResource afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfileResource, afdOriginGroupName);
            await afdOriginGroupInstance.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdOriginGroupInstance.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            FrontDoorOriginGroupResource afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfileResource, afdOriginGroupName);
            FrontDoorOriginGroupPatch updateOptions = new FrontDoorOriginGroupPatch
            {
                LoadBalancingSettings = new LoadBalancingSettings
                {
                    SampleSize = 10,
                    SuccessfulSamplesRequired = 5,
                    AdditionalLatencyInMilliseconds = 500
                }
            };
            var lro = await afdOriginGroupInstance.UpdateAsync(WaitUntil.Completed, updateOptions);
            FrontDoorOriginGroupResource updatedAfdOriginGroupInstance = lro.Value;
            ResourceDataHelper.AssertAfdOriginGroupUpdate(updatedAfdOriginGroupInstance, updateOptions);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceUsage()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            FrontDoorOriginGroupResource afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfileResource, afdOriginGroupName);
            int count = 0;
            await foreach (var tempUsage in afdOriginGroupInstance.GetResourceUsagesAsync())
            {
                count++;
                Assert.AreEqual(tempUsage.Unit, FrontDoorUsageUnit.Count);
                Assert.AreEqual(tempUsage.CurrentValue, 0);
            }
            Assert.AreEqual(count, 1);
        }
    }
}
