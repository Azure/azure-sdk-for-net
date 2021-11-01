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
    public class AFDOriginCollectionTests : CdnManagementTestBase
    {
        public AFDOriginCollectionTests(bool isAsync)
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
            string AFDOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AFDOriginGroup AFDOriginGroupInstance = await CreateAFDOriginGroup(AFDProfile, AFDOriginGroupName);
            string AFDOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AFDOrigin AFDOriginInstance = await CreateAFDOrigin(AFDOriginGroupInstance, AFDOriginName);
            Assert.AreEqual(AFDOriginName, AFDOriginInstance.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDOriginGroupInstance.GetAFDOrigins().CreateOrUpdateAsync(null, AFDOriginInstance.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDOriginGroupInstance.GetAFDOrigins().CreateOrUpdateAsync(AFDOriginName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AFDOriginGroup AFDOriginGroupInstance = await CreateAFDOriginGroup(AFDProfile, AFDOriginGroupName);
            string AFDOriginName = Recording.GenerateAssetName("AFDOrigin-");
            _ = await CreateAFDOrigin(AFDOriginGroupInstance, AFDOriginName);
            int count = 0;
            await foreach (var tempAFDOrigin in AFDOriginGroupInstance.GetAFDOrigins().GetAllAsync())
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
            string AFDOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AFDOriginGroup AFDOriginGroupInstance = await CreateAFDOriginGroup(AFDProfile, AFDOriginGroupName);
            string AFDOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AFDOrigin AFDOriginInstance = await CreateAFDOrigin(AFDOriginGroupInstance, AFDOriginName);
            AFDOrigin getAFDOriginInstance = await AFDOriginGroupInstance.GetAFDOrigins().GetAsync(AFDOriginName);
            ResourceDataHelper.AssertValidAFDOrigin(AFDOriginInstance, getAFDOriginInstance);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDOriginGroupInstance.GetAFDOrigins().GetAsync(null));
        }
    }
}
