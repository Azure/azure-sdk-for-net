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
            TestGetCatalogResponse(catalogResult, "virtualMachines", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSqlDatabases()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("SqlDatabases", "westus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SQLManagedInstances", "SQLDatabases", true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSuseLinux()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("SuseLinux");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SuseLinux");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSqlDataWarehouse()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("SqlDataWarehouse", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SqlDataWarehouse", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForVMwareCloudSimple()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("VMwareCloudSimple", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "VMwareCloudSimple", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForCosmosDb()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("CosmosDb");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "CosmosDb");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForRedHat()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("RedHat");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "RedHat");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForRedHatOsa()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("RedHatOsa");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "RedHatOsa");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForDatabricks()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("Databricks");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "Databricks");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAppService()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("AppService", "westus2");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "AppService", null, true, "westus2", "West US 2");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForBlockBlob()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("BlockBlob", "westus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "BlockBlob", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForManagedDisk()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("ManagedDisk", "westeurope");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "ManagedDisk", null, true, "westeurope", "West Europe");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForRedisCache()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("RedisCache", "westus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "RedisCache", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAzureDataExplorer()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("AzureDataExplorer");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "AzureDataExplorer");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForMySql()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("MySql", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "MySql", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForMariaDb()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("MariaDb", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "MariaDb", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForPostgreSql()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("PostgreSql", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "PostgreSql", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForDedicatedHost()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("DedicatedHost", "westeurope");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "DedicatedHost", null, true, "westeurope", "West Europe");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSapHana()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("SapHana", "westus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SapHana", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAVS()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("AVS", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "AVS", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForDataFactory()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("DataFactory", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "DataFactory", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForNetAppStorage()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("NetAppStorage", "westus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);
            TestGetCatalogResponse(catalogResult, "NetAppStorage", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAzureFiles()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("AzureFiles", "westus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "AzureFiles", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSqlEdge()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("SqlEdge");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SqlEdge");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForVirtualMachineSoftware()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync("VirtualMachineSoftware", publisherId: "test_test_pmc2pc1", offerId: "mnk_vmri_test_001", planId: "testplan001");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "VirtualMachineSoftware");
        }

        private void TestGetCatalogResponse(List<ReservationCatalog> catalogResult, string resourceTypeName, string alternateResourceTypeName = null, bool hasLocation = false, string location = null, string locationDisplayName = null)
        {
            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);

            catalogResult.ForEach(item =>
            {
                if (alternateResourceTypeName != null)
                {
                    Assert.IsTrue(item.AppliedResourceType.Equals(resourceTypeName) || item.AppliedResourceType.Equals(alternateResourceTypeName));
                }
                else
                {
                    Assert.AreEqual(resourceTypeName, item.AppliedResourceType);
                }

                if (hasLocation)
                {
                    Assert.NotNull(item.Locations);
                    Assert.IsTrue(item.Locations.Count == 1);
                    Assert.AreEqual(location, item.Locations[0].Name);
                    Assert.AreEqual(locationDisplayName, item.Locations[0].DisplayName);
                }
            });
        }
    }
}
