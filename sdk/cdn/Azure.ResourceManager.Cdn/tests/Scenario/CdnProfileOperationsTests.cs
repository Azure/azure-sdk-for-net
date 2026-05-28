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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardVerizon);
            await cdnProfile.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await cdnProfile.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        //TODO: [TestCase(null)] Need to be able to re-record this case
        [TestCase(true)]
        //TODO: [TestCase(false)] Need to be able to re-record this case
        public async Task Update(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardVerizon);
            var lro = await cdnProfile.AddTagAsync("newTag", "newValue");
            ProfileResource updatedCdnProfile = lro.Value;
            ResourceDataHelper.AssertProfileUpdate(updatedCdnProfile, "newTag", "newValue");
        }

        [TestCase]
        [RecordedTest]
        public async Task GenerateSsoUri()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardVerizon);
            SsoUri ssoUri = await cdnProfile.GenerateSsoUriAsync();
            Assert.NotNull(ssoUri);
            Assert.True(ssoUri.AvailableSsoUri.ToString().StartsWith("https://"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetSupportedOptimizationTypes()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardVerizon);
            SupportedOptimizationTypesListResult optimizationTypesList = await cdnProfile.GetSupportedOptimizationTypesAsync();
            Assert.NotNull(optimizationTypesList);
            Assert.NotNull(optimizationTypesList.SupportedOptimizationTypes);
            Assert.Greater(optimizationTypesList.SupportedOptimizationTypes.Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceUsage()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardVerizon);
            int count = 0;
            await foreach (var tempResourceUsage in cdnProfile.GetResourceUsagesAsync())
            {
                count++;
                Assert.AreEqual(tempResourceUsage.ResourceType, "endpoint");
                Assert.AreEqual(tempResourceUsage.Unit, CdnUsageUnit.Count);
                Assert.AreEqual(tempResourceUsage.CurrentValue, 0);
                Assert.AreEqual(tempResourceUsage.Limit, 25);
            }
            Assert.AreEqual(count, 1);
        }
    }
}
