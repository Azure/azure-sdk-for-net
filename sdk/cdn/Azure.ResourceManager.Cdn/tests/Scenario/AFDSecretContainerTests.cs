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
    public class AFDSecretContainerTests : CdnManagementTestBase
    {
        public AFDSecretContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string secretName = Recording.GenerateAssetName("AFDSecret-");
            Secret secret = await CreateSecret(AFDProfile, secretName);
            Assert.AreEqual(secretName, secret.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetSecrets().CreateOrUpdateAsync(null, secret.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetSecrets().CreateOrUpdateAsync(secretName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string secretName = Recording.GenerateAssetName("AFDSecret-");
            _ = await CreateSecret(AFDProfile, secretName);
            int count = 0;
            await foreach (var tempSecret in AFDProfile.GetSecrets().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string secretName = Recording.GenerateAssetName("AFDSecret-");
            Secret secret = await CreateSecret(AFDProfile, secretName);
            Secret getSecret = await AFDProfile.GetSecrets().GetAsync(secretName);
            ResourceDataHelper.AssertValidSecret(secret, getSecret);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetSecrets().GetAsync(null));
        }
    }
}
