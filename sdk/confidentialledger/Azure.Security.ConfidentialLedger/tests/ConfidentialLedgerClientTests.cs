// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.ConfidentialLedger.Certificate;
using Azure.Security.ConfidentialLedger.Models;
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
        public void DefaultServiceVersionIsLatestGa()
        {
            Assert.AreEqual("2026-02-23", new ConfidentialLedgerClientOptions().Version);
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
                                committed.SetContent(@"{""collectionId"":""subledger:0"",""state"":""Committed""}");
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

        [Test]
        public async Task PostLedgerEntryWithWaitForCommitFallsBackToPollingWhenBodyNotCommitted()
        {
            // Simulates an API version or service build that does not honor waitForCommit: it ignores
            // the query parameter and returns a normal local-commit 200 whose body does not report
            // "state": "Committed". The client must not assume the transaction is globally committed;
            // it must fall back to polling the transaction status endpoint.
            bool statusEndpointCalled = false;

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

                                var accepted = new MockResponse(200);
                                accepted.AddHeader("x-ms-ccf-transaction-id", transactionId);
                                accepted.SetContent(@"{""collectionId"":""subledger:0"",""state"":""Pending""}");
                                return accepted;
                            }),
                    },
                    certificateClientOptions: CreateCertificateClientOptions()));

            var operation = await client.PostLedgerEntryAsync(
                WaitUntil.Completed,
                RequestContent.Create(new { contents = "test" }),
                waitForCommit: true);

            Assert.IsTrue(statusEndpointCalled, "The status endpoint must be polled when the waitForCommit response body does not report a committed state.");
            Assert.IsTrue(operation.HasCompleted);
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task TypedPostLedgerEntryReturnsWriteResultWithTransactionId(bool waitForCommit)
        {
            string requestBody = null;
            var client = CreateClient(req =>
            {
                if (req.Uri.Path.Contains($"transactions/{transactionId}/status"))
                {
                    var status = new MockResponse(200);
                    status.SetContent(@"{""state"":""Committed"",""transactionId"":""1234""}");
                    return status;
                }

                requestBody = ReadBody(req);
                StringAssert.DoesNotContain("collectionId", req.Uri.Query);
                var response = new MockResponse(200);
                response.AddHeader("x-ms-ccf-transaction-id", transactionId);
                // The service selects the collection when none is requested.
                response.SetContent(waitForCommit
                    ? @"{""collectionId"":""subledger:0"",""state"":""Committed""}"
                    : @"{""collectionId"":""subledger:0""}");
                return response;
            });

            Operation<LedgerWriteResult> operation = await client.PostLedgerEntryAsync(
                WaitUntil.Completed,
                new LedgerEntry("hello"),
                waitForCommit: waitForCommit);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(transactionId, operation.Id);
            Assert.AreEqual(transactionId, operation.Value.TransactionId);
            Assert.AreEqual("subledger:0", operation.Value.CollectionId);
            Assert.AreEqual(TransactionState.Committed, operation.Value.State);
            Assert.AreEqual("hello", JsonDocument.Parse(requestBody).RootElement.GetProperty("contents").GetString());
        }

        [Test]
        public async Task TypedCreateLedgerEntryPopulatesTransactionIdFromHeader()
        {
            var client = CreateClient(req =>
            {
                var response = new MockResponse(200);
                response.AddHeader("x-ms-ccf-transaction-id", transactionId);
                response.SetContent(@"{""collectionId"":""subledger:0""}");
                return response;
            });

            Response<LedgerWriteResult> result = await client.CreateLedgerEntryAsync(new LedgerEntry("hello"));

            Assert.AreEqual(transactionId, result.Value.TransactionId);
            Assert.AreEqual("subledger:0", result.Value.CollectionId);
        }

        [Test]
        public async Task TypedCreateOrUpdateLedgerUserSendsMergePatchBody()
        {
            string contentType = null;
            string requestBody = null;
            var client = CreateClient(req =>
            {
                req.Headers.TryGetValue("Content-Type", out contentType);
                requestBody = ReadBody(req);
                var response = new MockResponse(200);
                response.SetContent(@"{""userId"":""user1"",""assignedRoles"":[""Reader""]}");
                return response;
            });

            Response<LedgerUserMultipleRoles> result = await client.CreateOrUpdateLedgerUserAsync(
                "user1",
                new LedgerUserMultipleRoles(new[] { ConfidentialLedgerUserRoleName.Reader }));

            Assert.AreEqual("application/merge-patch+json", contentType);
            JsonElement body = JsonDocument.Parse(requestBody).RootElement;
            Assert.IsFalse(body.TryGetProperty("userId", out _), "Read-only userId must not be sent.");
            Assert.AreEqual("Reader", body.GetProperty("assignedRoles")[0].GetString());
            Assert.AreEqual("user1", result.Value.UserId);
            CollectionAssert.AreEqual(new[] { ConfidentialLedgerUserRoleName.Reader }, result.Value.AssignedRoles);
        }

        [Test]
        public async Task TypedUpdateRuntimeOptionsOmitsUnsetProperties()
        {
            string requestBody = null;
            var client = CreateClient(req =>
            {
                requestBody = ReadBody(req);
                var response = new MockResponse(200);
                response.SetContent(@"{""max_heap_bytes"":1024,""max_stack_bytes"":512}");
                return response;
            });

            Response<JsRuntimeOptions> result = await client.UpdateRuntimeOptionsStableAsync(new JsRuntimeOptions { MaxHeapBytes = 1024 });

            JsonElement body = JsonDocument.Parse(requestBody).RootElement;
            Assert.AreEqual(1024, body.GetProperty("max_heap_bytes").GetInt64());
            Assert.AreEqual(1, body.EnumerateObject().Count(), "Only explicitly set properties should be sent in a merge patch.");
            Assert.AreEqual(512, result.Value.MaxStackBytes);
        }

        [Test]
        public async Task TypedGetLedgerIdentityInformationReturnsModel()
        {
            var identityClient = InstrumentClient(new ConfidentialLedgerCertificateClient(
                new Uri("https://identity.confidential-ledger.core.azure.com"),
                CreateCertificateClientOptions()));

            Response<LedgerIdentityInformation> identity = await identityClient.GetLedgerIdentityInformationAsync("chrissconfidentialledger");

            Assert.AreEqual("chrissconfidentialledger", identity.Value.LedgerId);
            StringAssert.StartsWith("-----BEGIN CERTIFICATE-----", identity.Value.LedgerTlsCertificate);
        }

        private ConfidentialLedgerClient CreateClient(Func<MockRequest, MockResponse> handler) =>
            InstrumentClient(
                new ConfidentialLedgerClient(
                    new("https://client.name"),
                    new MockCredential(),
                    ledgerOptions: new ConfidentialLedgerClientOptions
                    {
                        Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                        Transport = new MockTransport(handler),
                    },
                    certificateClientOptions: CreateCertificateClientOptions()));

        private static string ReadBody(MockRequest request)
        {
            if (request.Content == null)
            {
                return null;
            }
            using var stream = new MemoryStream();
            request.Content.WriteTo(stream, default);
            return Encoding.UTF8.GetString(stream.ToArray());
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
