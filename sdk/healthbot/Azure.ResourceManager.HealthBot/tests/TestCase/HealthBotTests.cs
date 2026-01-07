// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HealthBot.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HealthBot.Tests.TestCase
{
    public class HealthBotTests : HealthBotManagementTestBase
    {
        public HealthBotTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public async Task<HealthBotCollection> GetHealthBotCollection()
        {
            var group = await CreateResourceGroupAsync();
            var collection = group.GetHealthBots();
            return collection;
        }

        public HealthBotData GetHealthBotData()
        {
            var data = new HealthBotData(DefaultLocation, new HealthBotSku(HealthBotSkuName.F0));
            return data;
        }
        public static void AssertData(HealthBotData data1, HealthBotData data2)
        {
            Assert.That(data2.Name, Is.EqualTo(data1.Name));
            Assert.That(data2.Id, Is.EqualTo(data1.Id));
            Assert.That(data2.Location, Is.EqualTo(data1.Location));
        }

        [RecordedTest]
        [Ignore("HealthBot subscription limit")]
        public async Task HealthBotApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetHealthBotCollection();
            var name = Recording.GenerateAssetName("healthbot-");
            var name2 = Recording.GenerateAssetName("healthbot-");
            var name3 = Recording.GenerateAssetName("healthbot-");
            var input = GetHealthBotData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            HealthBotResource healthBot1 = lro.Value;
            Assert.That(healthBot1.Data.Name, Is.EqualTo(name));
            //2.Get
            HealthBotResource HealthBot2 = await collection.GetAsync(name);
            AssertData(healthBot1.Data, HealthBot2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //.ListBotsBySubscription
            await foreach (var num in DefaultSubscription.GetHealthBotsAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 6);
            //4Exists
            Assert.That((bool)await collection.ExistsAsync(name), Is.True);
            Assert.That((bool)await collection.ExistsAsync(name + "1"), Is.False);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            HealthBotResource healthBot3 = await healthBot1.GetAsync();

            AssertData(healthBot1.Data, healthBot3.Data);
            //6.Update
            HealthBotResource healthBot5 = Client.GetHealthBotResource(new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/deleteme0713/providers/Microsoft.HealthBot/healthBots/bottest"));
            HealthBotPatch patch = new HealthBotPatch()
            {
                Tags =
                {
                    { "updateKey", "updateValue" }
                },
                //Sku = new HealthBotSku(HealthBotSkuName.S1)
            };
            HealthBotResource result = await healthBot5.UpdateAsync(patch);
            //7.Delete
            await healthBot1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
