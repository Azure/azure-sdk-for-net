// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests.TestsCase
{
    public class ActionGroupCollectionTests : MonitorTestBase
    {
        public ActionGroupCollectionTests(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<ActionGroupCollection> GetActionGroupCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetActionGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetActionGroupCollectionAsync();
            var name = Recording.GenerateAssetName("testActionGroup");
            var input = ResourceDataHelper.GetBasicActionGroupData("global");
            var lro = await container.CreateOrUpdateAsync(true, name, input);
            var actionGroup = lro.Value;
            Assert.AreEqual(name, actionGroup.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetActionGroupCollectionAsync();
            var actionGroupName = Recording.GenerateAssetName("testActionGroup-");
            var input = ResourceDataHelper.GetBasicActionGroupData("global");
            var lro = await collection.CreateOrUpdateAsync(true, actionGroupName, input);
            ActionGroup actionGroup1 = lro.Value;
            ActionGroup actionGroup2 = await collection.GetAsync(actionGroupName);
            ResourceDataHelper.AssertActionGroup(actionGroup1.Data, actionGroup2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetActionGroupCollectionAsync();
            var input = ResourceDataHelper.GetBasicActionGroupData("global");
            _ = await collection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testActionGroup-"), input);
            _ = await collection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testActionGroup-"), input);
            int count = 0;
            await foreach (var actiongroup in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
