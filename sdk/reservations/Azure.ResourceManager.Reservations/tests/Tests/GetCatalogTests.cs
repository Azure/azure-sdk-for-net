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
        public GetCatalogTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            // if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            // {
            await InitializeClients();
            // }
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
    }
}
