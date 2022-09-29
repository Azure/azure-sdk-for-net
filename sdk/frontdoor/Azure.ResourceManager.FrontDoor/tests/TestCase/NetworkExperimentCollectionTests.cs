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
using Microsoft.Extensions.Options;

namespace Azure.ResourceManager.FrontDoor.Tests.TestCase
{
    public class NetworkExperimentCollectionTests : FrontDoorManagementTestBase
    {
        public NetworkExperimentCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<FrontDoorNetworkExperimentProfileCollection> GetFrontDoorCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetFrontDoorNetworkExperimentProfiles();
        }

        [TestCase]
        [RecordedTest]
        [Ignore("no authorization")]
        public async Task AFDExperimentApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetFrontDoorCollectionAsync();
            var name = Recording.GenerateAssetName("TestProflie-");
            var name2 = Recording.GenerateAssetName("TestProflie-");
            var name3 = Recording.GenerateAssetName("TestProflie-");
            var input = ResourceDataHelpers.GetProfileData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            FrontDoorNetworkExperimentProfileResource proflie1 = lro.Value;
            Assert.AreEqual(name, proflie1.Data.Name);
            //2.Get
            FrontDoorNetworkExperimentProfileResource proflie2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertFrontDoorNetWorkExperiment(proflie1.Data, proflie2.Data);
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
