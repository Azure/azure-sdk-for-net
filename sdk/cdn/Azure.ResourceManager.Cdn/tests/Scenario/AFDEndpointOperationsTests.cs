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
    public class AFDEndpointOperationsTests : CdnManagementTestBase
    {
        public AFDEndpointOperationsTests(bool isAsync)
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
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            await AFDEndpointInstance.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await AFDEndpointInstance.GetAsync());
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
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            AFDEndpointUpdateParameters updateParameters = new AFDEndpointUpdateParameters
            {
                OriginResponseTimeoutSeconds = 30
            };
            updateParameters.Tags.Add("newTag", "newValue");
            var lro = await AFDEndpointInstance.UpdateAsync(updateParameters);
            AFDEndpoint updatedAFDEndpointInstance = lro.Value;
            ResourceDataHelper.AssertAFDEndpointUpdate(updatedAFDEndpointInstance, updateParameters);
        }

        [TestCase]
        [RecordedTest]
        public async Task Purge()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            AfdPurgeParameters purgeParameters = new AfdPurgeParameters(new List<string>
            {
                "/*"
            });
            Assert.DoesNotThrowAsync(async () => await AFDEndpointInstance.PurgeContentAsync(purgeParameters));
        }

        [TestCase]
        [RecordedTest]
        public async Task Usages()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            int count = 0;
            await foreach (var tempUsage in AFDEndpointInstance.GetResourceUsageAsync())
            {
                count++;
                Assert.AreEqual(tempUsage.CurrentValue, 0);
                Assert.AreEqual(tempUsage.Unit, UsageUnit.Count);
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task ValidateCustomDomain()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            ValidateCustomDomainInput validateCustomDomainInput = new ValidateCustomDomainInput("customdomain4afd.azuretest.net");
            ValidateCustomDomainOutput validateCustomDomainOutput  = await AFDEndpointInstance.ValidateCustomDomainAsync(validateCustomDomainInput);
            Assert.False(validateCustomDomainOutput.CustomDomainValidated);
        }
    }
}
