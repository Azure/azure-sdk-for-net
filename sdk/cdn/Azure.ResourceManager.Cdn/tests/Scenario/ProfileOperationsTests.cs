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
    public class ProfileOperationsTests : CdnManagementTestBase
    {
        public ProfileOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardAkamai);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            await profile.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await profile.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardAkamai);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            ProfileUpdateParameters updateParameters = new ProfileUpdateParameters();
            updateParameters.Tags.Add("newTag", "newValue");
            var lro2 = await profile.UpdateAsync(updateParameters);
            Profile updatedProfile = lro2.Value;
            AssertProfileUpdate(updatedProfile, updateParameters);
        }

        [TestCase]
        [RecordedTest]
        public async Task GenerateSsoUri()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardVerizon);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            SsoUri ssoUri = await profile.GenerateSsoUriAsync();
            Assert.NotNull(ssoUri);
            Assert.True(ssoUri.SsoUriValue.StartsWith("https://"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetSupportedOptimizationTypes()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardAkamai);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            SupportedOptimizationTypesListResult optimizationTypesList = await profile.GetSupportedOptimizationTypesAsync();
            Assert.NotNull(optimizationTypesList);
            Assert.NotNull(optimizationTypesList.SupportedOptimizationTypes);
            Assert.Greater(optimizationTypesList.SupportedOptimizationTypes.Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceUsage()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            ProfileData profileData = CreateProfileData(SkuName.StandardAkamai);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            Profile profile = lro.Value;
            int count = 0;
            await foreach (var tempResourceUsage in profile.GetResourceUsageAsync())
            {
                count++;
                Assert.AreEqual(tempResourceUsage.ResourceType, "endpoint");
                Assert.AreEqual(tempResourceUsage.Unit, "count");
                Assert.AreEqual(tempResourceUsage.CurrentValue, 0);
                Assert.AreEqual(tempResourceUsage.Limit, 25);
            }
            Assert.AreEqual(count, 1);
        }

        //[TestCase]
        //[RecordedTest]
        //public async Task CheckHostNameAvaiability()
        //{
        //    ResourceGroup rg = await CreateResourceGroup("testRg-");
        //}

        //[TestCase]
        //[RecordedTest]
        //public async Task GetLogAnalyticsMetrics()
        //{
        //    ResourceGroup rg = await CreateResourceGroup("testRg-");
        //}

        //[TestCase]
        //[RecordedTest]
        //public async Task GetLogAnalyticsRankings()
        //{
        //    ResourceGroup rg = await CreateResourceGroup("testRg-");
        //}

        //[TestCase]
        //[RecordedTest]
        //public async Task GetLogAnalyticsLocations()
        //{
        //    ResourceGroup rg = await CreateResourceGroup("testRg-");
        //}

        //[TestCase]
        //[RecordedTest]
        //public async Task GetLogAnalyticsResources()
        //{
        //    ResourceGroup rg = await CreateResourceGroup("testRg-");
        //}

        //[TestCase]
        //[RecordedTest]
        //public async Task GetWafLogAnalyticsMetrics()
        //{
        //    ResourceGroup rg = await CreateResourceGroup("testRg-");
        //}

        //[TestCase]
        //[RecordedTest]
        //public async Task GetWafLogAnalyticsRankings()
        //{
        //    ResourceGroup rg = await CreateResourceGroup("testRg-");
        //}

        //[TestCase]
        //[RecordedTest]
        //public async Task CheckResourceUsage()
        //{
        //    ResourceGroup rg = await CreateResourceGroup("testRg-");
        //}

        private static void AssertProfileUpdate(Profile updatedProfile, ProfileUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedProfile.Data.Tags.Count, updateParameters.Tags.Count);
            foreach (var kv in updatedProfile.Data.Tags)
            {
                Assert.True(updateParameters.Tags.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value, updateParameters.Tags[kv.Key]);
            }
        }
    }
}
