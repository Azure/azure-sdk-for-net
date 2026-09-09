// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
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

        private const string AlternateLedgerTlsCert =
            @"-----BEGIN CERTIFICATE-----\nMIIBezCCASGgAwIBAgIRAJm8lmSE26KV0eDDXrRD6LQwCgYIKoZIzj0EAwIwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjEwMzExMDAwMDAwWhcNMjMwNjExMjM1\nOTU5WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazBZMBMGByqGSM49AgEGCCqGSM49\nAwEHA0IABJDsxegT33aucCNaiHPK2YNPqwRg1Y2xxVVkII9yUCs6QyNJoCWI4Zfv\nj7iCOpaaBFxDBOuXcqyzXix\u002Be0r3rZyjUDBOMAwGA1UdEwQFMAMBAf8wHQYDVR0O\nBBYEFLmINpd7X6PFiqD3z0FsjUgDyHtDMB8GA1UdIwQYMBaAFLmINpd7X6PFiqD3\nz0FsjUgDyHtDMAoGCCqGSM49BAMCA0gAMEUCIQD13yI1tEd9m0CtyfSqUnN80wYr\n6QRh9JO3tuSMA10b2gIgGZTs\u002BkowdDjP//U5fgCBovlcGIhdiBBF2wuHnLfqAkI=\n-----END CERTIFICATE-----\n\u0000";

        private static MockTransport CreateCertTransport() => new MockTransport(req =>
        {
            var cert = new MockResponse(200);
            cert.SetContent($@"{{ ""ledgerTlsCertificate"": ""{LedgerTlsCert}"", ""ledgerId"": ""testledger"" }}");
            return cert;
        });

        private ConfidentialLedgerClient CreateClient(HttpPipelineTransport ledgerTransport, bool enableArchivedFallback, int maxRetries = 0, Action<ConfidentialLedgerClientOptions> configure = null)
        {
            var options = new ConfidentialLedgerClientOptions
            {
                Retry = { Delay = TimeSpan.Zero, MaxRetries = maxRetries },
                Transport = ledgerTransport,
                EnableArchivedCollectionFallback = enableArchivedFallback,
            };
            configure?.Invoke(options);
            return InstrumentClient(new ConfidentialLedgerClient(
                new Uri("https://testledger.confidential-ledger.azure.com"),
                new MockCredential(),
                ledgerOptions: options,
                certificateClientOptions: new ConfidentialLedgerCertificateClientOptions
                {
                    Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                    Transport = CreateCertTransport(),
                }));
        }

        [Test]
        public void ArchivedCollectionFallback_IsDisabledByDefault()
        {
            var options = new ConfidentialLedgerClientOptions();

            Assert.IsFalse(options.EnableArchivedCollectionFallback);
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
                              {{ ""contents"": ""latest"", ""collectionId"": ""{collectionId}"", ""transactionId"": ""2.7"", ""tags"": [""retained""] }}
                        ] }}");
                    return ok;
                }
                return new MockResponse(404);
            });

            var client = CreateClient(transport, enableArchivedFallback: true);

            Response response = await client.GetCurrentLedgerEntryAsync(collectionId, new RequestContext());

            Assert.AreEqual(200, response.Status);
            Assert.IsTrue(rangeQueried, "Expected the historical range query to be used as a fallback.");

            using JsonDocument doc = JsonDocument.Parse(response.Content);
            JsonElement root = doc.RootElement;
            Assert.AreEqual("latest", root.GetProperty("contents").GetString());
            Assert.AreEqual(collectionId, root.GetProperty("collectionId").GetString());
            Assert.AreEqual("2.7", root.GetProperty("transactionId").GetString());
            Assert.AreEqual("retained", root.GetProperty("tags")[0].GetString());
        }

        [Test]
        public async Task ArchivedCollectionFallback_RetriesHistoricalRangeWhileLoading()
        {
            const string collectionId = "my-collection";
            int rangeCalls = 0;

            var transport = new MockTransport(req =>
            {
                string path = req.Uri.Path;
                if (path.Contains("/current"))
                {
                    return new MockResponse(404);
                }
                if (path.EndsWith("/app/transactions"))
                {
                    rangeCalls++;
                    var response = new MockResponse(200);
                    if (rangeCalls == 1)
                    {
                        response.SetContent(
                            $@"{{ ""state"": ""Loading"", ""nextLink"": ""/app/transactions?api-version=2024-12-09-preview&collectionId={collectionId}&fromTransactionId=1.2"" }}");
                    }
                    else
                    {
                        response.SetContent(
                            $@"{{ ""state"": ""Ready"", ""entries"": [
                                {{ ""contents"": ""latest"", ""collectionId"": ""{collectionId}"", ""transactionId"": ""2.7"" }}
                            ] }}");
                    }
                    return response;
                }
                return new MockResponse(404);
            });

            var client = CreateClient(transport, enableArchivedFallback: true, maxRetries: 3);

            Response response = await client.GetCurrentLedgerEntryAsync(collectionId, new RequestContext());

            Assert.AreEqual(200, response.Status);
            Assert.GreaterOrEqual(rangeCalls, 2);
            using JsonDocument doc = JsonDocument.Parse(response.Content);
            Assert.AreEqual("latest", doc.RootElement.GetProperty("contents").GetString());
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

            Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetCurrentLedgerEntryAsync(collectionId, new RequestContext()));
            Assert.IsFalse(rangeQueried, "Historical range query must not be used when the fallback is disabled.");
        }

        [Test]
        public void CollectionCapacityExceeded_IsSurfacedWithoutWriteFailover()
        {
            int failoverMetadataCalls = 0;
            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.StartsWith("/failover/"))
                {
                    failoverMetadataCalls++;
                    return new MockResponse(500);
                }

                var response = new MockResponse(400);
                response.SetContent(
                    @"{ ""error"": { ""code"": ""CollectionCapacityExceeded"", ""message"": ""Collection capacity 10 has been reached."" } }");
                return response;
            });

            var client = CreateClient(transport, enableArchivedFallback: true, maxRetries: 3);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await client.CreateLedgerEntryAsync(
                    RequestContent.Create(new { contents = "overflow" }),
                    collectionId: "new-collection",
                    context: new RequestContext()));

            Assert.AreEqual(400, exception.Status);
            Assert.AreEqual("CollectionCapacityExceeded", exception.ErrorCode);
            Assert.AreEqual(0, failoverMetadataCalls, "Capacity failures on writes must not trigger failover.");
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

            Response response = await client.GetLedgerEntryAsync(transactionId, null, new RequestContext());

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
            Assert.AreEqual(4, statusCalls, "Three individual 404 HTTP requests are tolerated; the fourth fails.");
        }

        [TestCase(408)]
        [TestCase(429)]
        [TestCase(500)]
        [TestCase(503)]
        public async Task Failover_RoutesEligibleReadsForRetryableStatus(int status)
        {
            var hosts = new List<string>();
            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.StartsWith("/failover/"))
                {
                    var metadata = new MockResponse(200);
                    metadata.SetContent(@"{ ""failoverLedgers"": [ ""backup"" ] }");
                    return metadata;
                }
                hosts.Add(req.Uri.Host);
                if (req.Uri.Host.StartsWith("testledger"))
                {
                    return new MockResponse(status);
                }
                var response = new MockResponse(200);
                response.SetContent(@"{ ""state"": ""Ready"", ""entry"": { ""contents"": ""ok"" } }");
                return response;
            });
            var client = CreateClient(transport, false, maxRetries: 1);

            Response response = await client.GetLedgerEntryAsync("2.1", null, new RequestContext());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, hosts.FindAll(host => host.StartsWith("testledger")).Count);
            Assert.AreEqual(1, hosts.FindAll(host => host.StartsWith("backup")).Count);
        }

        [Test]
        public async Task Failover_TransportExceptionAfterPrimaryRetries_UsesIndependentRetryBudget()
        {
            int primaryCalls = 0;
            int backupCalls = 0;
            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.StartsWith("/failover/"))
                {
                    var metadata = new MockResponse(200);
                    metadata.SetContent(@"{ ""failoverLedgers"": [ ""backup"" ] }");
                    return metadata;
                }
                if (req.Uri.Host.StartsWith("testledger"))
                {
                    primaryCalls++;
                    throw new HttpRequestException("primary unavailable");
                }
                backupCalls++;
                if (backupCalls == 1)
                {
                    return new MockResponse(503);
                }
                var response = new MockResponse(200);
                response.SetContent(@"{ ""contents"": ""ok"" }");
                return response;
            });
            var client = CreateClient(transport, false, maxRetries: 1);

            Response response = await client.GetCurrentLedgerEntryAsync(null, new RequestContext());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, primaryCalls, "Primary gets its initial request plus one retry.");
            Assert.AreEqual(2, backupCalls, "Failover gets an independent initial request plus one retry.");
        }

        [Test]
        public void Failover_SyncTransportExceptionSucceeds()
        {
            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.StartsWith("/failover/"))
                {
                    var metadata = new MockResponse(200);
                    metadata.SetContent(@"{ ""failoverLedgers"": [ ""backup"" ] }");
                    return metadata;
                }
                if (req.Uri.Host.StartsWith("testledger"))
                {
                    throw new TimeoutException("network timeout");
                }
                var response = new MockResponse(200);
                response.SetContent(@"{ ""contents"": ""ok"" }");
                return response;
            });
            var client = new ConfidentialLedgerClient(
                new Uri("https://testledger.confidential-ledger.azure.com"),
                new MockCredential(),
                ledgerOptions: new ConfidentialLedgerClientOptions { Transport = transport, Retry = { MaxRetries = 0 } },
                certificateClientOptions: new ConfidentialLedgerCertificateClientOptions { Transport = CreateCertTransport() });

            Assert.AreEqual(200, client.GetCurrentLedgerEntry(null, new RequestContext()).Status);
        }

        [Test]
        public void Failover_CallerCancellationDoesNotDiscoverOrFailOver()
        {
            int metadataCalls = 0;
            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.StartsWith("/failover/"))
                {
                    metadataCalls++;
                }
                throw new OperationCanceledException();
            });
            var client = CreateClient(transport, false);
            using var source = new CancellationTokenSource();
            source.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () =>
                await client.GetCurrentLedgerEntryAsync(null, new RequestContext { CancellationToken = source.Token }));
            Assert.AreEqual(0, metadataCalls);
        }

        [Test]
        public async Task Failover_AppliesConfiguredNetworkTimeoutToFailoverOnly()
        {
            var observed = new List<TimeSpan>();
            MockTransport transport = MockTransport.FromMessageCallback(message =>
            {
                if (message.Request.Uri.Path.StartsWith("/failover/"))
                {
                    var metadata = new MockResponse(200);
                    metadata.SetContent(@"{ ""failoverLedgers"": [ ""backup"" ] }");
                    return metadata;
                }
                if (message.Request.Uri.Host.StartsWith("testledger"))
                {
                    return new MockResponse(503);
                }
                observed.Add(message.NetworkTimeout.Value);
                var response = new MockResponse(200);
                response.SetContent(@"{ ""contents"": ""ok"" }");
                return response;
            });
            var client = CreateClient(transport, false, configure: options => options.FailoverNetworkTimeout = TimeSpan.FromSeconds(7));

            await client.GetCurrentLedgerEntryAsync(null, new RequestContext());

            Assert.AreEqual(new[] { TimeSpan.FromSeconds(7) }, observed);
        }

        [Test]
        public void CertificateTrustStore_BindsCertificateToLedgerId()
        {
            var identityResponse = new MockResponse(200);
            identityResponse.SetContent($@"{{ ""ledgerTlsCertificate"": ""{LedgerTlsCert}"" }}");
            using X509Certificate2 certificate = ConfidentialLedgerCertificateClient.ParseCertificate(identityResponse);
            var alternateIdentityResponse = new MockResponse(200);
            alternateIdentityResponse.SetContent($@"{{ ""ledgerTlsCertificate"": ""{AlternateLedgerTlsCert}"" }}");
            using X509Certificate2 alternateCertificate = ConfidentialLedgerCertificateClient.ParseCertificate(alternateIdentityResponse);
            var store = new ConfidentialLedgerCertificateTrustStore(verifyConnection: true);
            store.Trust("ledger-a", certificate);
            store.Trust("ledger-b", alternateCertificate);

            Assert.IsTrue(store.Validate("ledger-a", certificate));
            Assert.IsTrue(store.Validate("ledger-b", alternateCertificate));
            Assert.IsFalse(store.Validate("ledger-b", certificate));
            Assert.IsFalse(store.Validate("ledger-a", alternateCertificate));
        }

        [Test]
        public async Task Failover_NonUserCancellationSucceeds()
        {
            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.StartsWith("/failover/"))
                {
                    var metadata = new MockResponse(200);
                    metadata.SetContent(@"{ ""failoverLedgers"": [ ""backup"" ] }");
                    return metadata;
                }
                if (req.Uri.Host.StartsWith("testledger"))
                {
                    throw new OperationCanceledException("transport timeout");
                }
                var response = new MockResponse(200);
                response.SetContent(@"{ ""contents"": ""ok"" }");
                return response;
            });

            Assert.AreEqual(200, (await CreateClient(transport, false).GetCurrentLedgerEntryAsync(null, new RequestContext())).Status);
        }

        [Test]
        public void Failover_MalformedMetadataPreservesOriginalTransportException()
        {
            var original = new HttpRequestException("primary unavailable");
            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.StartsWith("/failover/"))
                {
                    var metadata = new MockResponse(200);
                    metadata.SetContent("not-json");
                    return metadata;
                }
                throw original;
            });

            HttpRequestException thrown = Assert.ThrowsAsync<HttpRequestException>(async () =>
                await CreateClient(transport, false).GetCurrentLedgerEntryAsync(null, new RequestContext()));
            Assert.AreSame(original, thrown);
        }

        [Test]
        public async Task Failover_OrderedObjectMetadataUsesFirstUsableEndpoint()
        {
            var attemptedHosts = new List<string>();
            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.StartsWith("/failover/"))
                {
                    var metadata = new MockResponse(200);
                    metadata.SetContent(@"{ ""failoverLedgers"": [ { ""name"": ""first"" }, { ""id"": ""second"" } ] }");
                    return metadata;
                }
                attemptedHosts.Add(req.Uri.Host);
                if (req.Uri.Host.StartsWith("second"))
                {
                    var response = new MockResponse(200);
                    response.SetContent(@"{ ""contents"": ""ok"" }");
                    return response;
                }
                return new MockResponse(503);
            });

            await CreateClient(transport, false).GetCurrentLedgerEntryAsync(null, new RequestContext());

            CollectionAssert.AreEqual(
                new[] { "testledger.confidential-ledger.azure.com", "first.confidential-ledger.azure.com", "second.confidential-ledger.azure.com" },
                attemptedHosts);
        }

        [Test]
        public async Task Failover_RandomSelectionIsSafeForConcurrentCalls()
        {
            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.StartsWith("/failover/"))
                {
                    var metadata = new MockResponse(200);
                    metadata.SetContent(@"{ ""failoverLedgers"": [ ""first"", ""second"", ""third"" ] }");
                    return metadata;
                }
                if (req.Uri.Host.StartsWith("testledger"))
                {
                    return new MockResponse(503);
                }
                var response = new MockResponse(200);
                response.SetContent(@"{ ""contents"": ""ok"" }");
                return response;
            });
            ConfidentialLedgerClient client = CreateClient(
                transport,
                false,
                configure: options => options.Failover = ConfidentialLedgerClientOptions.FailoverSelection.Random);
            var calls = new List<Task<Response>>();
            for (int i = 0; i < 20; i++)
            {
                calls.Add(client.GetCurrentLedgerEntryAsync(null, new RequestContext()));
            }

            Response[] responses = await Task.WhenAll(calls);

            Assert.That(responses, Has.All.Property(nameof(Response.Status)).EqualTo(200));
        }

        [Test]
        public async Task Failover_RoutesReadToFailoverLedger_OnTransientPrimaryFailure()
        {
            const string collectionId = "c1";
            string servedFromHost = null;

            var transport = new MockTransport(req =>
            {
                string path = req.Uri.Path;
                string host = req.Uri.Host;

                if (path.StartsWith("/failover/"))
                {
                    var meta = new MockResponse(200);
                    meta.SetContent(@"{ ""ledgerId"": ""testledger"", ""failoverLedgers"": [ ""backupledger"" ] }");
                    return meta;
                }
                if (path.Contains("/current"))
                {
                    if (host.StartsWith("testledger"))
                    {
                        // Primary ledger is temporarily unavailable.
                        return new MockResponse(503);
                    }
                    // Request was routed to a failover ledger.
                    servedFromHost = host;
                    var ok = new MockResponse(200);
                    ok.SetContent($@"{{ ""collectionId"": ""{collectionId}"", ""contents"": ""v"", ""transactionId"": ""2.1"" }}");
                    return ok;
                }
                return new MockResponse(404);
            });

            var client = CreateClient(transport, enableArchivedFallback: false);

            Response response = await client.GetCurrentLedgerEntryAsync(collectionId, new RequestContext());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual("backupledger.confidential-ledger.azure.com", servedFromHost,
                "Expected the read to be routed to the failover ledger after the primary returned a transient failure.");
        }

        [Test]
        public void Failover_DoesNotRouteWritesToFailoverLedger()
        {
            int failoverMetadataCalls = 0;

            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.StartsWith("/failover/"))
                {
                    failoverMetadataCalls++;
                    var meta = new MockResponse(200);
                    meta.SetContent(@"{ ""failoverLedgers"": [ ""backupledger"" ] }");
                    return meta;
                }
                // The write (POST) consistently fails with a transient error.
                return new MockResponse(503);
            });

            var client = CreateClient(transport, enableArchivedFallback: false);

            Assert.ThrowsAsync<RequestFailedException>(async () =>
                await client.CreateLedgerEntryAsync(RequestContent.Create(new { contents = "x" }), collectionId: "c1", context: new RequestContext()));
            Assert.AreEqual(0, failoverMetadataCalls, "Writes must not trigger failover discovery or routing.");
        }

        [Test]
        [TestCase("receipt")]
        [TestCase("status")]
        [TestCase("governance")]
        [TestCase("range")]
        public void Failover_DoesNotRouteUnsupportedGetToFailoverLedger(string operation)
        {
            int failoverMetadataCalls = 0;
            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.StartsWith("/failover/"))
                {
                    failoverMetadataCalls++;
                    var meta = new MockResponse(200);
                    meta.SetContent(@"{ ""failoverLedgers"": [ ""backupledger"" ] }");
                    return meta;
                }

                return new MockResponse(503);
            });

            var client = CreateClient(transport, enableArchivedFallback: false);

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                switch (operation)
                {
                    case "receipt":
                        await client.GetReceiptAsync("2.1", new RequestContext());
                        break;
                    case "status":
                        await client.GetTransactionStatusAsync("2.1", new RequestContext());
                        break;
                    case "governance":
                        await client.GetConstitutionAsync(new RequestContext());
                        break;
                    default:
                        await foreach (BinaryData _ in client.GetLedgerEntriesAsync("c1", null, null, null, new RequestContext()))
                        {
                        }
                        break;
                }
            });

            Assert.AreEqual(0, failoverMetadataCalls, "Unsupported GET operations must remain on the primary ledger.");
        }

        [Test]
        public void Failover_AllEndpointsFail_SurfacesError()
        {
            var transport = new MockTransport(req =>
            {
                if (req.Uri.Path.StartsWith("/failover/"))
                {
                    var meta = new MockResponse(200);
                    meta.SetContent(@"{ ""failoverLedgers"": [ ""backupledger"" ] }");
                    return meta;
                }
                // Both the primary and the failover ledger are unavailable.
                return new MockResponse(503);
            });

            var client = CreateClient(transport, enableArchivedFallback: false);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetCurrentLedgerEntryAsync("c1", new RequestContext()));
            Assert.AreEqual(503, ex.Status);
        }
    }
}
