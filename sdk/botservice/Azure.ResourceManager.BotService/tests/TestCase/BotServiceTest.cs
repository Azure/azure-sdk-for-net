// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.BotService.Models;
using Azure.ResourceManager.BotService.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.BotService.Tests
{
    public class BotServiceTest : BotServiceManagementTestBase
    {
        public BotServiceTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task ProviderApiTest()
        {
            //1.Create
            var botName = Recording.GenerateAssetName("testbotService");
            var botName2 = Recording.GenerateAssetName("testbotservice");
            var botName3 = Recording.GenerateAssetName("testbotService");
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = resourceGroup.GetBots();
            var input = ResourceDataHelpers.GetBotData();
            var resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, botName, input)).Value;
            Assert.AreEqual(botName, resource.Data.Name);
            //2.Get
            var resource2 = (await resource.GetAsync()).Value;
            ResourceDataHelpers.AssertBotServiceData(resource.Data, resource2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, botName2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, botName3, input);
            int count = 0;
            await foreach (var item in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4.Exist
            Assert.IsTrue(await collection.ExistsAsync(botName));
            Assert.IsFalse(await collection.ExistsAsync(botName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resouece operation
            //1.Get
            var rResource3 = (await resource.GetAsync()).Value;
            ResourceDataHelpers.AssertBotServiceData(resource.Data, rResource3.Data);
            //2.Update
            var patch = new BotData(AzureLocation.EastUS)
            {
                Properties = new BotProperties("The Name of the bot", new Uri("http://mybot.coffee"), "exampleappid")
                {
                    Description = "The description of the bot",
                    IconUri = new Uri("http://myicon"),
                    MsaAppType = BotMsaAppType.UserAssignedMSI,
                    MsaAppTenantId = "exampleapptenantid",
                    MsaAppMSIResourceId = new ResourceIdentifier("/subscriptions/foo/resourcegroups/bar/providers/microsoft.managedidentity/userassignedidentities/sampleId"),
                    DeveloperAppInsightKey = "appinsightskey",
                    DeveloperAppInsightsApiKey = "appinsightsapikey",
                    DeveloperAppInsightsApplicationId = "appinsightsappid",
                    LuisAppIds =
                    {
                        "luisappid1","luisappid2"
                    },
                    LuisKey = "luiskey",
                    IsCmekEnabled = true,
                    CmekKeyVaultUri = new Uri("https://myCmekKey"),
                    PublicNetworkAccess = BotServicePublicNetworkAccess.Enabled,
                    IsLocalAuthDisabled = true,
                    SchemaTransformationVersion = "1.0",
                },
                Sku = new BotServiceSku(BotServiceSkuName.S1),
                Kind = BotServiceKind.Sdk,
                ETag = new ETag("etag1"),
                Tags =
                {
                    ["UpdateKey1"] = "UpdateValue1",
                    ["UpdateKey1"] = "UpdateValue1",
                    ["UpdateKey1"] = "UpdateValue1"
                },
            };
            var resource4 = (await rResource3.UpdateAsync(patch)).Value;
            ResourceDataHelpers.AssertBotServiceData(patch, resource4.Data);
            //3. Delete
            await resource4.DeleteAsync(WaitUntil.Completed);
        }
    }
}
