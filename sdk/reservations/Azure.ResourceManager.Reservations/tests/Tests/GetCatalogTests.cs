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
        private SubscriptionResourceGetCatalogOptions options;

        public GetCatalogTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            options = new SubscriptionResourceGetCatalogOptions();
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForVirtualMachines()
        {
            options.ReservedResourceType = "VirtualMachines";
            options.Location = "eastus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "virtualMachines", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSqlDatabases()
        {
            options.ReservedResourceType = "SqlDatabases";
            options.Location = "westus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SQLManagedInstances", "SQLDatabases", true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSuseLinux()
        {
            options.ReservedResourceType = "SuseLinux";
            options.Location = null;
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SuseLinux");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSqlDataWarehouse()
        {
            options.ReservedResourceType = "SqlDataWarehouse";
            options.Location = "eastus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SqlDataWarehouse", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForVMwareCloudSimple()
        {
            options.ReservedResourceType = "VMwareCloudSimple";
            options.Location = "eastus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "VMwareCloudSimple", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForCosmosDb()
        {
            options.ReservedResourceType = "CosmosDb";
            options.Location = null;
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "CosmosDb");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForRedHat()
        {
            options.ReservedResourceType = "RedHat";
            options.Location = null;
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "RedHat");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForRedHatOsa()
        {
            options.ReservedResourceType = "RedHatOsa";
            options.Location = null;
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "RedHatOsa");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForDatabricks()
        {
            options.ReservedResourceType = "Databricks";
            options.Location = null;
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "Databricks");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAppService()
        {
            options.ReservedResourceType = "AppService";
            options.Location = "westus2";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "AppService", null, true, "westus2", "West US 2");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForBlockBlob()
        {
            options.ReservedResourceType = "BlockBlob";
            options.Location = "westus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "BlockBlob", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForManagedDisk()
        {
            options.ReservedResourceType = "ManagedDisk";
            options.Location = "westeurope";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "ManagedDisk", null, true, "westeurope", "West Europe");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForRedisCache()
        {
            options.ReservedResourceType = "RedisCache";
            options.Location = "westus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "RedisCache", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAzureDataExplorer()
        {
            options.ReservedResourceType = "AzureDataExplorer";
            options.Location = null;
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "AzureDataExplorer");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForMySql()
        {
            options.ReservedResourceType = "MySql";
            options.Location = "eastus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "MySql", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForMariaDb()
        {
            options.ReservedResourceType = "MariaDb";
            options.Location = "eastus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "MariaDb", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForPostgreSql()
        {
            options.ReservedResourceType = "PostgreSql";
            options.Location = "eastus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "PostgreSql", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForDedicatedHost()
        {
            options.ReservedResourceType = "DedicatedHost";
            options.Location = "westeurope";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "DedicatedHost", null, true, "westeurope", "West Europe");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSapHana()
        {
            options.ReservedResourceType = "SapHana";
            options.Location = "westus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SapHana", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAVS()
        {
            options.ReservedResourceType = "AVS";
            options.Location = "eastus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "AVS", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForDataFactory()
        {
            options.ReservedResourceType = "DataFactory";
            options.Location = "eastus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "DataFactory", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForNetAppStorage()
        {
            options.ReservedResourceType = "NetAppStorage";
            options.Location = "westus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
            Assert.IsTrue(catalogResult.Count > 0);
            TestGetCatalogResponse(catalogResult, "NetAppStorage", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAzureFiles()
        {
            options.ReservedResourceType = "AzureFiles";
            options.Location = "westus";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "AzureFiles", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSqlEdge()
        {
            options.ReservedResourceType = "SqlEdge";
            options.Location = null;
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SqlEdge");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForVirtualMachineSoftware()
        {
            options.ReservedResourceType = "VirtualMachineSoftware";
            options.Location = null;
            options.PublisherId = "test_test_pmc2pc1";
            options.OfferId = "mnk_vmri_test_001";
            options.PlanId = "testplan001";
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
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
