// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AFDEndpointCollectionTests : CdnManagementTestBase
    {
        public AFDEndpointCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            Assert.AreEqual(AFDEndpointName, AFDEndpointInstance.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetAFDEndpoints().CreateOrUpdateAsync(null, AFDEndpointInstance.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetAFDEndpoints().CreateOrUpdateAsync(AFDEndpointName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            _ = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            int count = 0;
            await foreach (var tempAFDEndpoint in AFDProfile.GetAFDEndpoints().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            AFDEndpoint getAFDEndpointInstance = await AFDProfile.GetAFDEndpoints().GetAsync(AFDEndpointName);
            ResourceDataHelper.AssertValidAFDEndpoint(AFDEndpointInstance, getAFDEndpointInstance);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetAFDEndpoints().GetAsync(null));
        }
    }
}
