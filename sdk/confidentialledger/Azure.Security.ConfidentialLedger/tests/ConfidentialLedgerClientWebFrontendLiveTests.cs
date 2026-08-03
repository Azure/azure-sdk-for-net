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
    /// Recorded end-to-end tests for the Confidential Ledger Web Frontend Gateway path
    /// (<see cref="ConfidentialLedgerClientOptions.UseWebFrontend"/> = <c>true</c>).
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="PostLedgerEntry_WebFrontendClient_Completes"/> is a recorded test that validates a
    /// <see cref="ConfidentialLedgerClientOptions.UseWebFrontend"/> client end to end against a real
    /// gateway-fronted ledger (public TLS, no CCF identity bootstrap, submit + wait for commit). Under
    /// healthy conditions the gateway commits synchronously (HTTP 200); the client handles 200 and 202
    /// identically from the caller's perspective.
    /// </para>
    /// <para>
    /// The remaining tests are <see cref="LiveOnlyAttribute"/> because they exercise the queued
    /// (HTTP 202 + <c>operationId</c>) path, which the gateway only takes when the underlying CCF cluster
    /// is temporarily unreachable - a condition that cannot be reproduced on demand for a recording. That
    /// path is covered deterministically by the <c>MockTransport</c> unit tests in
    /// <see cref="ConfidentialLedgerClientWebFrontendTests"/>.
    /// </para>
    /// <para>
    /// To record against a gateway ledger: set <c>CONFIDENTIALLEDGER_WEBFE_URL</c> to the gateway endpoint.
    /// For canary the identity endpoint is <c>https://canary.identity.confidential-ledger.core.azure.com</c>
    /// (it differs from prod and is only used by the environment readiness probe - WebFE mode never calls the
    /// identity service). Then run
    /// <c>AZURE_TEST_MODE=Record dotnet test --filter FullyQualifiedName~WebFrontendLiveTests</c> and
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
            if (!TestEnvironment.IsWebFrontendConfigured)
            {
                Assert.Ignore("Set CONFIDENTIALLEDGER_WEBFE_URL to a Web Frontend Gateway-fronted ledger to run the WebFE recorded tests.");
            }

            Credential = TestEnvironment.Credential;

            // In Web Frontend mode the gateway terminates TLS with a publicly-rooted certificate, so no
            // CCF identity-service bootstrap and no custom TLS validation certificate are required. The
            // client is instrumented so requests flow through the test-proxy for recording/playback.
            Client = InstrumentClient(
                new ConfidentialLedgerClient(
                    TestEnvironment.ConfidentialLedgerWebFrontendUrl,
                    credential: Credential,
                    options: InstrumentClientOptions(
                        new ConfidentialLedgerClientOptions(ServiceVersion.V2024_12_09_Preview) { UseWebFrontend = true })));
        }

        [RecordedTest]
        public async Task PostLedgerEntry_WebFrontendClient_Completes()
        {
            // Validates a UseWebFrontend=true client end to end against the gateway: submit with
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
        [LiveOnly]
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
        [LiveOnly]
        public async Task RehydratePostLedgerEntryOperation_ResumesPolling()
        {
            // Submit and capture only the operation id, then resume completion through a freshly
            // rehydrated operation - the cross-process resume scenario RehydratePostLedgerEntryOperation
            // is designed for.
            Operation submitted = await Client.PostLedgerEntryAsync(
                waitUntil: WaitUntil.Started,
                RequestContent.Create(new { contents = Recording.GenerateAssetName("webfe-entry") }));

            string operationId = submitted.Id;
            Assert.IsNotNull(operationId);

            Operation resumed = Client.RehydratePostLedgerEntryOperation(operationId);
            await resumed.WaitForCompletionResponseAsync();

            Assert.IsTrue(resumed.HasCompleted);
            Assert.IsNotNull(resumed.Id);
        }
    }
}
