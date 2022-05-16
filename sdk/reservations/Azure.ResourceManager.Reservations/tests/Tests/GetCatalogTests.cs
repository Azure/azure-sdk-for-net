// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Reservations.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Reservations.Tests
{
    public class GetCatalogTests : ReservationsManagementClientBase
    {
        public GetCatalogTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForVirtualMachines()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("VirtualMachines", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("virtualMachines", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("eastus", item.Locations[0].Name);
                Assert.AreEqual("East US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSqlDatabases()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("SqlDatabases", "westus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.IsTrue(item.ReservedResourceType.Equals("SQLManagedInstances") || item.ReservedResourceType.Equals("SQLDatabases"));
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("westus", item.Locations[0].Name);
                Assert.AreEqual("West US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSuseLinux()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("SuseLinux");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("SuseLinux", item.ReservedResourceType);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSqlDataWarehouse()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("SqlDataWarehouse", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("SqlDataWarehouse", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("eastus", item.Locations[0].Name);
                Assert.AreEqual("East US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForVMwareCloudSimple()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("VMwareCloudSimple", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("VMwareCloudSimple", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("eastus", item.Locations[0].Name);
                Assert.AreEqual("East US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForCosmosDb()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("CosmosDb");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("CosmosDb", item.ReservedResourceType);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForRedHat()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("RedHat");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("RedHat", item.ReservedResourceType);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForRedHatOsa()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("RedHatOsa");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("RedHatOsa", item.ReservedResourceType);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForDatabricks()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("Databricks");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("Databricks", item.ReservedResourceType);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAppService()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("AppService", "westus2");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("AppService", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("westus2", item.Locations[0].Name);
                Assert.AreEqual("West US 2", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForBlockBlob()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("BlockBlob", "westus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("BlockBlob", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("westus", item.Locations[0].Name);
                Assert.AreEqual("West US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForManagedDisk()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("ManagedDisk", "westeurope");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("ManagedDisk", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("westeurope", item.Locations[0].Name);
                Assert.AreEqual("West Europe", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForRedisCache()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("RedisCache", "westus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("RedisCache", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("westus", item.Locations[0].Name);
                Assert.AreEqual("West US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAzureDataExplorer()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("AzureDataExplorer");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("AzureDataExplorer", item.ReservedResourceType);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForMySql()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("MySql", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("MySql", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("eastus", item.Locations[0].Name);
                Assert.AreEqual("East US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForMariaDb()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("MariaDb", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("MariaDb", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("eastus", item.Locations[0].Name);
                Assert.AreEqual("East US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForPostgreSql()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("PostgreSql", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("PostgreSql", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("eastus", item.Locations[0].Name);
                Assert.AreEqual("East US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForDedicatedHost()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("DedicatedHost", "westeurope");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("DedicatedHost", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("westeurope", item.Locations[0].Name);
                Assert.AreEqual("West Europe", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSapHana()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("SapHana", "westus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("SapHana", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("westus", item.Locations[0].Name);
                Assert.AreEqual("West US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAVS()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("AVS", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("AVS", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("eastus", item.Locations[0].Name);
                Assert.AreEqual("East US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForDataFactory()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("DataFactory", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("DataFactory", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("eastus", item.Locations[0].Name);
                Assert.AreEqual("East US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForNetAppStorage()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("NetAppStorage", "westus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("NetAppStorage", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("westus", item.Locations[0].Name);
                Assert.AreEqual("West US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAzureFiles()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("AzureFiles", "westus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("AzureFiles", item.ReservedResourceType);
                Assert.NotNull(item.Locations);
                Assert.IsTrue(item.Locations.Count == 1);
                Assert.AreEqual("westus", item.Locations[0].Name);
                Assert.AreEqual("West US", item.Locations[0].DisplayName);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSqlEdge()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("SqlEdge");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("SqlEdge", item.ReservedResourceType);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForVirtualMachineSoftware()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("VirtualMachineSoftware", publisherId: "test_test_pmc2pc1", offerId: "mnk_vmri_test_001", planId: "testplan001");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                Assert.AreEqual("VirtualMachineSoftware", item.ReservedResourceType);
            });
        }
    }
}
