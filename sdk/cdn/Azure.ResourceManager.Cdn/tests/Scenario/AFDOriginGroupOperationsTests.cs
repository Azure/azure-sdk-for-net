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
    public class AFDOriginGroupOperationsTests : CdnManagementTestBase
    {
        public AFDOriginGroupOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AFDOriginGroup AFDOriginGroupInstance = await CreateAFDOriginGroup(AFDProfile, AFDOriginGroupName);
            await AFDOriginGroupInstance.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await AFDOriginGroupInstance.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AFDOriginGroup AFDOriginGroupInstance = await CreateAFDOriginGroup(AFDProfile, AFDOriginGroupName);
            AFDOriginGroupUpdateParameters updateParameters = new AFDOriginGroupUpdateParameters
            {
                LoadBalancingSettings = new LoadBalancingSettingsParameters
                {
                    SampleSize = 10,
                    SuccessfulSamplesRequired = 5,
                    AdditionalLatencyInMilliseconds = 500
                }
            };
            var lro = await AFDOriginGroupInstance.UpdateAsync(updateParameters);
            AFDOriginGroup updatedAFDOriginGroupInstance = lro.Value;
            ResourceDataHelper.AssertAFDOriginGroupUpdate(updatedAFDOriginGroupInstance, updateParameters);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceUsage()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AFDOriginGroup AFDOriginGroupInstance = await CreateAFDOriginGroup(AFDProfile, AFDOriginGroupName);
            int count = 0;
            await foreach (var tempUsage in AFDOriginGroupInstance.GetResourceUsageAsync())
            {
                count++;
                Assert.AreEqual(tempUsage.Unit, UsageUnit.Count);
                Assert.AreEqual(tempUsage.CurrentValue, 0);
            }
            Assert.AreEqual(count, 1);
        }
    }
}
