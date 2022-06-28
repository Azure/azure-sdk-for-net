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
    public class AfdOriginGroupCollectionTests : CdnManagementTestBase
    {
        public AfdOriginGroupCollectionTests(bool isAsync)
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
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            FrontDoorOriginGroupResource afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfileResource, afdOriginGroupName);
            Assert.AreEqual(afdOriginGroupName, afdOriginGroupInstance.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorOriginGroups().CreateOrUpdateAsync(WaitUntil.Completed, null, afdOriginGroupInstance.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorOriginGroups().CreateOrUpdateAsync(WaitUntil.Completed, afdOriginGroupName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            _ = await CreateAfdOriginGroup(afdProfileResource, afdOriginGroupName);
            int count = 0;
            await foreach (var tempAfdOriginGroup in afdProfileResource.GetFrontDoorOriginGroups().GetAllAsync())
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
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            FrontDoorOriginGroupResource afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfileResource, afdOriginGroupName);
            FrontDoorOriginGroupResource getAfdOriginGroupInstance = await afdProfileResource.GetFrontDoorOriginGroups().GetAsync(afdOriginGroupName);
            ResourceDataHelper.AssertValidAfdOriginGroup(afdOriginGroupInstance, getAfdOriginGroupInstance);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorOriginGroups().GetAsync(null));
        }
    }
}
