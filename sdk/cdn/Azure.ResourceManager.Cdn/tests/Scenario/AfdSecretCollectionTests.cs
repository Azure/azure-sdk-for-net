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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdSecretName = Recording.GenerateAssetName("AFDSecret-");
            AfdSecret afdSecret = await CreateAfdSecret(afdProfile, afdSecretName);
            Assert.AreEqual(afdSecretName, afdSecret.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfile.GetAfdSecrets().CreateOrUpdateAsync(null, afdSecret.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfile.GetAfdSecrets().CreateOrUpdateAsync(afdSecretName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdSecretName = Recording.GenerateAssetName("AFDSecret-");
            _ = await CreateAfdSecret(afdProfile, afdSecretName);
            int count = 0;
            await foreach (var tempSecret in afdProfile.GetAfdSecrets().GetAllAsync())
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
            string afdSecretName = Recording.GenerateAssetName("AFDSecret-");
            AfdSecret afdSecret = await CreateAfdSecret(afdProfile, afdSecretName);
            AfdSecret getAfdSecret = await afdProfile.GetAfdSecrets().GetAsync(afdSecretName);
            ResourceDataHelper.AssertValidAfdSecret(afdSecret, getAfdSecret);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfile.GetAfdSecrets().GetAsync(null));
        }
    }
}
