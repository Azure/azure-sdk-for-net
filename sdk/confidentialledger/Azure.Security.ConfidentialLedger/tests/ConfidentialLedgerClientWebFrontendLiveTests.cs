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
    /// These tests are currently marked <see cref="LiveOnlyAttribute"/> because they require a
    /// gateway-fronted ledger to record against and no recordings exist yet. To bring them online:
    /// <list type="number">
    ///   <item><description>Point <c>CONFIDENTIALLEDGER_WEBFE_URL</c> (or <c>CONFIDENTIALLEDGER_URL</c>) at a
    ///   Web Frontend Gateway ledger, and set <c>CONFIDENTIALLEDGER_IDENTITY_URL</c> and
    ///   <c>CONFIDENTIALLEDGER_CLIENT_OBJECTID</c>.</description></item>
    ///   <item><description>Record: <c>AZURE_TEST_MODE=Record dotnet test --filter FullyQualifiedName~WebFrontendLiveTests</c>.</description></item>
    ///   <item><description>Push the recordings: <c>test-proxy push -a sdk/confidentialledger/Azure.Security.ConfidentialLedger/assets.json</c>
    ///   (updates the <c>assets.json</c> tag).</description></item>
    ///   <item><description>Remove the <see cref="LiveOnlyAttribute"/> so the tests replay in CI (Playback).</description></item>
    /// </list>
    /// Until then, the WebFE code path is covered by the deterministic <c>MockTransport</c> unit tests in
    /// <see cref="ConfidentialLedgerClientWebFrontendTests"/>.
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
        [LiveOnly]
        public async Task PostLedgerEntry_QueuedSubmission_Completes()
        {
            // WaitUntil.Completed drives the gateway's queued-write flow end to end: submit -> 202 (or 200)
            // -> poll GET /app/operations/{operationId} -> committed. On completion the operation's Id is
            // the underlying CCF transaction id.
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
