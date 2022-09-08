// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests.Scenario
{
    [TestFixture]
    public class DeleteLedgerTest : AclManagementTestBase
    {
        private ConfidentialLedgerResource _ledgerResource;
        private const string TestFixtureName = "Delete";
        private readonly string _ledgerName;

        public DeleteLedgerTest(bool isAsync) : base(isAsync)
        {
            _ledgerName = TestEnvironment.TestLedgerName + TestFixtureName;
        }

        [Test, Order(1)]
        [RecordedTest]
        public async Task TestDeleteLedger()
        {
            await CreateLedger(_ledgerName);
            _ledgerResource = await GetLedgerByName(_ledgerName);

            await _ledgerResource.DeleteAsync(WaitUntil.Completed);
            try
            {
                await GetLedgerByName(_ledgerName);
                Assert.Fail("Ledger should not exist after delete");
            }
            catch (Exception exception)
            {
                Assert.True(exception.Message.Contains("ResourceNotFound"));
                Assert.AreEqual("Azure.ResourceManager.ConfidentialLedger", exception.Source);
            }
        }

        /**
         * When the requested the resource does not exist in a delete call, api guidelines advise to return 204.
         * 204 is being wrapped in 200 response code at ARM level.
         * https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md
         *
         */
        [Test, Order(2)]
        [RecordedTest]
        public async Task TestDeleteLedgerOnDeletedLedger()
        {
            ArmOperation armOperation = await _ledgerResource.DeleteAsync(WaitUntil.Completed);
            int responseStatus = (await armOperation.WaitForCompletionResponseAsync()).Status;
            Assert.AreEqual(StatusCodes.Status200OK, responseStatus);
        }
    }
}
