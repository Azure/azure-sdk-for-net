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
    internal class BotDirectLneChannelTest : BotServiceManagementTestBase
    {
        public BotDirectLneChannelTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("CHANNEL_NOT_SUPPORTED")]
        public async Task ProviderApiTest()
        {
            //1.Create
            var botName = Recording.GenerateAssetName("testbotService");
            var channelName = Recording.GenerateAssetName("testchannel");
            var channelName2 = Recording.GenerateAssetName("testchannel");
            var channelName3 = Recording.GenerateAssetName("testchannel");
            var msaAppId = Recording.Random.NewGuid().ToString();
            var resourceGroup = await CreateResourceGroupAsync();
            var botCollection = resourceGroup.GetBots();
            var botInput = ResourceDataHelpers.GetBotData(msaAppId);
            var botResource = (await botCollection.CreateOrUpdateAsync(WaitUntil.Completed, botName, botInput)).Value;
            var collection = botResource.GetBotChannels();
            var input = ResourceDataHelpers.GetDirectLineSpeechChannelData();
            var resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, channelName, input)).Value;
            Assert.AreEqual(channelName, resource.Data.Name);
            //2.Get
            var resource2 = (await resource.GetAsync()).Value;
            ResourceDataHelpers.AssertBotChannel(resource.Data, resource2.Data);
            //3.GetAll
            int count = 0;
            _ = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, channelName2, input)).Value;
            _ = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, channelName3, input)).Value;
            await foreach (var item in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exist
            Assert.IsTrue(await collection.ExistsAsync(channelName));
            Assert.IsFalse(await collection.ExistsAsync(channelName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resouece operation
            //1.Get
            var rResource3 = (await resource.GetAsync()).Value;
            ResourceDataHelpers.AssertBotChannel(resource.Data, rResource3.Data);
            //2.Update
            var patch = new BotChannelData(new AzureLocation("global"))
            {
                Properties = new DirectLineSpeechChannel()
                {
                    Properties = new DirectLineSpeechChannelProperties()
                    {
                        CognitiveServiceRegion = "XupdatecognitiveServiceRegionX",
                        CognitiveServiceSubscriptionKey = "XcognitiveServiceSubscriptionKeyX",
                        IsEnabled = true,
                    },
                }
            };
            var resource4 = (await rResource3.UpdateAsync(patch)).Value;
            //3. Delete
            await resource4.DeleteAsync(WaitUntil.Completed);
        }
    }
}
