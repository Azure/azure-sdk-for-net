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
    public class AfdSecretCollectionTests : CdnManagementTestBase
    {
        public AfdSecretCollectionTests(bool isAsync)
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
            string afdSecretName = Recording.GenerateAssetName("AFDSecret-");
            FrontDoorSecretResource afdSecret = await CreateAfdSecret(afdProfileResource, afdSecretName);
            Assert.AreEqual(afdSecretName, afdSecret.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorSecrets().CreateOrUpdateAsync(WaitUntil.Completed, null, afdSecret.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorSecrets().CreateOrUpdateAsync(WaitUntil.Completed, afdSecretName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdSecretName = Recording.GenerateAssetName("AFDSecret-");
            _ = await CreateAfdSecret(afdProfileResource, afdSecretName);
            int count = 0;
            await foreach (var tempSecret in afdProfileResource.GetFrontDoorSecrets().GetAllAsync())
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
            string afdSecretName = Recording.GenerateAssetName("AFDSecret-");
            FrontDoorSecretResource afdSecret = await CreateAfdSecret(afdProfileResource, afdSecretName);
            FrontDoorSecretResource getAfdSecret = await afdProfileResource.GetFrontDoorSecrets().GetAsync(afdSecretName);
            ResourceDataHelper.AssertValidAfdSecret(afdSecret, getAfdSecret);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorSecrets().GetAsync(null));
        }
    }
}
