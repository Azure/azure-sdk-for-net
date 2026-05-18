// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests
{
    /// <summary>
    /// Unit tests that exercise the Web Frontend Gateway code path (<see cref="ConfidentialLedgerClientOptions.UseWebFrontend"/>).
    /// All tests use a <see cref="MockTransport"/> so no live ledger is required.
    /// </summary>
    public class ConfidentialLedgerClientWebFrontendTests : ClientTestBase
    {
        public ConfidentialLedgerClientWebFrontendTests(bool isAsync) : base(isAsync) { }

        private const string LedgerHost = "https://contoso.confidential-ledger.azure.com";
        private const string OperationId = "11111111-1111-1111-1111-111111111111";
        private const string TransactionId = "2.42";
        private const string CollectionId = "my-collection";

        private static ConfidentialLedgerClientOptions BuildOptions(MockTransport transport)
            => new ConfidentialLedgerClientOptions
            {
                UseWebFrontend = true,
                Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                Transport = transport,
            };

        private ConfidentialLedgerClient CreateClient(MockTransport transport)
            => InstrumentClient(new ConfidentialLedgerClient(
                new Uri(LedgerHost),
                new MockCredential(),
                BuildOptions(transport)));

        // W1: UseWebFrontend default is false (preserves legacy behavior).
        [Test]
        public void UseWebFrontendDefaultsToFalse()
        {
            var options = new ConfidentialLedgerClientOptions();
            Assert.IsFalse(options.UseWebFrontend);
        }

        // W2: Ctor with UseWebFrontend = true does NOT call the identity service
        // (no cert client is configured; the call would fail otherwise).
        [Test]
        public void CtorSkipsIdentityServiceBootstrapInWebFrontendMode()
        {
            // No certificate client options provided -> would throw if the ctor tried to fetch the
            // identity-service cert via the default network client. The fact that this succeeds
            // proves UseWebFrontend skips that bootstrap.
            Assert.DoesNotThrow(() =>
            {
                _ = new ConfidentialLedgerClient(
                    new Uri(LedgerHost),
                    new MockCredential(),
                    new ConfidentialLedgerClientOptions { UseWebFrontend = true });
            });
        }

        // W3: mTLS (client certificate) is rejected in Web Frontend mode.
        [Test]
        public void CtorRejectsClientCertificateInWebFrontendMode()
        {
            using var ecdsa = System.Security.Cryptography.ECDsa.Create();
            var req = new System.Security.Cryptography.X509Certificates.CertificateRequest(
                "CN=acl-webfe-test",
                ecdsa,
                System.Security.Cryptography.HashAlgorithmName.SHA256);
            using var clientCert = req.CreateSelfSigned(DateTimeOffset.UtcNow.AddMinutes(-5), DateTimeOffset.UtcNow.AddDays(1));

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                _ = new ConfidentialLedgerClient(
                    new Uri(LedgerHost),
                    clientCert,
                    new ConfidentialLedgerClientOptions { UseWebFrontend = true });
            });
            Assert.That(ex.ParamName, Is.EqualTo("clientCertificate"));
            Assert.That(ex.Message, Does.Contain(nameof(ConfidentialLedgerClientOptions.UseWebFrontend)));
        }

        // W4: 200 (synchronous commit) on POST yields an operation whose Id is the CCF transaction id;
        // polling uses /app/transactions/{txId}/status.
        [Test]
        public async Task PostLedgerEntry_SyncCommit_UsesTransactionIdPath()
        {
            var transport = new MockTransport(req =>
            {
                if (req.Method == RequestMethod.Post && req.Uri.Path.EndsWith("/app/transactions", StringComparison.Ordinal))
                {
                    var ok = new MockResponse(200);
                    ok.AddHeader(ConfidentialLedgerConstants.TransactionIdHeaderName, TransactionId);
                    ok.SetContent("{}");
                    return ok;
                }
                if (req.Method == RequestMethod.Get && req.Uri.Path.Contains($"transactions/{TransactionId}/status"))
                {
                    var s = new MockResponse(200);
                    s.SetContent("{\"state\":\"Committed\"}");
                    return s;
                }
                return new MockResponse(404);
            });

            var client = CreateClient(transport);
            var operation = await client.PostLedgerEntryAsync(WaitUntil.Started, RequestContent.Create(new { contents = "hello" }));
            Assert.AreEqual(TransactionId, operation.Id);

            await operation.WaitForCompletionResponseAsync();
            Assert.IsTrue(operation.HasCompleted);
            // Only POST + 1 status GET expected.
            Assert.AreEqual(2, transport.Requests.Count);
        }

        // W5: 202 (queued) yields an operation whose Id is the gateway operation id;
        // polling targets /app/operations/{operationId}; on "committed", Id flips to transaction id.
        [Test]
        public async Task PostLedgerEntry_Queued_TransitionsToCommitted()
        {
            int operationPolls = 0;
            var transport = new MockTransport(req =>
            {
                if (req.Method == RequestMethod.Post && req.Uri.Path.EndsWith("/app/transactions", StringComparison.Ordinal))
                {
                    var queued = new MockResponse(202);
                    queued.AddHeader(ConfidentialLedgerConstants.OperationIdHeaderName, OperationId);
                    queued.SetContent("{\"operationId\":\"" + OperationId + "\",\"status\":\"queued\"}");
                    return queued;
                }
                if (req.Method == RequestMethod.Get && req.Uri.Path.EndsWith($"/app/operations/{OperationId}", StringComparison.Ordinal))
                {
                    operationPolls++;
                    var resp = new MockResponse(200);
                    if (operationPolls < 2)
                    {
                        resp.SetContent("{\"operationId\":\"" + OperationId + "\",\"status\":\"queued\"}");
                    }
                    else
                    {
                        resp.SetContent("{\"operationId\":\"" + OperationId + "\",\"status\":\"committed\",\"transactionId\":\"" + TransactionId + "\",\"collectionId\":\"" + CollectionId + "\"}");
                    }
                    return resp;
                }
                return new MockResponse(404);
            });

            var client = CreateClient(transport);
            var operation = await client.PostLedgerEntryAsync(WaitUntil.Started, RequestContent.Create(new { contents = "queued" }));
            Assert.AreEqual(OperationId, operation.Id);
            Assert.IsFalse(operation.HasCompleted);

            await operation.WaitForCompletionResponseAsync();

            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual(TransactionId, operation.Id, "Id must flip to the CCF transaction id after the gateway reports the operation as committed.");
            Assert.AreEqual(operationPolls, 2);
            // POST + 2 operation status polls.
            Assert.AreEqual(3, transport.Requests.Count);
        }

        // W6: 202 with no header but with a body-level operationId is honored.
        [Test]
        public async Task PostLedgerEntry_Queued_OperationIdFromBody()
        {
            var transport = new MockTransport(req =>
            {
                if (req.Method == RequestMethod.Post)
                {
                    var queued = new MockResponse(202);
                    // No x-ms-webfe-operation-id header — only in body.
                    queued.SetContent("{\"operationId\":\"" + OperationId + "\",\"status\":\"queued\"}");
                    return queued;
                }
                var committed = new MockResponse(200);
                committed.SetContent("{\"operationId\":\"" + OperationId + "\",\"status\":\"committed\",\"transactionId\":\"" + TransactionId + "\"}");
                return committed;
            });

            var client = CreateClient(transport);
            var operation = await client.PostLedgerEntryAsync(WaitUntil.Started, RequestContent.Create(new { contents = "x" }));
            Assert.AreEqual(OperationId, operation.Id);
            await operation.WaitForCompletionResponseAsync();
            Assert.AreEqual(TransactionId, operation.Id);
        }

        // W7: 202 with neither header nor body operationId throws RequestFailedException.
        [Test]
        public void PostLedgerEntry_Queued_NoOperationId_Throws()
        {
            var transport = new MockTransport(req =>
            {
                var queued = new MockResponse(202);
                queued.SetContent("{}");
                return queued;
            });

            var client = CreateClient(transport);

            // Always call the Async overload — the test framework's proxy automatically
            // re-dispatches to the sync variant when IsAsync == false.
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await client.PostLedgerEntryAsync(WaitUntil.Started, RequestContent.Create(new { contents = "x" })));
            Assert.AreEqual(202, ex.Status);
            Assert.That(ex.Message, Does.Contain(ConfidentialLedgerConstants.OperationIdHeaderName));
        }

        // W8: "failed" terminal state surfaces RequestFailedException with the gateway error code in the message.
        [Test]
        public async Task PostLedgerEntry_FailedTerminalState_Throws()
        {
            var transport = new MockTransport(req =>
            {
                if (req.Method == RequestMethod.Post)
                {
                    var queued = new MockResponse(202);
                    queued.AddHeader(ConfidentialLedgerConstants.OperationIdHeaderName, OperationId);
                    queued.SetContent("{\"operationId\":\"" + OperationId + "\",\"status\":\"queued\"}");
                    return queued;
                }
                var failed = new MockResponse(200);
                failed.SetContent("{\"operationId\":\"" + OperationId + "\",\"status\":\"failed\",\"error\":{\"code\":\"MaxRetriesExceeded\",\"message\":\"too many retries\"}}");
                return failed;
            });

            var client = CreateClient(transport);
            var operation = await client.PostLedgerEntryAsync(WaitUntil.Started, RequestContent.Create(new { contents = "x" }));

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await operation.WaitForCompletionResponseAsync());
            Assert.That(ex.Message, Does.Contain("MaxRetriesExceeded"));
            Assert.That(ex.Message, Does.Contain("too many retries"));
            Assert.IsTrue(operation.HasCompleted);
        }

        // W9: 404 from /app/operations/{id} (TTL eviction) surfaces a terminal RequestFailedException
        //     describing the reconciliation requirement.
        [Test]
        public async Task PostLedgerEntry_OperationStatusNotFound_TerminalFailure()
        {
            int operationGets = 0;
            var transport = new MockTransport(req =>
            {
                if (req.Method == RequestMethod.Post)
                {
                    var queued = new MockResponse(202);
                    queued.AddHeader(ConfidentialLedgerConstants.OperationIdHeaderName, OperationId);
                    queued.SetContent("{\"operationId\":\"" + OperationId + "\",\"status\":\"queued\"}");
                    return queued;
                }
                operationGets++;
                return new MockResponse(404);
            });

            var client = CreateClient(transport);
            var operation = await client.PostLedgerEntryAsync(WaitUntil.Started, RequestContent.Create(new { contents = "x" }));

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await operation.WaitForCompletionResponseAsync());
            Assert.AreEqual(404, ex.Status);
            Assert.That(ex.Message, Does.Contain("evicted"));
            // The classifier in the standard client retries 404 once before giving up; for the
            // operations endpoint we don't want endless retry. The retry policy is configured with
            // MaxRetries = 0 in BuildOptions, so we expect a small bounded number of gets.
            Assert.IsTrue(operationGets >= 1);
            Assert.IsTrue(operation.HasCompleted);
        }

        // W10: Rehydrate path — no I/O on construction; first UpdateStatus call hits
        //      /app/operations/{operationId}.
        [Test]
        public async Task RehydratePostLedgerEntryOperation_PerformsNoInitialIO_PollsOperations()
        {
            var transport = new MockTransport(req =>
            {
                Assert.AreEqual(RequestMethod.Get, req.Method);
                Assert.That(req.Uri.Path, Does.EndWith($"/app/operations/{OperationId}"));
                var committed = new MockResponse(200);
                committed.SetContent("{\"operationId\":\"" + OperationId + "\",\"status\":\"committed\",\"transactionId\":\"" + TransactionId + "\"}");
                return committed;
            });

            var client = CreateClient(transport);
            var operation = client.RehydratePostLedgerEntryOperation(OperationId);

            // Construction is local — no requests yet.
            Assert.AreEqual(0, transport.Requests.Count);
            Assert.AreEqual(OperationId, operation.Id);
            Assert.IsFalse(operation.HasCompleted);

            await operation.WaitForCompletionResponseAsync();

            Assert.AreEqual(1, transport.Requests.Count);
            Assert.AreEqual(TransactionId, operation.Id);
            Assert.IsTrue(operation.HasCompleted);
        }

        // W11 (bonus): GetOperationStatus protocol method round-trips a queued response.
        [Test]
        public async Task GetOperationStatus_RoundTripsQueuedResponse()
        {
            string responseJson = "{\"operationId\":\"" + OperationId + "\",\"status\":\"queued\"}";
            var transport = new MockTransport(req =>
            {
                Assert.That(req.Uri.Path, Does.EndWith($"/app/operations/{OperationId}"));
                var r = new MockResponse(200);
                r.SetContent(responseJson);
                return r;
            });

            var client = CreateClient(transport);
            // Always call the Async overload — the test framework's proxy automatically
            // re-dispatches to the sync variant when IsAsync == false.
            Response response = await client.GetOperationStatusAsync(OperationId);

            Assert.AreEqual(200, response.Status);
            string body = Encoding.UTF8.GetString(response.Content.ToArray());
            Assert.That(body, Does.Contain("\"status\":\"queued\""));
        }
    }
}
