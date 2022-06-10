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
    public class AfdEndpointCollectionTests : CdnManagementTestBase
    {
        public AfdEndpointCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            FrontDoorEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfileResource, afdEndpointName);
            Assert.AreEqual(afdEndpointName, afdEndpointInstance.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, null, afdEndpointInstance.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, afdEndpointName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            _ = await CreateAfdEndpoint(afdProfileResource, afdEndpointName);
            int count = 0;
            await foreach (var tempAFDEndpoint in afdProfileResource.GetFrontDoorEndpoints().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            FrontDoorEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfileResource, afdEndpointName);
            FrontDoorEndpointResource getAfdEndpointInstance = await afdProfileResource.GetFrontDoorEndpoints().GetAsync(afdEndpointName);
            ResourceDataHelper.AssertValidAfdEndpoint(afdEndpointInstance, getAfdEndpointInstance);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorEndpoints().GetAsync(null));
        }
    }
}
