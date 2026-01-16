// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Reservations.Tests
{
    public class GetAppliedReservationListTests : ReservationsManagementClientBase
    {
        public GetAppliedReservationListTests(bool isAsync) : base(isAsync)
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
        public async Task TestAppliedReservationList()
        {
            var response = await Subscription.GetAppliedReservationsAsync();

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.ReservationOrderIds, Is.Not.Null);
            Assert.That(response.Value.ReservationOrderIds.Value, Is.Not.Null);
            Assert.That(response.Value.ReservationOrderIds.Value.Count, Is.EqualTo(127));
        }
    }
}
