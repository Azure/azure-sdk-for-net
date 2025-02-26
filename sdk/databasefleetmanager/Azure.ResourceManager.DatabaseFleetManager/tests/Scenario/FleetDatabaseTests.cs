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
    public class FleetDatabaseTests : DatabaseFleetManagerManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public FleetDatabaseTests(bool isAsync)
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
            var tierName = Recording.GenerateAssetName("tier");
            var databaseName = Recording.GenerateAssetName("db");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            await CreateDatabaseAsync(_resourceGroup, fleetName, fleetspaceName, databaseName, tierName, DefaultDatabaseProperties);

            List<FleetDatabaseResource> databases = await fleetspace.GetFleetDatabases().GetAllAsync().ToEnumerableAsync();

            Assert.IsNotEmpty(databases);
            Assert.AreEqual(1, databases.Count);
            Assert.AreEqual(databaseName, databases[0].Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var tierName = Recording.GenerateAssetName("tier");
            var databaseName = Recording.GenerateAssetName("db");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);
            await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            FleetDatabaseResource database = await CreateDatabaseAsync(_resourceGroup, fleetName, fleetspaceName, databaseName, tierName, DefaultDatabaseProperties);

            Assert.IsNotNull(database?.Data);
            Assert.AreEqual(databaseName, database.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var tierName = Recording.GenerateAssetName("tier");
            var databaseName = Recording.GenerateAssetName("db");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            await CreateDatabaseAsync(_resourceGroup, fleetName, fleetspaceName, databaseName, tierName, DefaultDatabaseProperties);

            Assert.IsTrue((await fleetspace.GetFleetDatabases().ExistsAsync(databaseName)).Value);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var tierName = Recording.GenerateAssetName("tier");
            var databaseName = Recording.GenerateAssetName("db");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            await CreateDatabaseAsync(_resourceGroup, fleetName, fleetspaceName, databaseName, tierName, DefaultDatabaseProperties);

            Response<FleetDatabaseResource> database = await fleetspace.GetFleetDatabases().GetAsync(databaseName);

            Assert.IsNotNull(database.Value.Data);
            Assert.AreEqual(databaseName, database.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Rename()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var tierName = Recording.GenerateAssetName("tier");
            var databaseName = Recording.GenerateAssetName("db");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            FleetDatabaseResource database = await CreateDatabaseAsync(_resourceGroup, fleetName, fleetspaceName, databaseName, tierName, DefaultDatabaseProperties);

            Assert.AreEqual(databaseName, database.Data.Name);

            var newDatabaseName = Recording.GenerateAssetName("db");

            await database.RenameAsync(WaitUntil.Completed, new DatabaseRenameProperties
            {
                NewName = newDatabaseName
            });

            database = await fleetspace.GetFleetDatabases().GetAsync(newDatabaseName);

            Assert.AreEqual(newDatabaseName, database.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task ChangeTier()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var tierName1 = Recording.GenerateAssetName("tier");
            var tierName2 = Recording.GenerateAssetName("tier");
            var databaseName = Recording.GenerateAssetName("db");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName1, DefaultPooledTierProperties);
            await CreateTierAsync(_resourceGroup, fleetName, tierName2, DefaultPooledTierProperties);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            FleetDatabaseResource database = await CreateDatabaseAsync(_resourceGroup, fleetName, fleetspaceName, databaseName, tierName1, DefaultDatabaseProperties);

            Assert.AreEqual(tierName1, database.Data.Properties.TierName);

            await database.ChangeTierAsync(WaitUntil.Completed, new DatabaseChangeTierProperties
            {
                TargetTierName = tierName2
            });

            database = await fleetspace.GetFleetDatabases().GetAsync(databaseName);

            Assert.AreEqual(tierName2, database.Data.Properties.TierName);
        }

        [Test]
        [RecordedTest]
        public async Task RevertTde()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var tierName1 = Recording.GenerateAssetName("tier");
            var tierName2 = Recording.GenerateAssetName("tier");
            var databaseName = Recording.GenerateAssetName("db");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName1, DefaultPooledTierProperties);
            await CreateTierAsync(_resourceGroup, fleetName, tierName2, DefaultPooledTierProperties);
            await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            FleetDatabaseResource database = await CreateDatabaseAsync(_resourceGroup, fleetName, fleetspaceName, databaseName, tierName1, DefaultDatabaseProperties);

            await database.RevertAsync(WaitUntil.Completed);

            Assert.IsNull(database.Data.Properties.TransparentDataEncryption);
        }

        [Test]
        [RecordedTest]
        public async Task Update()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var tierName = Recording.GenerateAssetName("tier");
            var databaseName = Recording.GenerateAssetName("db");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            FleetDatabaseResource database = await CreateDatabaseAsync(_resourceGroup, fleetName, fleetspaceName, databaseName, tierName, DefaultDatabaseProperties);

            var tagName = "testTag";
            var tagValue = "testing";

            database.Data.Properties.ResourceTags.Add(tagName, tagValue);
            await database.UpdateAsync(WaitUntil.Completed, database.Data);

            database = await fleetspace.GetFleetDatabases().GetAsync(databaseName);

            Assert.AreEqual(tagValue, database.Data.Properties.ResourceTags[tagName]);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            var fleetName = Recording.GenerateAssetName("fleet");
            var fleetspaceName = Recording.GenerateAssetName("fleetspace");
            var tierName = Recording.GenerateAssetName("tier");
            var databaseName = Recording.GenerateAssetName("db");

            await CreateFleetAsync(_resourceGroup, fleetName);
            await CreateTierAsync(_resourceGroup, fleetName, tierName, DefaultPooledTierProperties);
            FleetspaceResource fleetspace = await CreateFleetspaceAsync(_resourceGroup, fleetName, fleetspaceName, DefaultFleetspaceProperties);
            await CreateDatabaseAsync(_resourceGroup, fleetName, fleetspaceName, databaseName, tierName, DefaultDatabaseProperties);

            List<FleetDatabaseResource> databases = await fleetspace.GetFleetDatabases().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, databases.Count);

            await databases[0].DeleteAsync(WaitUntil.Completed);

            databases = await fleetspace.GetFleetDatabases().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, databases.Count);
        }
    }
}
