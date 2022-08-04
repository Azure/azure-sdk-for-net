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
    public class AfdOriginCollectionTests : CdnManagementTestBase
    {
        public AfdOriginCollectionTests(bool isAsync)
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
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            FrontDoorOriginResource afdOriginInstance = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            Assert.AreEqual(afdOriginName, afdOriginInstance.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdOriginGroupInstance.GetFrontDoorOrigins().CreateOrUpdateAsync(WaitUntil.Completed, null, afdOriginInstance.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdOriginGroupInstance.GetFrontDoorOrigins().CreateOrUpdateAsync(WaitUntil.Completed, afdOriginName, null));
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
            FrontDoorOriginGroupResource afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfileResource, afdOriginGroupName);
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            _ = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            int count = 0;
            await foreach (var tempAfdOrigin in afdOriginGroupInstance.GetFrontDoorOrigins().GetAllAsync())
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
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            FrontDoorOriginResource afdOriginInstance = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            FrontDoorOriginResource getAfdOriginInstance = await afdOriginGroupInstance.GetFrontDoorOrigins().GetAsync(afdOriginName);
            ResourceDataHelper.AssertValidAfdOrigin(afdOriginInstance, getAfdOriginInstance);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdOriginGroupInstance.GetFrontDoorOrigins().GetAsync(null));
        }
    }
}
