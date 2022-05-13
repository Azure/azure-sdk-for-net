// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EdgeOrder.Tests;
using Azure.ResourceManager.Reservations.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Reservations.Tests.Tests
{
    [TestFixture]
    public class GetCatalogTests : ReservationsManagementClientBase
    {
        public GetCatalogTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            //if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            //{
            await InitializeClients();
            //}
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase, Order(1)]
        public async Task TestGetCatalogForVirtualMachines()
        {
            AsyncPageable<ReservationCatalog> catalogResponse = ReservationsExtensions.GetCatalogAsync(Subscription, "VirtualMachines", "eastus");
            List<ReservationCatalog> catalogResult = await catalogResponse.ToEnumerableAsync();

            Assert.NotNull(catalogResult);
        }
    }
}
