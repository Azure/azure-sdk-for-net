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
    public class PublishedBlueprintTest : BlueprintManagementTestBase
    {
        public PublishedBlueprintTest(bool isAsync) :
            base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task PublicblueprintApiTest()
        {
            //prepare
            string printName = Recording.GenerateAssetName("blueprint-");
            string version = Recording.GenerateAssetName("v2");
            var resourceGroup = await CreateResourceGroupAsync();
            string resourceScope = $"/subscriptions/{resourceGroup.Data.Id.SubscriptionId}";
            ResourceIdentifier scopeId = new ResourceIdentifier(string.Format("{0}", resourceScope));
            //CreateOrUpdate
            BlueprintCollection blueprintCollection = Client.GetBlueprints(scopeId);
            var printInput = ResourceDataHelpers.GetBlueprintData();
            var blueprintResource = (await blueprintCollection.CreateOrUpdateAsync(WaitUntil.Completed, printName, printInput)).Value;
            var collection = blueprintResource.GetPublishedBlueprints();
            var input = ResourceDataHelpers.GetPublishedBlueprintData(blueprintResource.Data.Name);
            var resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, version, input)).Value;
            Assert.AreEqual(version, resource.Data.Name);
            //Get
            var resource2 = (await collection.GetAsync(version)).Value;
            ResourceDataHelpers.AssertPublishedBlueprintData(resource.Data, resource2.Data);
            //Exist
            Assert.IsTrue(await collection.ExistsAsync(version));
            Assert.IsFalse(await collection.ExistsAsync(version + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resouece operation
            //1.Get
            var resource3 = (await collection.GetAsync(version)).Value;
            ResourceDataHelpers.AssertPublishedBlueprintData(resource.Data, resource3.Data);
            //2.Update
            /*var updateData = resource.Data;
            updateData.ChangeNotes = "update";
            var resource4 = (await resource.UpdateAsync(WaitUntil.Completed, updateData)).Value;
            ResourceDataHelpers.AssertPublishedBlueprintData(updateData, resource4.Data);*/
            //3. Delete
            await resource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
