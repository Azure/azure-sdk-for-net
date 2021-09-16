// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class ProfileContainerTests : CdnManagementTestBase
    {
        public ProfileContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardAkamai);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            Assert.AreEqual(profileName, profile.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().CreateOrUpdateAsync(null, profileData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().CreateOrUpdateAsync(profileName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByRg()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardAkamai);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            _ = lro.Value;
            int count = 0;
            await foreach (var tempProfile in rg.GetProfiles().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListBySubscription()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardAkamai);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            int count = 0;
            await foreach (var tempProfile in Client.DefaultSubscription.GetProfilesAsync())
            {
                if (tempProfile.Data.Id == profile.Data.Id)
                {
                    count++;
                }
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardAkamai);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            Profile getProfile = await rg.GetProfiles().GetAsync(profileName);
            AssertValidProfile(profile, getProfile);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetProfiles().GetAsync(null));
        }

        private static void AssertValidProfile(Profile model, Profile getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.Sku.Name, getResult.Data.Sku.Name);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.FrontdoorId, getResult.Data.FrontdoorId);
        }
    }
}
