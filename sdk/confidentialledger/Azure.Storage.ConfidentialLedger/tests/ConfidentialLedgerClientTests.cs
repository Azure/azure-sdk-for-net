// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Storage.ConfidentialLedger.Tests
{
    public class ConfidentialLedgerClientTests : ConfidentialLedgerTestBase
    {
        [Test]
        public void GetUser()
        {
            ConfidentialLedgerClient client = GetClient();

            const string objId = "3c1303ad-140b-493c-ab45-bed8ddbfa72c";
            var user = client.GetUser(objId);
            var stringResult = user.Content.ToString();

            Assert.That(stringResult, Does.Contain(objId));
        }

        [Test]
        public void GetLedgerEntries()
        {
            ConfidentialLedgerClient client = GetClient();

            var result = client.GetLedgerEntries();
            var stringResult = result.Content.ToString();
        }

        private ConfidentialLedgerClient GetClient()
        {
            var client = new ConfidentialLedgerClient(
                "https://lyshi-sdk-ledger-2.eastus.cloudapp.azure.com",
                "https://identity.accledger.azure.com/ledgerIdentity/lyshi-sdk-ledger-2",
                Credential,
                Options);
            return client;
        }
    }
}
