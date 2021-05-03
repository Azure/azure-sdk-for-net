// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.ConfidentialLedger;
using NUnit.Framework;

namespace Azure.Template.Tests
{
    public class ConfidentialLedgerClientTests : ConfidentialLedgerTestBase
    {
        [Test]
        public void TestFoo()
        {
            var client = new AzureDataConfidentialLedgerClient(
                "https://lyshi-sdk-ledger-2.eastus.cloudapp.azure.com",
                "https://identity.accledger.azure.com/ledgerIdentity/lyshi-sdk-ledger-2",
                Credential,
                Options);

            const string objId = "3c1303ad-140b-493c-ab45-bed8ddbfa72c";
            var user = client.GetUser(objId);
            var stringResult = user.Content.ToString();

            Assert.That(stringResult, Does.Contain(objId));
        }
    }
}
