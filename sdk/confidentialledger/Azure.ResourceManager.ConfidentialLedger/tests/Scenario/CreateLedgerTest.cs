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
            // Override the default mode to Playback for this test
            // This is necessary as CI is using None mode and does not run tests
            if (Mode == RecordedTestMode.None || Mode == RecordedTestMode.Live)
            {
                Mode = RecordedTestMode.Playback;
            }
        }

        [Test, Order(1)]
        [RecordedTest]
        public async Task TestNameAvailabilityBeforeCreating()
        {
            IgnoreTestInLiveMode();
            ConfidentialLedgerNameAvailabilityResult response = await GetLedgerNameAvailability(LedgerNameInFixture);
            Assert.True(response.IsNameAvailable);
        }

        [Test, Order(2)]
        [RecordedTest]
        public async Task TestCreateLedger()
        {
            IgnoreTestInLiveMode();
            await CreateLedger(LedgerNameInFixture);
            ConfidentialLedgerResource ledgerResource = await GetLedgerByName(LedgerNameInFixture);

            Assert.NotNull(ledgerResource);
            Assert.AreEqual(LedgerNameInFixture, ledgerResource.Data.Properties.LedgerName);
            Assert.NotNull(ledgerResource.Data.Properties.LedgerUri);
        }

        [Test, Order(3)]
        [RecordedTest]
        public async Task TestNameAvailabilityAfterCreating()
        {
            IgnoreTestInLiveMode();
            ConfidentialLedgerNameAvailabilityResult response = await GetLedgerNameAvailability(LedgerNameInFixture);
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
