// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardAkamai);
            await profile.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await profile.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardAkamai);
            ProfileUpdateParameters updateParameters = new ProfileUpdateParameters();
            updateParameters.Tags.Add("newTag", "newValue");
            var lro = await profile.UpdateAsync(updateParameters);
            Profile updatedProfile = lro.Value;
            ResourceDataHelper.AssertProfileUpdate(updatedProfile, updateParameters);
        }

        [TestCase]
        [RecordedTest]
        public async Task GenerateSsoUri()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardVerizon);
            SsoUri ssoUri = await profile.GenerateSsoUriAsync();
            Assert.NotNull(ssoUri);
            Assert.True(ssoUri.SsoUriValue.StartsWith("https://"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetSupportedOptimizationTypes()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardAkamai);
            SupportedOptimizationTypesListResult optimizationTypesList = await profile.GetSupportedOptimizationTypesAsync();
            Assert.NotNull(optimizationTypesList);
            Assert.NotNull(optimizationTypesList.SupportedOptimizationTypes);
            Assert.Greater(optimizationTypesList.SupportedOptimizationTypes.Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceUsage()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardAkamai);
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
    }
}
