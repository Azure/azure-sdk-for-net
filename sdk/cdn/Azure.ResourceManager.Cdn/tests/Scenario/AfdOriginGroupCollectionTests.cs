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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroup afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            Assert.AreEqual(afdOriginGroupName, afdOriginGroupInstance.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfile.GetAfdOriginGroups().CreateOrUpdateAsync(null, afdOriginGroupInstance.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfile.GetAfdOriginGroups().CreateOrUpdateAsync(afdOriginGroupName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            _ = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            int count = 0;
            await foreach (var tempAfdOriginGroup in afdProfile.GetAfdOriginGroups().GetAllAsync())
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
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroup afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            AfdOriginGroup getAfdOriginGroupInstance = await afdProfile.GetAfdOriginGroups().GetAsync(afdOriginGroupName);
            ResourceDataHelper.AssertValidAfdOriginGroup(afdOriginGroupInstance, getAfdOriginGroupInstance);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfile.GetAfdOriginGroups().GetAsync(null));
        }
    }
}
