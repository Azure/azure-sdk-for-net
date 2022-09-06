// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests.Scenario
{
    [TestFixture]
    public class CreateLedgerTest : AclManagementTestBase
    {
        private const string LedgerName = AclManagementTestEnvironment.TestLedgerName;
        private ConfidentialLedgerResource _ledgerResource;

        public CreateLedgerTest() : base(true)
        {
        }

        [SetUp]
        public async Task InitializeTestFixture()
        {
            var timer = new Stopwatch();
            timer.Start();

            if (Mode is RecordedTestMode.Record or RecordedTestMode.Playback)
            {
                await InitializeClients();
            }

            // Create the ledger
            await CreateLedger(LedgerName, AzureLocation.WestEurope);

            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            TestContext.WriteLine("Time taken By Initializer: {0} second {1} millisecond",
                timeTaken.Milliseconds.ToString(), timeTaken.Milliseconds.ToString());
        }

        [Test]
        public async Task TestCreateLedger()
        {
            var timer = new Stopwatch();
            timer.Start();

            // Fetch the ledger created in setup stage.
            _ledgerResource = await GetLedgerByName(LedgerName);
            Assert.NotNull(_ledgerResource);
            Assert.AreEqual(LedgerName, _ledgerResource.Data.Properties.LedgerName);

            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            TestContext.WriteLine("Time taken By Test: {0} second {1} millisecond",
                timeTaken.Milliseconds.ToString(), timeTaken.Milliseconds.ToString());
        }
    }
}
