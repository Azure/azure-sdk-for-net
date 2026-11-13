// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using static Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions;

namespace Azure.Security.ConfidentialLedger.Tests
{
    /// <summary>
    /// Recorded end-to-end tests for the Confidential Ledger Gateway path
    /// (<see cref="ConfidentialLedgerClientOptions.UseLedgerGateway"/> = <c>true</c>).
    /// </summary>
    /// <remarks>
    /// <para>
    /// These recorded tests validate a <see cref="ConfidentialLedgerClientOptions.UseLedgerGateway"/> client
    /// end to end against a real gateway-fronted ledger (public TLS, no CCF identity bootstrap).
    /// <see cref="PostLedgerEntry_WebFrontendClient_Completes"/> covers a healthy gateway, which commits
    /// synchronously (HTTP 200). The other two were recorded with the underlying CCF cluster taken offline,
    /// so the gateway queues the write (HTTP 202 + <c>x-ms-webfe-operation-id</c>) and
    /// <c>GET /app/operations/{operationId}</c> reports <c>"queued"</c>:
    /// <see cref="PostLedgerEntry_Started_GetOperationStatus"/> submits and reads the queued status, and
    /// <see cref="RehydratePostLedgerEntryOperation_WhileLedgerDown_PollsQueued"/> resumes an operation from
    /// only its persisted id and confirms it stays pending while the ledger is down.
    /// </para>
    /// <para>
    /// The queued -&gt; committed transition (the operation completing once CCF recovers) depends on recovery
    /// timing that is not reproducible in a single recording; it is covered deterministically by the
    /// <c>MockTransport</c> unit tests in <see cref="ConfidentialLedgerClientLedgerGatewayTests"/>.
    /// </para>
    /// <para>
    /// To re-record: set <c>CONFIDENTIALLEDGER_WEBFE_URL</c> to the gateway endpoint (for canary the identity
    /// endpoint is <c>https://canary.identity.confidential-ledger.core.azure.com</c>, which differs from prod
    /// and is only used by the environment readiness probe - gateway mode never calls the identity service),
    /// then run <c>AZURE_TEST_MODE=Record dotnet test --filter FullyQualifiedName~WebFrontendLiveTests</c> and
    /// <c>test-proxy push -a sdk/confidentialledger/Azure.Security.ConfidentialLedger/assets.json</c>.
    /// </para>
    /// </remarks>
    public class ConfidentialLedgerClientWebFrontendLiveTests : RecordedTestBase<ConfidentialLedgerEnvironment>
    {
        private TokenCredential Credential;
        private ConfidentialLedgerClient Client;

        public ConfidentialLedgerClientWebFrontendLiveTests(bool isAsync) : base(isAsync)
        {
            // https://github.com/Azure/autorest.csharp/issues/1214
            TestDiagnostics = false;
        }

        [SetUp]
        public void Setup()
        {
            // Only run when a gateway endpoint is explicitly configured. This keeps the tests inert in the
            // live-test pipeline (which does execute [LiveOnly] tests) against a non-gateway ledger.
            if (!TestEnvironment.IsLedgerGatewayConfigured)
            {
                Assert.Ignore("Set CONFIDENTIALLEDGER_WEBFE_URL to a Ledger Gateway-fronted ledger to run the Ledger Gateway recorded tests.");
            }

            Credential = TestEnvironment.Credential;

            // In Ledger Gateway mode the gateway terminates TLS with a publicly-rooted certificate, so no
            // CCF identity-service bootstrap and no custom TLS validation certificate are required. The
            // client is instrumented so requests flow through the test-proxy for recording/playback.
            Client = InstrumentClient(
                new ConfidentialLedgerClient(
                    TestEnvironment.ConfidentialLedgerGatewayUrl,
                    credential: Credential,
                    options: InstrumentClientOptions(
                        new ConfidentialLedgerClientOptions(ServiceVersion.V2024_12_09_Preview) { UseLedgerGateway = true })));
        }

        [RecordedTest]
        public async Task PostLedgerEntry_WebFrontendClient_Completes()
        {
            // Validates a UseLedgerGateway=true client end to end against the gateway: submit with
            // WaitUntil.Completed and wait for commit. A healthy gateway commits synchronously (HTTP 200,
            // Direct polling); if the CCF cluster is unreachable it returns 202 and the operation polls
            // GET /app/operations/{operationId}. Either way Id is the CCF transaction id on completion.
            Operation operation = await Client.PostLedgerEntryAsync(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(new { contents = Recording.GenerateAssetName("webfe-entry") }));

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsNotNull(operation.Id);
            Assert.AreEqual((int)HttpStatusCode.OK, operation.GetRawResponse().Status);
        }

        [RecordedTest]
        public async Task PostLedgerEntry_Started_GetOperationStatus()
        {
            // WaitUntil.Started returns immediately after submission. The returned Id is the gateway
            // operation id (when queued), which can be polled directly via GetOperationStatus.
            Operation operation = await Client.PostLedgerEntryAsync(
                waitUntil: WaitUntil.Started,
                RequestContent.Create(new { contents = Recording.GenerateAssetName("webfe-entry") }));

            Assert.IsNotNull(operation.Id);

            Response status = await Client.GetOperationStatusAsync(operation.Id);
            string body = new StreamReader(status.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, status.Status);
            Assert.That(body, Does.Contain("status"));
        }

        [RecordedTest]
        public async Task RehydratePostLedgerEntryOperation_WhileLedgerDown_PollsQueued()
        {
            // Submit while CCF is unreachable: the gateway queues the write and returns an operation id
            // (HTTP 202). Capture only that id, as a caller would persist it across a process restart.
            Operation submitted = await Client.PostLedgerEntryAsync(
                waitUntil: WaitUntil.Started,
                RequestContent.Create(new { contents = Recording.GenerateAssetName("webfe-entry") }));

            string operationId = submitted.Id;
            Assert.IsNotNull(operationId);

            // Rehydrate from only the persisted id - no network I/O until the first poll.
            Operation resumed = Client.RehydratePostLedgerEntryOperation(operationId);
            Assert.IsFalse(resumed.HasCompleted);

            // First poll hits GET /app/operations/{operationId}. While the ledger is down the operation
            // remains queued, so the operation stays pending and Id is still the gateway operation id.
            // (Once CCF recovers a later poll would report "committed" and flip Id to the transaction id.)
            await resumed.UpdateStatusAsync();
            Assert.IsFalse(resumed.HasCompleted);
            Assert.AreEqual(operationId, resumed.Id);
        }

        [RecordedTest]
        public async Task RehydratePostLedgerEntryOperation_ResumesToCommitted()
        {
            // Resume an operation that was queued while CCF was offline (its id was persisted by the caller).
            // Once the ledger recovers the gateway commits the queued write, so polling the id drives the
            // rehydrated operation to completion and Id flips from the gateway operation id to the CCF
            // transaction id. Requires CONFIDENTIALLEDGER_WEBFE_OPERATION_ID to be a now-recovered queued id.
            string operationId = TestEnvironment.LedgerGatewayQueuedOperationId;
            if (string.IsNullOrEmpty(operationId))
            {
                Assert.Ignore("Set CONFIDENTIALLEDGER_WEBFE_OPERATION_ID to an operation id that was queued while the ledger was down (and has since recovered) to record/replay this test.");
            }

            Operation resumed = Client.RehydratePostLedgerEntryOperation(operationId);
            await resumed.WaitForCompletionResponseAsync();

            Assert.IsTrue(resumed.HasCompleted);
            Assert.AreNotEqual(operationId, resumed.Id);
        }
    }
}
