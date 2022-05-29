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
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "VirtualMachines",
                Location = "eastus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "virtualMachines", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSqlDatabases()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "SqlDatabases",
                Location = "westus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SQLManagedInstances", "SQLDatabases", true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSuseLinux()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "SuseLinux"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SuseLinux");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSqlDataWarehouse()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "SqlDataWarehouse",
                Location = "eastus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SqlDataWarehouse", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForVMwareCloudSimple()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "VMwareCloudSimple",
                Location = "eastus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "VMwareCloudSimple", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForCosmosDb()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "CosmosDb"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "CosmosDb");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForRedHat()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "RedHat"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "RedHat");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForRedHatOsa()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "RedHatOsa"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "RedHatOsa");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForDatabricks()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "Databricks"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "Databricks");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAppService()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "AppService",
                Location = "westus2"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "AppService", null, true, "westus2", "West US 2");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForBlockBlob()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "BlockBlob",
                Location = "westus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "BlockBlob", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForManagedDisk()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "ManagedDisk",
                Location = "westeurope"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "ManagedDisk", null, true, "westeurope", "West Europe");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForRedisCache()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "RedisCache",
                Location = "westus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "RedisCache", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAzureDataExplorer()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "AzureDataExplorer"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "AzureDataExplorer");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForMySql()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "MySql",
                Location = "eastus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "MySql", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForMariaDb()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "MariaDb",
                Location = "eastus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "MariaDb", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForPostgreSql()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "PostgreSql",
                Location = "eastus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "PostgreSql", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForDedicatedHost()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "DedicatedHost",
                Location = "westeurope"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "DedicatedHost", null, true, "westeurope", "West Europe");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSapHana()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "SapHana",
                Location = "westus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SapHana", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForAVS()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "AVS",
                Location = "eastus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "AVS", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForDataFactory()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "DataFactory",
                Location = "eastus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "DataFactory", null, true, "eastus", "East US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForNetAppStorage()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "NetAppStorage",
                Location = "westus"
            };
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
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "AzureFiles",
                Location = "westus"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "AzureFiles", null, true, "westus", "West US");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForSqlEdge()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "SqlEdge"
            };
            AsyncPageable<ReservationCatalog> catalogResponse = Subscription.GetCatalogAsync(options);
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();
            TestGetCatalogResponse(catalogResult, "SqlEdge");
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCatalogForVirtualMachineSoftware()
        {
            ReservationsGetCatalogOptions options = new ReservationsGetCatalogOptions
            {
                ReservedResourceType = "VirtualMachineSoftware",
                PublisherId = "test_test_pmc2pc1",
                OfferId = "mnk_vmri_test_001",
                PlanId = "testplan001"
            };
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
                    Assert.IsTrue(item.ReservedResourceType.Equals(resourceTypeName) || item.ReservedResourceType.Equals(alternateResourceTypeName));
                }
                else
                {
                    Assert.AreEqual(resourceTypeName, item.ReservedResourceType);
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
