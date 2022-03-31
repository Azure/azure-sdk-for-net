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
            AfdEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfileResource, afdEndpointName);
            Assert.AreEqual(afdEndpointName, afdEndpointInstance.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetAfdEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, null, afdEndpointInstance.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetAfdEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, afdEndpointName, null));
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
            await foreach (var tempAFDEndpoint in afdProfileResource.GetAfdEndpoints().GetAllAsync())
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
            AfdEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfileResource, afdEndpointName);
            AfdEndpointResource getAfdEndpointInstance = await afdProfileResource.GetAfdEndpoints().GetAsync(afdEndpointName);
            ResourceDataHelper.AssertValidAfdEndpoint(afdEndpointInstance, getAfdEndpointInstance);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetAfdEndpoints().GetAsync(null));
        }
    }
}
