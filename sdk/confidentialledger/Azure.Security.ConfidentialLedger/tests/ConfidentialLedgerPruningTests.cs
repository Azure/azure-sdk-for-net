// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.ConfidentialLedger.Certificate;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests
{
    /// <summary>
    /// Unit tests for the combined SDK resiliency features:
    /// archived-collection (pruning) fallback, GetLedgerEntry auto-poll while Loading,
    /// and PostLedgerEntryOperation 406/404 polling tolerance.
    /// </summary>
    public class ConfidentialLedgerPruningTests : ClientTestBase
    {
        public ConfidentialLedgerPruningTests(bool isAsync) : base(isAsync) { }

        private const string LedgerTlsCert =
            @"-----BEGIN CERTIFICATE-----\nMIIBejCCASGgAwIBAgIRANPpW17pcDYr1KnqsJH5yC8wCgYIKoZIzj0EAwIwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjEwMzExMDAwMDAwWhcNMjMwNjExMjM1\nOTU5WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazBZMBMGByqGSM49AgEGCCqGSM49\nAwEHA0IABOCPGnfcmfm5Vyax3bvg5Xqg6RUZtda0U5qpmxqGgLfL3LYJd3heTPd\u002B\n51o29pMtKJGG4cWeZ3\u002BYbhZzHnetf8WjUDBOMAwGA1UdEwQFMAMBAf8wHQYDVR0O\nBBYEFFxq\u002BImyEVh4u4BfynwnEAsbvRJBMB8GA1UdIwQYMBaAFFxq\u002BImyEVh4u4Bf\nynwnEAsbvRJBMAoGCCqGSM49BAMCA0cAMEQCIC597R3C89/IzfqjkO31XKy4Rnfy\nXauWszBChtH1v2CoAiAS0tmFNjD3fweHH8O2ySXK/tPCBTq877pIjFGwvuj2uw==\n-----END CERTIFICATE-----\n\u0000";

        private static MockTransport CreateCertTransport() => new MockTransport(req =>
        {
            var cert = new MockResponse(200);
            cert.SetContent($@"{{ ""ledgerTlsCertificate"": ""{LedgerTlsCert}"", ""ledgerId"": ""testledger"" }}");
            return cert;
        });

        private ConfidentialLedgerClient CreateClient(MockTransport ledgerTransport, bool enableArchivedFallback, int maxRetries = 0)
        {
            return InstrumentClient(new ConfidentialLedgerClient(
                new Uri("https://testledger.confidential-ledger.azure.com"),
                new MockCredential(),
                ledgerOptions: new ConfidentialLedgerClientOptions
                {
                    Retry = { Delay = TimeSpan.Zero, MaxRetries = maxRetries },
                    Transport = ledgerTransport,
                    EnableArchivedCollectionFallback = enableArchivedFallback,
                },
                certificateClientOptions: new ConfidentialLedgerCertificateClientOptions
                {
                    Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                    Transport = CreateCertTransport(),
                }));
        }

        [Test]
        public async Task ArchivedCollectionFallback_Enabled_ReturnsLatestHistoricalEntry()
        {
            const string collectionId = "my-collection";
            bool rangeQueried = false;

            var transport = new MockTransport(req =>
            {
                string path = req.Uri.Path;
                if (path.Contains("/current"))
                {
                    // Collection's live entry has been archived (pruned) -> 404.
                    return new MockResponse(404);
                }
                if (path.EndsWith("/app/transactions"))
                {
                    // Historical range query returns the collection's entries (oldest-first).
                    rangeQueried = true;
                    var ok = new MockResponse(200);
                    ok.SetContent(
                        $@"{{ ""state"": ""Ready"", ""entries"": [
                            {{ ""contents"": ""old"", ""collectionId"": ""{collectionId}"", ""transactionId"": ""2.3"" }},
                            {{ ""contents"": ""latest"", ""collectionId"": ""{collectionId}"", ""transactionId"": ""2.7"" }}
                        ] }}");
                    return ok;
                }
                return new MockResponse(404);
            });

            var client = CreateClient(transport, enableArchivedFallback: true);

            Response response = await client.GetCurrentLedgerEntryAsync(collectionId);

            Assert.AreEqual(200, response.Status);
            Assert.IsTrue(rangeQueried, "Expected the historical range query to be used as a fallback.");

            using JsonDocument doc = JsonDocument.Parse(response.Content);
            JsonElement root = doc.RootElement;
            Assert.AreEqual("latest", root.GetProperty("contents").GetString());
            Assert.AreEqual(collectionId, root.GetProperty("collectionId").GetString());
            Assert.AreEqual("2.7", root.GetProperty("transactionId").GetString());
        }

        [Test]
        public void ArchivedCollectionFallback_Disabled_DoesNotQueryHistoryAndThrows()
        {
            const string collectionId = "my-collection";
            bool rangeQueried = false;

            var transport = new MockTransport(req =>
            {
                string path = req.Uri.Path;
                if (path.EndsWith("/app/transactions"))
                {
                    rangeQueried = true;
                    var ok = new MockResponse(200);
                    ok.SetContent(@"{ ""state"": ""Ready"", ""entries"": [ { ""contents"": ""latest"" } ] }");
                    return ok;
                }
                // current + failover metadata all 404 -> the call ultimately fails.
                return new MockResponse(404);
            });

            var client = CreateClient(transport, enableArchivedFallback: false);

            Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetCurrentLedgerEntryAsync(collectionId));
            Assert.IsFalse(rangeQueried, "Historical range query must not be used when the fallback is disabled.");
        }

        [Test]
        public async Task GetLedgerEntry_RetriesWhileLoading_ViaRetryPolicy()
        {
            const string transactionId = "2.9";
            int callCount = 0;

            var transport = new MockTransport(req =>
            {
                callCount++;
                var resp = new MockResponse(200);
                if (callCount == 1)
                {
                    // First read: entry is still being committed.
                    resp.SetContent(@"{ ""state"": ""Loading"" }");
                }
                else
                {
                    resp.SetContent($@"{{ ""state"": ""Ready"", ""entry"": {{ ""contents"": ""done"", ""transactionId"": ""{transactionId}"" }} }}");
                }
                return resp;
            });

            // The response classifier marks the 200 "Loading" response retriable, so the configured
            // retry policy polls until the entry is ready. Allow at least one retry with no delay.
            var client = CreateClient(transport, enableArchivedFallback: false, maxRetries: 3);

            Response response = await client.GetLedgerEntryAsync(transactionId);

            Assert.AreEqual(200, response.Status);
            Assert.GreaterOrEqual(callCount, 2, "Expected the retry policy to re-request while the entry was Loading.");
            using JsonDocument doc = JsonDocument.Parse(response.Content);
            Assert.AreEqual("Ready", doc.RootElement.GetProperty("state").GetString());
        }

        [Test]
        public async Task PostLedgerEntryOperation_Treats406AsPendingThenSucceeds()
        {
            const string transactionId = "3.1";
            int statusCalls = 0;

            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.Contains($"transactions/{transactionId}/status"))
                {
                    statusCalls++;
                    if (statusCalls == 1)
                    {
                        // Transaction known but not yet committed.
                        return new MockResponse(406);
                    }
                    var committed = new MockResponse(200);
                    committed.SetContent(@"{ ""state"": ""Committed"" }");
                    return committed;
                }

                // The initial POST response carries the transaction id header.
                var posted = new MockResponse(200);
                posted.AddHeader("x-ms-ccf-transaction-id", transactionId);
                posted.SetContent("posted");
                return posted;
            });

            var client = CreateClient(transport, enableArchivedFallback: false);

            Operation operation = await client.PostLedgerEntryAsync(WaitUntil.Started, RequestContent.Create(new { contents = "x" }));
            Response response = await operation.WaitForCompletionResponseAsync();

            Assert.AreEqual(200, response.Status);
            Assert.GreaterOrEqual(statusCalls, 2, "Expected the operation to keep polling after a 406 response.");
        }

        [Test]
        public async Task PostLedgerEntryOperation_Tolerates404sThenSucceeds()
        {
            const string transactionId = "3.2";
            int statusCalls = 0;

            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.Contains($"transactions/{transactionId}/status"))
                {
                    statusCalls++;
                    // Two transient 404s (replication lag) then a committed response.
                    if (statusCalls <= 2)
                    {
                        return new MockResponse(404);
                    }
                    var committed = new MockResponse(200);
                    committed.SetContent(@"{ ""state"": ""Committed"" }");
                    return committed;
                }

                var posted = new MockResponse(200);
                posted.AddHeader("x-ms-ccf-transaction-id", transactionId);
                posted.SetContent("posted");
                return posted;
            });

            var client = CreateClient(transport, enableArchivedFallback: false);

            Operation operation = await client.PostLedgerEntryAsync(WaitUntil.Started, RequestContent.Create(new { contents = "x" }));
            Response response = await operation.WaitForCompletionResponseAsync();

            Assert.AreEqual(200, response.Status);
            Assert.GreaterOrEqual(statusCalls, 3, "Expected the operation to tolerate transient 404s and keep polling.");
        }

        [Test]
        public async Task PostLedgerEntryOperation_FailsAfterTooMany404s()
        {
            const string transactionId = "3.3";
            int statusCalls = 0;

            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.Contains($"transactions/{transactionId}/status"))
                {
                    statusCalls++;
                    // Persistent 404 -> the transaction id is treated as invalid after the tolerance.
                    return new MockResponse(404);
                }

                var posted = new MockResponse(200);
                posted.AddHeader("x-ms-ccf-transaction-id", transactionId);
                posted.SetContent("posted");
                return posted;
            });

            var client = CreateClient(transport, enableArchivedFallback: false);

            Operation operation = await client.PostLedgerEntryAsync(WaitUntil.Started, RequestContent.Create(new { contents = "x" }));
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionResponseAsync());
            Assert.GreaterOrEqual(statusCalls, 4, "Expected the operation to fail only after exceeding the 404 tolerance.");
        }
    }
}
