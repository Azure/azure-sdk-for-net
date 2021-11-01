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
    public class AFDOriginGroupCollectionTests : CdnManagementTestBase
    {
        public AFDOriginGroupCollectionTests(bool isAsync)
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
            Assert.AreEqual(AFDOriginGroupName, AFDOriginGroupInstance.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetAFDOriginGroups().CreateOrUpdateAsync(null, AFDOriginGroupInstance.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetAFDOriginGroups().CreateOrUpdateAsync(AFDOriginGroupName, null));
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
            _ = await CreateAFDOriginGroup(AFDProfile, AFDOriginGroupName);
            int count = 0;
            await foreach (var tempAFDOriginGroup in AFDProfile.GetAFDOriginGroups().GetAllAsync())
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
            AFDOriginGroup getAFDOriginGroupInstance = await AFDProfile.GetAFDOriginGroups().GetAsync(AFDOriginGroupName);
            ResourceDataHelper.AssertValidAFDOriginGroup(AFDOriginGroupInstance, getAFDOriginGroupInstance);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetAFDOriginGroups().GetAsync(null));
        }
    }
}
