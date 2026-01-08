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
            Assert.That(ex.Status, Is.EqualTo(404));
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
            Assert.That(ssoUri, Is.Not.Null);
            Assert.That(ssoUri.AvailableSsoUri.ToString(), Does.StartWith("https://"));
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
            Assert.That(optimizationTypesList, Is.Not.Null);
            Assert.That(optimizationTypesList.SupportedOptimizationTypes, Is.Not.Null);
            Assert.That(optimizationTypesList.SupportedOptimizationTypes.Count, Is.GreaterThan(0));
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
                Assert.Multiple(() =>
                {
                    Assert.That(tempResourceUsage.ResourceType, Is.EqualTo("endpoint"));
                    Assert.That(CdnUsageUnit.Count, Is.EqualTo(tempResourceUsage.Unit));
                    Assert.That(tempResourceUsage.CurrentValue, Is.EqualTo(0));
                    Assert.That(tempResourceUsage.Limit, Is.EqualTo(25));
                });
            }
            Assert.That(count, Is.EqualTo(1));
        }
    }
}
