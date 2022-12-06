// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class ActionGroupOperationTests : MonitorTestBase
    {
        public ActionGroupOperationTests(bool isAsync)
            : base(isAsync)
        {
        }

        private async Task<ActionGroupResource> CreateActionGroupAsync(string actionGroupName)
        {
            var collection = (await CreateResourceGroupAsync()).GetActionGroups();
            var input = ResourceDataHelper.GetBasicActionGroupData("Global");
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, actionGroupName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var actionGroupName = Recording.GenerateAssetName("testActionGroup-");
            var actionGroup = await CreateActionGroupAsync(actionGroupName);
            await actionGroup.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var actionGroupName = Recording.GenerateAssetName("testActionGroup-");
            var actionGroup = await CreateActionGroupAsync(actionGroupName);
            ActionGroupResource actionGroup2 = await actionGroup.GetAsync();

            ResourceDataHelper.AssertActionGroup(actionGroup.Data, actionGroup2.Data);
        }
    }
}
