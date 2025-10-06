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
    [TestFixture("create")]
    public class CreateLedgerTest : AclManagementTestBase
    {
        public CreateLedgerTest(string testFixtureName) : base(true, testFixtureName)
        {
        }

        [Test, Order(1)]
        [RecordedTest]
        public async Task TestNameAvailabilityBeforeCreating()
        {
            ConfidentialLedgerNameAvailabilityResult response = await GetLedgerNameAvailability(LedgerName);
            Assert.True(response.IsNameAvailable);
        }

        [Test, Order(2)]
        [RecordedTest]
        [LiveOnly(Reason = "Test relies on PrincipalId format which currently is not a valid GUID. This will be fixed when the sanitization migrates to the Test Proxy.")]
        public async Task TestCreateLedger()
        {
            // Create the ledger
            await CreateLedger(LedgerName);

            ConfidentialLedgerResource ledgerResource = await GetLedgerByName(LedgerName);

            Assert.NotNull(ledgerResource);
            Assert.AreEqual(LedgerName, ledgerResource.Data.Properties.LedgerName);
            Assert.NotNull(ledgerResource.Data.Properties.LedgerUri);
        }

        [Test, Order(3)]
        [RecordedTest]
        public async Task TestNameAvailabilityAfterCreating()
        {
            ConfidentialLedgerNameAvailabilityResult response = await GetLedgerNameAvailability(LedgerName);
            Assert.False(response.IsNameAvailable);
        }

        /// <summary>
        /// Method checks the availability of the input ledgerName
        /// </summary>
        /// <param name="ledgerName"></param>
        /// <returns></returns>
        private async Task<ConfidentialLedgerNameAvailabilityResult> GetLedgerNameAvailability(string ledgerName)
        {
            ConfidentialLedgerNameAvailabilityContent ledgerNameAvailabilityContent = new() {
                Name = ledgerName,
                ResourceType = new ResourceType("Microsoft.ConfidentialLedger/ledgers")
            };
            return await Subscription.CheckConfidentialLedgerNameAvailabilityAsync(ledgerNameAvailabilityContent);
        }
    }
}
