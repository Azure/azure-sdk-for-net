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
    public class FleetTierTests : DatabaseFleetManagerManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public FleetTierTests(bool isAsync)
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
            var tierName = Recording.GenerateAssetName("tier");

            FleetResource fleet = await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);

            List<FleetTierResource> tiers = await fleet.GetFleetTiers().GetAllAsync().ToEnumerableAsync();

            Assert.IsNotEmpty(tiers);
            Assert.AreEqual(1, tiers.Count);
            Assert.AreEqual(tierName, tiers[0].Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var tierName = Recording.GenerateAssetName("tier");

            await CreateFleetAsync(_resourceGroup, fleetName);
            FleetTierResource tier = await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);

            Assert.IsNotNull(tier?.Data);
            Assert.AreEqual(tierName, tier.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var tierName = Recording.GenerateAssetName("tier");

            FleetResource fleet = await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);

            Assert.IsTrue((await fleet.GetFleetTiers().ExistsAsync(tierName)).Value);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var tierName = Recording.GenerateAssetName("tier");

            FleetResource fleet = await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);

            Response<FleetTierResource> tier = await fleet.GetFleetTiers().GetAsync(tierName);

            Assert.IsNotNull(tier.Value.Data);
            Assert.AreEqual(tierName, tier.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Update()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var tierName = Recording.GenerateAssetName("tier");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);

            Response<FleetResource> fleet = await _resourceGroup.GetFleets().GetAsync(fleetName);
            Response<FleetTierResource> tier = await fleet.Value.GetFleetTiers().GetAsync(tierName);

            var maxNumOfDatabases = 10;

            ArmOperation<FleetTierResource> updatedTier = await tier.Value.UpdateAsync(WaitUntil.Completed, new FleetTierData
            {
                Properties = new FleetTierProperties
                {
                    PoolNumOfDatabasesMax = maxNumOfDatabases
                }
            });

            Assert.IsNotNull(updatedTier.Value.Data);
            Assert.AreEqual(maxNumOfDatabases, updatedTier.Value.Data.Properties.PoolNumOfDatabasesMax);
        }

        [Test]
        [RecordedTest]
        public async Task Disable()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var tierName = Recording.GenerateAssetName("tier");

            FleetResource fleet = await CreateFleetAsync(_resourceGroup, fleetName);
            FleetTierResource tier = await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);

            Assert.IsFalse(tier.Data.Properties.Disabled);

            try
            {
                await tier.DisableAsync();
            }
            catch
            { }

            tier = await fleet.GetFleetTiers().GetAsync(tierName);

            Assert.IsTrue(tier.Data.Properties.Disabled);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var tierName = Recording.GenerateAssetName("tier");

            FleetResource fleet = await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);

            List<FleetTierResource> tiers = await fleet.GetFleetTiers().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, tiers.Count);

            var activeTier = tiers[0];

            // Need to disable tier before delete.
            try
            {
                await activeTier.DisableAsync();
            }
            catch
            { }

            activeTier = await fleet.GetFleetTiers().GetAsync(tierName);
            Assert.IsTrue(activeTier.Data.Properties.Disabled);

            await activeTier.DeleteAsync(WaitUntil.Completed);

            tiers = await fleet.GetFleetTiers().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, tiers.Count);
        }
    }
}
