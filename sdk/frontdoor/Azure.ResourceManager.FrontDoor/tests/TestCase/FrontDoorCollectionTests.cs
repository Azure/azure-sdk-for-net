// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.FrontDoor.Models;
using Azure.ResourceManager.FrontDoor.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.FrontDoor.Tests.TestCase
{
    public class FrontDoorCollectionTests : FrontDoorManagementTestBase
    {
        public FrontDoorCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }
            private FrontDoorCollection GetFrontDoorCollectionAsync(ResourceGroupResource resourceGroup)
        {
            return resourceGroup.GetFrontDoors();
        }

        [TestCase]
        [RecordedTest]
        public async Task FrontDoorApiTests()
        {
            //1.CreateorUpdate
            var resourceGroup = await GetResourceGroupAsync();
            var collection = GetFrontDoorCollectionAsync(resourceGroup);
            var groupName = resourceGroup.Data.Name;
            var name = Recording.GenerateAssetName("TestFrontDoor");
            var name2 = Recording.GenerateAssetName("TestFrontDoor");
            var name3 = Recording.GenerateAssetName("TestFrontDoor");
            var input = ResourceDataHelpers.GetFrontDoorData("global", name, groupName, DefaultSubscription.Data.Id);
            var input2 = ResourceDataHelpers.GetFrontDoorData("global", name2, groupName, DefaultSubscription.Data.Id);
            var input3 = ResourceDataHelpers.GetFrontDoorData("global", name3, groupName, DefaultSubscription.Data.Id);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            FrontDoorResource door1 = lro.Value;
            Assert.AreEqual(name, door1.Data.Name);
            //2.Get
            FrontDoorResource door2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertFrontDoor(door1.Data, door2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input2);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input3);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
