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
    public class PythonWebAppTotalTests : AppServiceTestBase
    {
        public PythonWebAppTotalTests(bool isAsync)
           : base(isAsync, Azure.Core.TestFramework.RecordedTestMode.Record)
        {
        }
        private async Task<AppServicePlanContainer> GetAppServicePlanContainerAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            //var AppServicePlanName = Recording.GenerateAssetName("testAppServicePlan_");
            //var PlanInput = ResourceDataHelper.GetBasicAppServicePlanData("AZURE_LOCATION");
            //var lro = await resourceGroup.GetAppServicePlans().CreateOrUpdateAsync(AppServicePlanName, PlanInput);
            //var appServicePlan = lro.Value;
            return resourceGroup.GetAppServicePlans();
        }

        [TestCase]
        [RecordedTest]
        public async Task AppServicePlanCreateOrUpdate()
        {
            var container = await GetAppServicePlanContainerAsync();
            var name = Recording.GenerateAssetName("testAppServicePlan_");
            var input = ResourceDataHelper.GetBasicAppServicePlanData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(name, input);
            var appServicePlan = lro.Value;
            Assert.AreEqual(name, appServicePlan.Data.Name);
        }
    }
}
