// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DatabaseFleetManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DatabaseFleetManager.Tests.Scenario
{
    public class FleetspaceTests : DatabaseFleetManagerManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public FleetspaceTests(bool isAsync)
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
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");

            FleetResource fleet = await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);

            List<FleetspaceResource> fleetspaces = await fleet.GetFleetspaces().GetAllAsync().ToEnumerableAsync();

            Assert.IsNotEmpty(fleetspaces);
            Assert.AreEqual(1, fleetspaces.Count);
            Assert.AreEqual(fleetspaceName, fleetspaces[0].Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");

            await CreateFleetAsync(_resourceGroup, fleetName);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);

            Assert.IsNotNull(fleetspace?.Data);
            Assert.AreEqual(fleetspaceName, fleetspace.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");

            FleetResource fleet = await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);

            Assert.IsTrue((await fleet.GetFleetspaces().ExistsAsync(fleetspaceName)).Value);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");

            FleetResource fleet = await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);

            Response<FleetspaceResource> fleetspace = await fleet.GetFleetspaces().GetAsync(fleetspaceName);

            Assert.IsNotNull(fleetspace.Value.Data);
            Assert.AreEqual(fleetspaceName, fleetspace.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Update()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);

            Response<FleetResource> fleet = await _resourceGroup.GetFleets().GetAsync(fleetName);
            Response<FleetspaceResource> fleetspace = await fleet.Value.GetFleetspaces().GetAsync(fleetspaceName);

            var capacityMax = 2;

            ArmOperation<FleetspaceResource> updatedFleetspace = await fleetspace.Value.UpdateAsync(WaitUntil.Completed, new FleetspaceData
            {
                Properties = new FleetspaceProperties
                {
                    CapacityMax = capacityMax
                }
            });

            Assert.IsNotNull(updatedFleetspace.Value.Data);
            Assert.AreEqual(capacityMax, updatedFleetspace.Value.Data.Properties.CapacityMax);
        }

        [Test]
        [RecordedTest]
        public async Task Unregister()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var tierName = Recording.GenerateAssetName("tier");
            var databaseName = Recording.GenerateAssetName("db");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            FleetDatabaseResource database = await CreateDatabaseAsync(_resourceGroup, fleetName, fleetspaceName, databaseName, tierName, DefaultDatabaseProperties);

            List<FleetDatabaseResource> databases = await fleetspace.GetFleetDatabases().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(databases);
            Assert.AreEqual(1, databases.Count);

            await fleetspace.UnregisterAsync(WaitUntil.Completed);

            databases = await fleetspace.GetFleetDatabases().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(databases);
        }

        [Test]
        [RecordedTest]
        public async Task Register()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var fleetspace2Name = Recording.GenerateAssetName("fleetspace");
            var tierName = Recording.GenerateAssetName("tier");
            var databaseName = Recording.GenerateAssetName("db");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);

            //
            // Unregister fleetspace.
            //

            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            FleetDatabaseResource database = await CreateDatabaseAsync(_resourceGroup, fleetName, fleetspaceName, databaseName, tierName, DefaultDatabaseProperties);
            var segments = database.Data.Properties.OriginalDatabaseId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            List<FleetDatabaseResource> databases = await fleetspace.GetFleetDatabases().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(databases);
            Assert.AreEqual(1, databases.Count);

            await fleetspace.UnregisterAsync(WaitUntil.Completed);

            databases = await fleetspace.GetFleetDatabases().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(databases);

            //
            // Re-register unregistered server.
            //

            // Create a new fleetspace.
            fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspace2Name, DefaultFleetspaceProperties);

            // Parse unregistered database connection string to extract subscription, resource group and server name.
            var subscription = segments[1];
            var resourceGroup = segments[3];
            var serverName = segments[7];

            await fleetspace.RegisterServerAsync(WaitUntil.Completed, new RegisterServerProperties
            {
                TierName = tierName,
                SourceSubscriptionId = subscription,
                SourceResourceGroupName = resourceGroup,
                SourceServerName = serverName,
            });

            databases = await fleetspace.GetFleetDatabases().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(databases);
            Assert.AreEqual(1, databases.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");

            FleetResource fleet = await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);

            List<FleetspaceResource> fleetspaces = await fleet.GetFleetspaces().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, fleetspaces.Count);

            await fleetspaces[0].DeleteAsync(WaitUntil.Completed);

            fleetspaces = await fleet.GetFleetspaces().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, fleetspaces.Count);
        }
    }
}
