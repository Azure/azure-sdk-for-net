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
    public class FrontDoorExperimentCollectionTests : FrontDoorManagementTestBase
    {
        public FrontDoorExperimentCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<FrontDoorExperimentCollection> GetFrontDoorRulesEngineCollectionAsync()
        {
            var collection = (await CreateResourceGroupAsync()).GetFrontDoorNetworkExperimentProfiles();
            var input = ResourceDataHelpers.GetProfileData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testprofile"), input);
            var frontDoor = lro.Value;
            return frontDoor.GetFrontDoorExperiments();
        }

        [TestCase]
        [RecordedTest]
        [Ignore("no authorization")]
        public async Task AFDExperimentApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetFrontDoorRulesEngineCollectionAsync();
            var name = Recording.GenerateAssetName("TestExperiment-");
            var name2 = Recording.GenerateAssetName("TestExperiment-");
            var name3 = Recording.GenerateAssetName("TestExperiment-");
            var input = ResourceDataHelpers.GetFrontDoorExperimentData("global");
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            FrontDoorExperimentResource experiment1 = lro.Value;
            Assert.AreEqual(name, experiment1.Data.Name);
            //2.Get
            FrontDoorExperimentResource experiment2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertFrontDoorExperiment(experiment1.Data, experiment2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
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
