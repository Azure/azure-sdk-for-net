// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Blueprint;
using Azure.ResourceManager.Blueprint.Models;
using NUnit.Framework;
using Azure.ResourceManager.Blueprint.Tests.Helpers;
using System;

namespace Azure.ResourceManager.Blueprint.Tests
{
    public class BlueprintTests : BlueprintManagementTestBase
    {
        public BlueprintTests(bool isAsync) :
            base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task BlueprintTest()
        {
            //prepare
            string printName = Recording.GenerateAssetName("blueprint-");
            string printName2 = Recording.GenerateAssetName("blueprint-");
            string printName3 = Recording.GenerateAssetName("blueprint-");
            var resourceGroup = await CreateResourceGroupAsync();
            string resourceScope = $"/subscriptions/{resourceGroup.Data.Id.SubscriptionId}";
            ResourceIdentifier scopeId = new ResourceIdentifier(string.Format("{0}", resourceScope));
            //CreateOrUpdate
            BlueprintCollection collection = Client.GetBlueprints(scopeId);
            var input = ResourceDataHelpers.GetBlueprintData();
            var blueprintResource =(await collection.CreateOrUpdateAsync(WaitUntil.Completed, printName, input)).Value;
            Assert.AreEqual(printName, blueprintResource.Data.Name);
            //Get
            var resource2 =(await collection.GetAsync(printName)).Value;
            ResourceDataHelpers.AssertBlueprint(blueprintResource.Data, resource2.Data);
            //GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, printName2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, printName3, input);
            int count = 0;
            await foreach (var availabilitySet in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4.Exist
            Assert.IsTrue(await collection.ExistsAsync(printName));
            Assert.IsFalse(await collection.ExistsAsync(printName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resouece operation
            //1.Get
            var resource3 = (await collection.GetAsync(printName)).Value;
            ResourceDataHelpers.AssertBlueprint(blueprintResource.Data, resource3.Data);
            //2.Update
            var updateData = blueprintResource.Data;
            updateData.Description = "Update Descriptions";
            var resource4 = (await blueprintResource.UpdateAsync(WaitUntil.Completed, updateData)).Value;
            ResourceDataHelpers.AssertBlueprint(updateData, resource4.Data);
            //3. Delete
            await resource4.DeleteAsync(WaitUntil.Completed);
        }
    }
}
