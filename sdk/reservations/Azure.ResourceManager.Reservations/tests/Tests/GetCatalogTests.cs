// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Reservations.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Reservations.Tests
{
    public class GetCatalogTests : ReservationsManagementClientBase
    {
        public GetCatalogTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
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
        }
    }
}
