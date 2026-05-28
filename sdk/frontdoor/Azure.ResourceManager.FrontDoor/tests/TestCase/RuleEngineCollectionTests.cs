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
    public class RuleEngineCollectionTests : FrontDoorManagementTestBase
    {
        public RuleEngineCollectionTests(bool isAsync)
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

        private async Task<FrontDoorRulesEngineCollection> GetFrontDoorRulesEngineCollectionAsync()
        {
            var resourceGroup = await GetResourceGroupAsync();
            var collection = GetFrontDoorCollectionAsync(resourceGroup);
            var groupName = resourceGroup.Data.Name;
            var frontdoorName = Recording.GenerateAssetName("testfrontdoor");
            var input = ResourceDataHelpers.GetFrontDoorData("global", frontdoorName, groupName, DefaultSubscription.Data.Id);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, frontdoorName, input);
            var frontDoor = lro.Value;
            return frontDoor.GetFrontDoorRulesEngines();
        }

        [TestCase]
        [RecordedTest]
        public async Task AFDRulesEngineApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetFrontDoorRulesEngineCollectionAsync();
            var name = Recording.GenerateAssetName("TestRulesEngine-");
            var name2 = Recording.GenerateAssetName("TestRulesEngine-");
            var name3 = Recording.GenerateAssetName("TestRulesEngine-");
            var input = ResourceDataHelpers.GetRulesEngineData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            FrontDoorRulesEngineResource rules1 = lro.Value;
            Assert.AreEqual(name, rules1.Data.Name);
            //2.Get
            FrontDoorRulesEngineResource rules2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertRuleEngine(rules1.Data, rules2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var rules in collection.GetAllAsync())
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
