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
    public class CdnProfileOperationsTests : CdnManagementTestBase
    {
        public CdnProfileOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardAkamai);
            await cdnProfile.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await cdnProfile.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardAkamai);
            ProfileUpdateOptions updateOptions = new ProfileUpdateOptions();
            updateOptions.Tags.Add("newTag", "newValue");
            var lro = await cdnProfile.UpdateAsync(updateOptions);
            Profile updatedCdnProfile = lro.Value;
            ResourceDataHelper.AssertProfileUpdate(updatedCdnProfile, updateOptions);
        }

        [TestCase]
        [RecordedTest]
        public async Task GenerateSsoUri()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardVerizon);
            SsoUri ssoUri = await cdnProfile.GenerateSsoUriAsync();
            Assert.NotNull(ssoUri);
            Assert.True(ssoUri.SsoUriValue.StartsWith("https://"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetSupportedOptimizationTypes()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardAkamai);
            SupportedOptimizationTypesListResult optimizationTypesList = await cdnProfile.GetSupportedOptimizationTypesAsync();
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
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardAkamai);
            int count = 0;
            await foreach (var tempResourceUsage in cdnProfile.GetResourceUsageAsync())
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
