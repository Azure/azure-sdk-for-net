// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests.Scenario
{
    [TestFixture("delete")]
    public class DeleteLedgerTest : AclManagementTestBase
    {
        private ConfidentialLedgerResource _ledgerResource;
        public DeleteLedgerTest(string testFixtureName) : base(true, testFixtureName)
        {
        }

        [SetUp]
        public async Task FixtureSetup()
        {
            await CreateLedger(LedgerName);
            _ledgerResource = await GetLedgerByName(LedgerName);
        }

        [Test, Order(1)]
        [RecordedTest]
        [LiveOnly(Reason = "Test relies on PrincipalId format which currently is not a valid GUID. This will be fixed when the sanitization migrates to the Test Proxy.")]
        public async Task TestDeleteLedger()
        {
            await _ledgerResource.DeleteAsync(WaitUntil.Completed);
            try
            {
                await GetLedgerByName(LedgerName);
                Assert.Fail("Ledger should not exist after delete operation");
            }
            catch (Exception exception)
            {
                Assert.True(exception.Message.Contains("ResourceNotFound"));
            }
        }

        [Test, Order(2)]
        [RecordedTest]
        [LiveOnly(Reason = "Test relies on PrincipalId format which currently is not a valid GUID. This will be fixed when the sanitization migrates to the Test Proxy.")]
        public async Task TestDeleteLedgerOnDeletedLedger()
        {
            await _ledgerResource.DeleteAsync(WaitUntil.Completed);

            ArmOperation armOperation = await _ledgerResource.DeleteAsync(WaitUntil.Completed);
            int responseStatus = (await armOperation.WaitForCompletionResponseAsync()).Status;

            //https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md
            Assert.AreEqual(StatusCodes.Status204NoContent, responseStatus);
        }
    }
}
