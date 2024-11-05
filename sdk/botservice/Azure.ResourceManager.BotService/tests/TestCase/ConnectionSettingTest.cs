// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.BotService.Models;
using Azure.ResourceManager.BotService.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.BotService.Tests
{
    public class ConnectionSettingTest : BotServiceManagementTestBase
    {
        public ConnectionSettingTest(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            //1.Create
            var botName = Recording.GenerateAssetName("testbotService");
            var settingName = Recording.GenerateAssetName("testsetting");
            var msaAppId = Recording.Random.NewGuid().ToString();
            var resourceGroup = await CreateResourceGroupAsync();
            var botCollection = resourceGroup.GetBots();
            var botInput = ResourceDataHelpers.GetBotData(msaAppId);
            var botResource = (await botCollection.CreateOrUpdateAsync(WaitUntil.Completed, botName, botInput)).Value;
            var collection = botResource.GetBotConnectionSettings();
            var providers = await DefaultSubscription.GetBotConnectionServiceProvidersAsync().ToEnumerableAsync();
            var providerId = providers.ElementAt(1).Properties.Id;
            var clientId = Recording.Random.NewGuid().ToString();
            string clientSecret = Recording.Random.NewGuid().ToString();
            var input = ResourceDataHelpers.GetBotConnectionSettingData(clientId, clientSecret, providerId);
            var resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, settingName, input)).Value;
            Assert.AreEqual(botName + "/" + settingName, resource.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("There is a bug in the Get method")]
        public async Task GetTest()
        {
            //1.Create
            var botName = Recording.GenerateAssetName("testbotService");
            var settingName = Recording.GenerateAssetName("testsetting");
            var msaAppId = Recording.Random.NewGuid().ToString();
            var resourceGroup = await CreateResourceGroupAsync();
            var botCollection = resourceGroup.GetBots();
            var botInput = ResourceDataHelpers.GetBotData(msaAppId);
            var botResource = (await botCollection.CreateOrUpdateAsync(WaitUntil.Completed, botName, botInput)).Value;
            var collection = botResource.GetBotConnectionSettings();
            var providers = await DefaultSubscription.GetBotConnectionServiceProvidersAsync().ToEnumerableAsync();
            var providerId = providers.ElementAt(1).Properties.Id;
            var clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            string clientSecret;
            if (Mode == RecordedTestMode.Playback)
            {
                clientSecret = "ABCD~1234~1234567~ABCDEFGHIJKLMNOPQRST";
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
                }
            }
            var input = ResourceDataHelpers.GetBotConnectionSettingData(clientId, clientSecret, providerId);
            var resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, settingName, input)).Value;
            //2.Get
            var resource2 = (await resource.GetAsync()).Value;
            ResourceDataHelpers.AssertBotConnectionSettingData(resource.Data, resource2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListTest()
        {
            //Create
            var botName = Recording.GenerateAssetName("testbotService");
            var settingName = Recording.GenerateAssetName("testsetting");
            var settingName2 = Recording.GenerateAssetName("testsetting");
            var settingName3 = Recording.GenerateAssetName("testsetting");
            var msaAppId = Recording.Random.NewGuid().ToString();
            var resourceGroup = await CreateResourceGroupAsync();
            var botCollection = resourceGroup.GetBots();
            var botInput = ResourceDataHelpers.GetBotData(msaAppId);
            var botResource = (await botCollection.CreateOrUpdateAsync(WaitUntil.Completed, botName, botInput)).Value;
            var collection = botResource.GetBotConnectionSettings();
            var providers = await DefaultSubscription.GetBotConnectionServiceProvidersAsync().ToEnumerableAsync();
            var providerId = providers.ElementAt(1).Properties.Id;
            var clientId = Recording.Random.NewGuid().ToString();
            string clientSecret = Recording.Random.NewGuid().ToString();
            var input = ResourceDataHelpers.GetBotConnectionSettingData(clientId, clientSecret, providerId);
            var resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, settingName, input)).Value;
            //3.GetAll
            int count = 0;
            _ = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, settingName2, input)).Value;
            _ = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, settingName3, input)).Value;
            await foreach (var item in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exist
            Assert.IsTrue(await collection.ExistsAsync(settingName));
            Assert.IsFalse(await collection.ExistsAsync(settingName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resouece operation
            //1.Get
            var rResource3 = (await resource.GetAsync()).Value;
            ResourceDataHelpers.AssertBotConnectionSettingData(resource.Data, rResource3.Data);
            //2.Update
            var patch = new BotConnectionSettingData(new AzureLocation("global"))
            {
                Properties = new BotConnectionSettingProperties()
                {
                    Parameters =
                    {
                        new BotConnectionSettingParameter()
                        {
                        Key = "Updatekey1",
                        Value = "Updatevalue1",
                        },
                        new BotConnectionSettingParameter()
                        {
                        Key = "Updatekey2",
                        Value = "Updatevalue2",
                        }
                    }
                },
                ETag = new ETag("etag1")
            };
            var resource4 = (await rResource3.UpdateAsync(patch)).Value;
            //3. Delete
            await resource4.DeleteAsync(WaitUntil.Completed);
        }
    }
}
