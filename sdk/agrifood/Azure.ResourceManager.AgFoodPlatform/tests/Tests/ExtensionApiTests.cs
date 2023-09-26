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
    public class ExtensionApiTests : AgFoodPlatformManagementTestBase
    {
        public ExtensionApiTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        public async Task<ExtensionCollection> GetExtensionCollection()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var name = Recording.GenerateAssetName("farmbeat");
            var farmBeatCollection = resourceGroup.GetFarmBeats();
            var input = ResourceDataHelpers.GetFarmBeatData(DefaultLocation);
            var lro = await farmBeatCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            FarmBeatResource farmbeat = lro.Value;
            var collection = farmbeat.GetExtensions();
            return collection;
        }

        [TestCase]
        public async Task ExtensionTests()
        {
            //1.CreateOrUpdate
            var collection = await GetExtensionCollection();
            var name = Recording.GenerateAssetName("extension");
            var name2 = Recording.GenerateAssetName("extension");
            var name3 = Recording.GenerateAssetName("extension");
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name);
            ExtensionResource extension1 = lro.Value;
            Assert.AreEqual(name, extension1.Data.Name);
            //2.Get
            ExtensionResource farmbeat2 = await extension1.GetAsync();
            Assert.AreEqual(extension1.Data, farmbeat2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3);
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
            ExtensionResource extension3 = await extension1.GetAsync();
            ResourceDataHelpers.AssertExtension(extension1.Data, extension3.Data);
            //6.update
            var farmBeat4 = await extension1.UpdateAsync();
            //7.Delete
            await extension1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
