// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class AppServicePlanCollectionTests : AppServiceTestBase
    {
        public AppServicePlanCollectionTests(bool isAsync)
           : base(isAsync)
        {
        }

        private async Task<AppServicePlanCollection> GetAppServicePlanCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetAppServicePlans();
        }

        [TestCase]
        [RecordedTest]
        public async Task AppServicePlanCreateOrUpdate()
        {
            var container = await GetAppServicePlanCollectionAsync();
            var name = Recording.GenerateAssetName("testAppServicePlan");
            var input = ResourceDataHelper.GetBasicAppServicePlanData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            var appServicePlan = lro.Value;
            Assert.AreEqual(name, appServicePlan.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetAppServicePlanCollectionAsync();
            var planName = Recording.GenerateAssetName("testAppServicePlan-");
            var input = ResourceDataHelper.GetBasicAppServicePlanData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, planName, input);
            AppServicePlanResource plan1 = lro.Value;
            AppServicePlanResource plan2 = await container.GetAsync(planName);
            ResourceDataHelper.AssertPlan(plan1.Data, plan2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetAppServicePlanCollectionAsync();
            var input = ResourceDataHelper.GetBasicAppServicePlanData(DefaultLocation);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAppService-"), input);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAppService-"), input);
            int count = 0;
            await foreach (var appServicePlan in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var container = await GetAppServicePlanCollectionAsync();
            var planName = Recording.GenerateAssetName("testAppService-");
            var input = ResourceDataHelper.GetBasicAppServicePlanData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, planName, input);
            AppServicePlanResource plan = lro.Value;
            Assert.IsTrue(await container.ExistsAsync(planName));
            Assert.IsFalse(await container.ExistsAsync(planName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}
