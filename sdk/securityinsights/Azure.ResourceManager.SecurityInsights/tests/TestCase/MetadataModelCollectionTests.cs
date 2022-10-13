// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class MetadataModelCollectionTests : SecurityInsightsManagementTestBase
    {
        public MetadataModelCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }
        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }
        private MetadataModelCollection GetFrontDoorCollectionAsync(ResourceGroupResource resourceGroup)
        {
            return resourceGroup.GetMetadataModels(workspaceName);
        }

        [TestCase]
        [RecordedTest]
        public async Task MetadataApiTests()
        {
            //1.CreateorUpdate
            var resourceGroup = await GetResourceGroupAsync();
            var collection = GetFrontDoorCollectionAsync(resourceGroup);
            var groupName = resourceGroup.Data.Name;
            var name = Recording.GenerateAssetName("TestFrontDoor");
            var name2 = Recording.GenerateAssetName("TestFrontDoor");
            var name3 = Recording.GenerateAssetName("TestFrontDoor");
            var input = ResourceDataHelpers.GetMetadataModelData(groupName, DefaultSubscription.Data.Id);
            var input2 = ResourceDataHelpers.GetMetadataModelData(groupName, DefaultSubscription.Data.Id);
            var input3 = ResourceDataHelpers.GetMetadataModelData(groupName, DefaultSubscription.Data.Id);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            MetadataModelResource model1 = lro.Value;
            Assert.AreEqual(name, model1.Data.Name);
            //2.Get
            MetadataModelResource model2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertMetadataModelData(model1.Data, model2.Data);
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
