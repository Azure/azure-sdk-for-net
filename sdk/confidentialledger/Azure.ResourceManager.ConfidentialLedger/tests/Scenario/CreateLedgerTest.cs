// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConfidentialLedger.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests.Scenario
{
    [TestFixture]
    public class CreateLedgerTest : AclManagementTestBase
    {
        private ConfidentialLedgerResource _ledgerResource;
        private const string TestFixtureName = "Create";
        private readonly string _ledgerName;

        public CreateLedgerTest() : base(true)
        {
            _ledgerName = TestEnvironment.TestLedgerName + TestFixtureName;
        }

        [Test, Order(1)]
        [RecordedTest]
        public async Task TestNameAvailabilityBeforeCreating()
        {
            LedgerNameAvailabilityResult response = await GetLedgerNameAvailability();
            Assert.True(response.IsNameAvailable);
        }

        [Test, Order(2)]
        [RecordedTest]
        public async Task TestCreateLedger()
        {
            // Create the ledger
            await CreateLedger(_ledgerName);

            _ledgerResource = await GetLedgerByName(_ledgerName);

            Assert.NotNull(_ledgerResource);
            Assert.AreEqual(_ledgerName, _ledgerResource.Data.Properties.LedgerName);
            Assert.NotNull(_ledgerResource.Data.Properties.LedgerUri);
        }

        [Test, Order(3)]
        [RecordedTest]
        public async Task TestNameAvailabilityAfterCreating()
        {
            LedgerNameAvailabilityResult response = await GetLedgerNameAvailability();
            Assert.False(response.IsNameAvailable);
        }

        private async Task<LedgerNameAvailabilityResult> GetLedgerNameAvailability()
        {
            LedgerNameAvailabilityContent ledgerNameAvailabilityContent = new() {
                Name = _ledgerName,
                ResourceType = new ResourceType("Microsoft.ConfidentialLedger/ledgers")
            };
            return await Subscription.CheckLedgerNameAvailabilityAsync(ledgerNameAvailabilityContent);
        }
    }
}
