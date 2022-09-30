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
    public class RuleEngineResourceTests : FrontDoorManagementTestBase
    {
        public RuleEngineResourceTests(bool isAsync)
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

        private async Task<FrontDoorRulesEngineResource> CreateAccountResourceAsync(string engineName)
        {
            var resourceGroup = await GetResourceGroupAsync();
            var collection = GetFrontDoorCollectionAsync(resourceGroup);
            var groupName = resourceGroup.Data.Name;
            var frontDoorName = Recording.GenerateAssetName("testfrontdoor");
            var input = ResourceDataHelpers.GetFrontDoorData("global", frontDoorName, groupName, DefaultSubscription.Id);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, frontDoorName, input);
            var frontDoor = lro.Value;
            var endineCollection = frontDoor.GetFrontDoorRulesEngines();
            var poolInput = ResourceDataHelpers.GetRulesEngineData();
            var lroc = await endineCollection.CreateOrUpdateAsync(WaitUntil.Completed, engineName, poolInput);
            return lroc.Value;
        }

        [TestCase]
        public async Task AFDRulesEngineResourceApiTests()
        {
            //1.Get
            var engineName = Recording.GenerateAssetName("testengine");
            var engine1 = await CreateAccountResourceAsync(engineName);
            FrontDoorRulesEngineResource engine2 = await engine1.GetAsync();

            ResourceDataHelpers.AssertRuleEngine(engine1.Data, engine2.Data);
            //2.Delete
            await engine1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
