// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.ConfidentialLedger.Certificate;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests
{
    public class ConfidentialLedgerClientTests : ClientTestBase
    {
        public ConfidentialLedgerClientTests(bool isAsync) : base(isAsync) { }
        private const string transactionId = "1234";

        [Test]
        public async Task FailedTransaction()
        {
            var client = InstrumentClient(
                new ConfidentialLedgerClient(
                    new("https://client.name"),
                    new MockCredential(),
                    ledgerOptions: new ConfidentialLedgerClientOptions
                    {
                        Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
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
                            }),
                    },
                    certificateClientOptions: new ConfidentialLedgerCertificateClientOptions
                    {
                        Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                        Transport = new MockTransport(
                            req =>
                            {
                                var cert = new MockResponse(200);
                                cert.SetContent(
                                    @" {
                                    ""ledgerTlsCertificate"": ""-----BEGIN CERTIFICATE-----\nMIIBejCCASGgAwIBAgIRANPpW17pcDYr1KnqsJH5yC8wCgYIKoZIzj0EAwIwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjEwMzExMDAwMDAwWhcNMjMwNjExMjM1\nOTU5WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazBZMBMGByqGSM49AgEGCCqGSM49\nAwEHA0IABOCPGnfcmfm5Vyax3bvg5Xqg6RUZtda0U5qpmxqGgLfL3LYJd3heTPd\u002B\n51o29pMtKJGG4cWeZ3\u002BYbhZzHnetf8WjUDBOMAwGA1UdEwQFMAMBAf8wHQYDVR0O\nBBYEFFxq\u002BImyEVh4u4BfynwnEAsbvRJBMB8GA1UdIwQYMBaAFFxq\u002BImyEVh4u4Bf\nynwnEAsbvRJBMAoGCCqGSM49BAMCA0cAMEQCIC597R3C89/IzfqjkO31XKy4Rnfy\nXauWszBChtH1v2CoAiAS0tmFNjD3fweHH8O2ySXK/tPCBTq877pIjFGwvuj2uw==\n-----END CERTIFICATE-----\n\u0000"",
                                    ""ledgerId"": ""chrissconfidentialledger""}");
                                return cert;
                            })
                    }
                    ));
            var operation = await client.PostLedgerEntryAsync(WaitUntil.Started, RequestContent.Create(new { contents = "test" }), null, default);
            var ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation.WaitForCompletionResponseAsync());
            Assert.That(ex.Message, Does.Contain(transactionId));
        }

        [Test]
        public void VerifyConnectionDefaultsToTrue()
        {
            var options = new ConfidentialLedgerClientOptions();
            Assert.IsTrue(options.VerifyConnection, "VerifyConnection should default to true to ensure TLS verification is enabled by default.");
        }

        [Test]
        public void CustomCertUri()
        {
            Uri customUri = new Uri("http://my-custom-uri.com");

            var client = InstrumentClient(
                new ConfidentialLedgerClient(
                    new("https://client.name"),
                    new MockCredential(),
                    ledgerOptions: new ConfidentialLedgerClientOptions
                    {
                        CertificateEndpoint = customUri,
                    },
                    certificateClientOptions: new ConfidentialLedgerCertificateClientOptions
                    {
                        Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                        Transport = new MockTransport(
                            req =>
                            {
                                Assert.AreEqual(customUri.Host, req.Uri.Host);
                                var cert = new MockResponse(200);
                                cert.SetContent(
                                    @" {
                                    ""ledgerTlsCertificate"": ""-----BEGIN CERTIFICATE-----\nMIIBejCCASGgAwIBAgIRANPpW17pcDYr1KnqsJH5yC8wCgYIKoZIzj0EAwIwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjEwMzExMDAwMDAwWhcNMjMwNjExMjM1\nOTU5WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazBZMBMGByqGSM49AgEGCCqGSM49\nAwEHA0IABOCPGnfcmfm5Vyax3bvg5Xqg6RUZtda0U5qpmxqGgLfL3LYJd3heTPd\u002B\n51o29pMtKJGG4cWeZ3\u002BYbhZzHnetf8WjUDBOMAwGA1UdEwQFMAMBAf8wHQYDVR0O\nBBYEFFxq\u002BImyEVh4u4BfynwnEAsbvRJBMB8GA1UdIwQYMBaAFFxq\u002BImyEVh4u4Bf\nynwnEAsbvRJBMAoGCCqGSM49BAMCA0cAMEQCIC597R3C89/IzfqjkO31XKy4Rnfy\nXauWszBChtH1v2CoAiAS0tmFNjD3fweHH8O2ySXK/tPCBTq877pIjFGwvuj2uw==\n-----END CERTIFICATE-----\n\u0000"",
                                    ""ledgerId"": ""chrissconfidentialledger""}");
                                return cert;
                            })
                    }
                ));
        }

        [Test]
        public void LatestServiceVersionIsNewPreview()
        {
            Assert.AreEqual("2026-07-31-preview", new ConfidentialLedgerClientOptions().Version);
        }

        [Test]
        public async Task PostLedgerEntryWithWaitForCommitReturnsCompletedOperationWithoutPolling()
        {
            bool statusEndpointCalled = false;
            bool waitForCommitQuerySent = false;

            var client = InstrumentClient(
                new ConfidentialLedgerClient(
                    new("https://client.name"),
                    new MockCredential(),
                    ledgerOptions: new ConfidentialLedgerClientOptions
                    {
                        Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                        Transport = new MockTransport(
                            req =>
                            {
                                if (req.Uri.Path.Contains($"transactions/{transactionId}/status"))
                                {
                                    statusEndpointCalled = true;
                                    var status = new MockResponse(200);
                                    status.SetContent(@"{""state"":""Committed"",""transactionId"":""1234""}");
                                    return status;
                                }

                                waitForCommitQuerySent = req.Uri.Query.Contains("waitForCommit=true");
                                var committed = new MockResponse(200);
                                committed.AddHeader("x-ms-ccf-transaction-id", transactionId);
                                committed.SetContent(@"{""collectionId"":""subledger:0""}");
                                return committed;
                            }),
                    },
                    certificateClientOptions: CreateCertificateClientOptions()));

            var operation = await client.PostLedgerEntryAsync(
                WaitUntil.Completed,
                RequestContent.Create(new { contents = "test" }),
                waitForCommit: true);

            Assert.IsTrue(waitForCommitQuerySent, "The waitForCommit=true query parameter should be sent to the service.");
            Assert.IsFalse(statusEndpointCalled, "The transaction status endpoint should not be polled when waitForCommit is true.");
            Assert.IsTrue(operation.HasCompleted, "The operation should be already completed when waitForCommit is true.");
            Assert.AreEqual(transactionId, operation.Id);
        }

        [Test]
        public async Task PostLedgerEntryWithoutWaitForCommitPollsStatus()
        {
            bool statusEndpointCalled = false;
            bool waitForCommitQuerySent = false;

            var client = InstrumentClient(
                new ConfidentialLedgerClient(
                    new("https://client.name"),
                    new MockCredential(),
                    ledgerOptions: new ConfidentialLedgerClientOptions
                    {
                        Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                        Transport = new MockTransport(
                            req =>
                            {
                                if (req.Uri.Path.Contains($"transactions/{transactionId}/status"))
                                {
                                    statusEndpointCalled = true;
                                    var status = new MockResponse(200);
                                    status.SetContent(@"{""state"":""Committed"",""transactionId"":""1234""}");
                                    return status;
                                }

                                if (req.Uri.Query.Contains("waitForCommit"))
                                {
                                    waitForCommitQuerySent = true;
                                }
                                var accepted = new MockResponse(200);
                                accepted.AddHeader("x-ms-ccf-transaction-id", transactionId);
                                accepted.SetContent(@"{""collectionId"":""subledger:0""}");
                                return accepted;
                            }),
                    },
                    certificateClientOptions: CreateCertificateClientOptions()));

            var operation = await client.PostLedgerEntryAsync(
                WaitUntil.Completed,
                RequestContent.Create(new { contents = "test" }));

            Assert.IsFalse(waitForCommitQuerySent, "The waitForCommit query parameter should not be sent by default.");
            Assert.IsTrue(statusEndpointCalled, "The transaction status endpoint should be polled when waitForCommit is not set.");
            Assert.IsTrue(operation.HasCompleted);
        }

        private static ConfidentialLedgerCertificateClientOptions CreateCertificateClientOptions() =>
            new ConfidentialLedgerCertificateClientOptions
            {
                Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                Transport = new MockTransport(
                    req =>
                    {
                        var cert = new MockResponse(200);
                        cert.SetContent(
                            @" {
                            ""ledgerTlsCertificate"": ""-----BEGIN CERTIFICATE-----\nMIIBejCCASGgAwIBAgIRANPpW17pcDYr1KnqsJH5yC8wCgYIKoZIzj0EAwIwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjEwMzExMDAwMDAwWhcNMjMwNjExMjM1\nOTU5WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazBZMBMGByqGSM49AgEGCCqGSM49\nAwEHA0IABOCPGnfcmfm5Vyax3bvg5Xqg6RUZtda0U5qpmxqGgLfL3LYJd3heTPd\u002B\n51o29pMtKJGG4cWeZ3\u002BYbhZzHnetf8WjUDBOMAwGA1UdEwQFMAMBAf8wHQYDVR0O\nBBYEFFxq\u002BImyEVh4u4BfynwnEAsbvRJBMB8GA1UdIwQYMBaAFFxq\u002BImyEVh4u4Bf\nynwnEAsbvRJBMAoGCCqGSM49BAMCA0cAMEQCIC597R3C89/IzfqjkO31XKy4Rnfy\nXauWszBChtH1v2CoAiAS0tmFNjD3fweHH8O2ySXK/tPCBTq877pIjFGwvuj2uw==\n-----END CERTIFICATE-----\n\u0000"",
                            ""ledgerId"": ""chrissconfidentialledger""}");
                        return cert;
                    })
            };
    }
}
