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
using System.Threading;

namespace Azure.ResourceManager.Blueprint.Tests
{
    public class AssignmentTest : BlueprintManagementTestBase
    {
        public AssignmentTest(bool isAsync) :
            base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task AssignmentApiTest()
        {
            //prepare
            string printName = Recording.GenerateAssetName("blueprint-");
            string version = Recording.GenerateAssetName("v");
            string assignmentName = Recording.GenerateAssetName("assignment-");
            string assignmrntName2 = Recording.GenerateAssetName("assignment-");
            string assignmentName3 = Recording.GenerateAssetName("assignment-");
            var resourceGroup = await CreateResourceGroupAsync();
            string resourceScope = $"/subscriptions/{resourceGroup.Data.Id.SubscriptionId}";
            ResourceIdentifier scopeId = new ResourceIdentifier(string.Format("{0}", resourceScope));
            //CreateOrUpdate
            BlueprintCollection blueprintCollection = Client.GetBlueprints(scopeId);
            var printInput = ResourceDataHelpers.GetBlueprintData();
            var blueprintResource = (await blueprintCollection.CreateOrUpdateAsync(WaitUntil.Completed, printName, printInput)).Value;
            var publishedCollection = blueprintResource.GetPublishedBlueprints();
            var publishedInput = ResourceDataHelpers.GetPublishedBlueprintData(blueprintResource.Data.Name);
            var publishedResource = (await publishedCollection.CreateOrUpdateAsync(WaitUntil.Completed, version, publishedInput)).Value;
            AssignmentCollection collection = Client.GetAssignments(scopeId);
            var input = ResourceDataHelpers.GetAssignmentData(blueprintResource.Id);
            var resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, assignmentName, input)).Value;
            Assert.AreEqual(assignmentName, resource.Data.Name);
            //Get
            var resource2 = (await collection.GetAsync(assignmentName)).Value;
            ResourceDataHelpers.AssertAssignmentData(resource.Data, resource2.Data);
            //GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, assignmrntName2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, assignmentName3, input);
            int count = 0;
            await foreach (var assignment in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4.Exist
            Assert.IsTrue(await collection.ExistsAsync(assignmentName));
            Assert.IsFalse(await collection.ExistsAsync(assignmentName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resouece operation
            //.Get
            var resource3 = (await collection.GetAsync(assignmentName)).Value;
            ResourceDataHelpers.AssertAssignmentData(resource.Data, resource3.Data);
        }
    }
}
