// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdEndpointOperationsTests : CdnManagementTestBase
    {
        public AfdEndpointOperationsTests(bool isAsync)
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
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            FrontDoorEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            await afdEndpointInstance.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdEndpointInstance.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            FrontDoorEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            FrontDoorEndpointPatch updateOptions = new FrontDoorEndpointPatch();
            updateOptions.Tags.Add("newTag", "newValue");
            var lro = await afdEndpointInstance.UpdateAsync(WaitUntil.Completed, updateOptions);
            FrontDoorEndpointResource updatedAfdEndpointInstance = lro.Value;
            ResourceDataHelper.AssertAfdEndpointUpdate(updatedAfdEndpointInstance, updateOptions);
        }

        [TestCase]
        [RecordedTest]
        public async Task Purge()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            FrontDoorEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            FrontDoorPurgeContent purgeParameters = new FrontDoorPurgeContent(new List<string>
            {
                "/*"
            });
            Assert.DoesNotThrowAsync(async () => await afdEndpointInstance.PurgeContentAsync(WaitUntil.Completed, purgeParameters));
        }

        [TestCase]
        [RecordedTest]
        public async Task Usages()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            FrontDoorEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            int count = 0;
            await foreach (var tempUsage in afdEndpointInstance.GetResourceUsagesAsync())
            {
                count++;
                Assert.AreEqual(tempUsage.CurrentValue, 0);
                Assert.AreEqual(tempUsage.Unit, FrontDoorUsageUnit.Count);
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task ValidateCustomDomain()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            FrontDoorEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            ValidateCustomDomainContent validateCustomDomainContent = new ValidateCustomDomainContent("customdomain4afd.azuretest.net");
            ValidateCustomDomainResult validateCustomDomainOutput  = await afdEndpointInstance.ValidateCustomDomainAsync(validateCustomDomainContent);
            Assert.False(validateCustomDomainOutput.IsCustomDomainValid);
        }
    }
}
