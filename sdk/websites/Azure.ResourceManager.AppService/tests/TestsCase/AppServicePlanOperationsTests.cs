// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class AppServicePlanOperationsTests : AppServiceTestBase
    {
        public AppServicePlanOperationsTests(bool isAsync)
    : base(isAsync)
        {
        }

        private async Task<AppServicePlan> CreateAppServicePlanAsync(string appServicePlanName)
        {
            var container = (await CreateResourceGroupAsync()).GetAppServicePlans();
            var input = ResourceDataHelper.GetBasicAppServicePlanData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(appServicePlanName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var planName = Recording.GenerateAssetName("testAppServicePlan-");
            var plan = await CreateAppServicePlanAsync(planName);
            await plan.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var planName = Recording.GenerateAssetName("testDisk-");
            var plan1 = await CreateAppServicePlanAsync(planName);
            AppServicePlan plan2 = await plan1.GetAsync();

            ResourceDataHelper.AssertPlan(plan1.Data, plan2.Data);
        }
    }
}
