// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AgFoodPlatform.Models;
using Azure.ResourceManager.AgFoodPlatform.Tests.Helpers;
using Azure.ResourceManager.Models;
using NUnit.Framework;
namespace Azure.ResourceManager.AgFoodPlatform.Tests
{
    public class PrivateEndPointCollectionTests : AgFoodPlatformManagementTestBase
    {
        public PrivateEndPointCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        public async Task<AgFoodPlatformPrivateEndpointConnectionCollection> GetBeatCollection()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var name = Recording.GenerateAssetName("farmbeat");
            var farmBeatCollection = resourceGroup.GetFarmBeats();
            var input = ResourceDataHelpers.GetFarmBeatData(DefaultLocation);
            var lro = await farmBeatCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            FarmBeatResource farmbeat = lro.Value;
            var collection = farmbeat.GetAgFoodPlatformPrivateEndpointConnections();
            return collection;
        }

        [TestCase]
        public async Task AgFoodPlatformPrivateEndpointConnectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetBeatCollection();
            var name = Recording.GenerateAssetName("point");
            var name2 = Recording.GenerateAssetName("point");
            var name3 = Recording.GenerateAssetName("point");
            var input = ResourceDataHelpers.GetPrivateEndpointConnectionData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            AgFoodPlatformPrivateEndpointConnectionResource point1 = lro.Value;
            Assert.AreEqual(name, point1.Data.Name);
            //2.Get
            AgFoodPlatformPrivateEndpointConnectionResource point2 = await point1.GetAsync();
            ResourceDataHelpers.AssertPrivateEndpointConnection(point1.Data, point2.Data);
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
            AgFoodPlatformPrivateEndpointConnectionResource point3 = await point1.GetAsync();
            ResourceDataHelpers.AssertPrivateEndpointConnection(point1.Data, point3.Data);
            //6.update
            AgFoodPlatformPrivateEndpointConnectionData patch = new AgFoodPlatformPrivateEndpointConnectionData()
            {
                ConnectionState = new AgFoodPlatformPrivateLinkServiceConnectionState()
                {
                    //Status = AgFoodPlatformPrivateEndpointServiceConnectionStatus.Approved,
                    Description = "Approved by updatejohndoe@contoso.com",
                },
            };
            var farmBeat4 = await point1.UpdateAsync(WaitUntil.Completed, patch);
            //7.Delete
            await point1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
