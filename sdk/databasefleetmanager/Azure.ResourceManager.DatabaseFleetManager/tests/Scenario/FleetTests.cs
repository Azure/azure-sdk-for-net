// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DatabaseFleetManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DatabaseFleetManager.Tests.Scenario
{
    public class FleetTests : DatabaseFleetManagerManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public FleetTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroupName = Recording.GenerateAssetName("sdk-test-rg");
            _resourceGroup = await CreateResourceGroup(DefaultSubscription, resourceGroupName, DefaultLocation);
        }

        [TearDown]
        public async Task TearDown()
        {
            List<FleetResource> fleets = await _resourceGroup.GetFleets().GetAllAsync().ToEnumerableAsync();
            foreach (FleetResource fleet in fleets)
            {
                await fleet.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            var fleetName = Recording.GenerateAssetName("fleet");

            await CreateFleetAsync(_resourceGroup, fleetName);

            List<FleetResource> fleets = await _resourceGroup.GetFleets().GetAllAsync().ToEnumerableAsync();

            Assert.IsNotEmpty(fleets);
            Assert.AreEqual(1, fleets.Count);
            Assert.AreEqual(fleetName, fleets[0].Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var fleetName = Recording.GenerateAssetName("fleet");

            FleetResource createdFleet = await CreateFleetAsync(_resourceGroup, fleetName);

            Assert.IsNotNull(createdFleet?.Data);
            Assert.AreEqual(fleetName, createdFleet.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            var fleetName = Recording.GenerateAssetName("fleet");

            await CreateFleetAsync(_resourceGroup, fleetName);

            Assert.IsTrue((await _resourceGroup.GetFleets().ExistsAsync(fleetName)).Value);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            var fleetName = Recording.GenerateAssetName("fleet");

            await CreateFleetAsync(_resourceGroup, fleetName);

            Response<FleetResource> fleet = await _resourceGroup.GetFleets().GetAsync(fleetName);

            Assert.IsNotNull(fleet.Value.Data);
            Assert.AreEqual(fleetName, fleet.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Update()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var tagName = Recording.GenerateAssetName("fleet-tag-");
            var tagValue = Recording.GenerateAssetName("fleet-tag-value-");

            await CreateFleetAsync(_resourceGroup, fleetName);

            Response<FleetResource> fleet = await _resourceGroup.GetFleets().GetAsync(fleetName);

            var patchData = new FleetPatch
            {
                Properties = new FleetProperties()
            };
            patchData.Tags.Add(tagName, tagValue);

            ArmOperation<FleetResource> updatedFleet = await fleet.Value.UpdateAsync(WaitUntil.Completed, patchData);

            Assert.IsNotNull(updatedFleet.Value.Data);
            Assert.IsTrue(updatedFleet.Value.Data.Tags.ContainsKey(tagName));
            Assert.AreEqual(tagValue, updatedFleet.Value.Data.Tags[tagName]);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            var fleetName = Recording.GenerateAssetName("fleet");

            await CreateFleetAsync(_resourceGroup, fleetName);

            List<FleetResource> fleets = await _resourceGroup.GetFleets().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, fleets.Count);

            await fleets[0].DeleteAsync(WaitUntil.Completed);

            fleets = await _resourceGroup.GetFleets().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, fleets.Count);
        }
    }
}
