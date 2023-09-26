// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AgFoodPlatform.Models;
using Azure.ResourceManager.AgFoodPlatform.Tests.Helpers;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.AgFoodPlatform.Tests
{
    public class FarmBeatTests : AgFoodPlatformManagementTestBase
    {
        public FarmBeatTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        public async Task<FarmBeatCollection> GetBeatsCollection()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = resourceGroup.GetFarmBeats();
            return collection;
        }

        [TestCase]
        public async Task FarmbeatsApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetBeatsCollection();
            var name = Recording.GenerateAssetName("farmbeat");
            var name2 = Recording.GenerateAssetName("farmbeat");
            var name3 = Recording.GenerateAssetName("farmbeat");
            var input = ResourceDataHelpers.GetFarmBeatData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            FarmBeatResource farmbeat1 = lro.Value;
            Assert.AreEqual(name, farmbeat1.Data.Name);
            //2.Get
            FarmBeatResource farmbeat2 = await farmbeat1.GetAsync();
            ResourceDataHelpers.AssertFarmBeat(farmbeat1.Data, farmbeat2.Data);
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
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            FarmBeatResource farmbeat3 = await farmbeat1.GetAsync();
            ResourceDataHelpers.AssertFarmBeat(farmbeat1.Data, farmbeat3.Data);
            //6.update
            FarmBeatPatch patch = new FarmBeatPatch()
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
                Properties = new FarmBeatsUpdateProperties()
                {
                    SensorIntegration = new SensorIntegration()
                    {
                        Enabled = "True",
                    },
                },
                Tags =
                {
                    ["updatekey1"] = "updatevalue1",
                    ["updatekey2"] = "updatevalue2",
                }
            };
            var farmBeat4 = await farmbeat1.UpdateAsync(WaitUntil.Completed, patch);
            //7.Delete
            await farmbeat1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
