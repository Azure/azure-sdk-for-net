// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class AppServicePlanOperationsTests : AppServiceTestBase
    {
        public AppServicePlanOperationsTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<AppServicePlanResource> CreateAppServicePlanAsync(string appServicePlanName)
        {
            var container = (await CreateResourceGroupAsync()).GetAppServicePlans();
            var input = ResourceDataHelper.GetBasicAppServicePlanData(AzureLocation.EastUS2);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, appServicePlanName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var planName = Recording.GenerateAssetName("testAppServicePlan-");
            var plan = await CreateAppServicePlanAsync(planName);
            await plan.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var planName = Recording.GenerateAssetName("testDisk-");
            var plan1 = await CreateAppServicePlanAsync(planName);
            AppServicePlanResource plan2 = await plan1.GetAsync();

            ResourceDataHelper.AssertPlan(plan1.Data, plan2.Data);
        }

        [RecordedTest]
        public async Task GetServerFarmSkus()
        {
            var planName = Recording.GenerateAssetName("testDisk-");
            var plan = await CreateAppServicePlanAsync(planName);
            var skus = await plan.GetServerFarmSkusAsync();
            var dict = skus.Value.ToObjectFromJson() as Dictionary<string, object>;
        }

        [TestCase]
        public async Task GetWebApps()
        {
            var planName = Recording.GenerateAssetName("testDisk-");
            var plan1 = await CreateAppServicePlanAsync(planName);
            AppServicePlanResource plan2 = await plan1.GetAsync();
            var relays = plan2.GetHybridConnectionRelaysAsync();
            await foreach (var relayOverview in relays)
            {
                var relay = await plan2.GetAppServicePlanHybridConnectionNamespaceRelayAsync(relayOverview.ServiceBusNamespace,
                relayOverview.Name);
                var listOfAppServicesWhichAreUsingHybridConnection = relay.Value.GetWebAppsByHybridConnectionAsync();
            }
        }

        [RecordedTest]
        public async Task ExistingGetWebApps()
        {
            AppServicePlanResource plan = Client.GetAppServicePlanResource(new ResourceIdentifier("/subscriptions/4d042dc6-fe17-4698-a23f-ec6a8d1e98f4/resourceGroups/v-zihewang1211/providers/Microsoft.Web/serverFarms/hybirdtest"));
            var relays = plan.GetHybridConnectionRelaysAsync();
            int num = 0;
            await foreach (var relayOverview in relays)
            {
                num++;
                Console.WriteLine(num);
                Console.WriteLine(relayOverview.ServiceBusNamespace);
                Console.WriteLine(relayOverview.Name);
                var relay = await plan.GetAppServicePlanHybridConnectionNamespaceRelayAsync(relayOverview.ServiceBusNamespace, relayOverview.Name);
                var listOfAppServicesWhichAreUsingHybridConnection = relay.Value.GetWebAppsByHybridConnectionAsync();
                await foreach (var webApp in listOfAppServicesWhichAreUsingHybridConnection)
                {
                    Console.WriteLine(webApp.Name);
                }
            }
        }
    }
}
