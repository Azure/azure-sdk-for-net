// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests
{
    public class ConfidentialLedgerClientTests : ClientTestBase
    {
        public ConfidentialLedgerClientTests(bool isAsync) : base(isAsync) { }
        private const string transactionId = "1234";

        [Test]
        public void FailedTransaction()
        {
            var client = InstrumentClient(
                new ConfidentialLedgerClient(
                    new("https://client"),
                    new MockCredential(),
                    new ConfidentialLedgerClientOptions
                    {
                        Transport = new MockTransport(
                            req =>
                            {
                                if (req.Uri.Path.Contains($"transactions/{transactionId}/status"))
                                {
                                    var success = new MockResponse(500);
                                    success.SetContent("success");
                                    return success;
                                }
                                var failed = new MockResponse(200);
                                failed.AddHeader("x-ms-ccf-transaction-id", transactionId);
                                failed.SetContent("failed");
                                return failed;
                            })
                    }));

            var ex = Assert.ThrowsAsync<InvalidOperationException>(
                async () => await client.PostLedgerEntryAsync(RequestContent.Create(new { contents = "test" }), null, true, default));
            Assert.That(ex.Message, Does.Contain(transactionId));
        }
    }
}
