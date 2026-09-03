// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Security.ConfidentialLedger.Certificate;
using NUnit.Framework;
using static Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions;

namespace Azure.Security.ConfidentialLedger.Tests
{
    /// <summary>
    /// Recorded end-to-end coverage for collection-pruning compatibility.
    /// </summary>
    /// <remarks>
    /// The recording captures the service's live-current 404 followed by the SDK's historical range
    /// query and synthesized 200 response. Playback therefore detects regressions in the automatic
    /// fallback without requiring CI to create enough collections to trigger pruning.
    /// </remarks>
    public class ConfidentialLedgerPruningLiveTests : RecordedTestBase<ConfidentialLedgerEnvironment>
    {
        private ConfidentialLedgerClient _client;

        public ConfidentialLedgerPruningLiveTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
            BodyRegexSanitizers.Add(
                new BodyRegexSanitizer("[^\\r](?<break>\\n)")
                {
                    GroupForReplace = "break",
                    Value = "\r\n"
                });
        }

        [SetUp]
        public async Task Setup()
        {
            if (!TestEnvironment.IsPruningLedgerConfigured)
            {
                Assert.Ignore(
                    "Set CONFIDENTIALLEDGER_PRUNING_URL, CONFIDENTIALLEDGER_PRUNING_IDENTITY_URL, " +
                    "and CONFIDENTIALLEDGER_PRUNED_COLLECTION_ID to record the pruning fallback test.");
            }

            var identityClient = new ConfidentialLedgerCertificateClient(
                TestEnvironment.ConfidentialLedgerPruningIdentityUrl,
                InstrumentClientOptions(new ConfidentialLedgerCertificateClientOptions()));
            (System.Security.Cryptography.X509Certificates.X509Certificate2 Cert, string PEM) serviceCert =
                ConfidentialLedgerClient.GetIdentityServerTlsCert(
                    TestEnvironment.ConfidentialLedgerPruningUrl,
                    new ConfidentialLedgerCertificateClientOptions(),
                    identityClient);

            if (Mode != RecordedTestMode.Playback)
            {
                await SetProxyOptionsAsync(
                    new ProxyOptions
                    {
                        Transport = new ProxyOptionsTransport
                        {
                            TLSValidationCert = serviceCert.PEM,
                            AllowAutoRedirect = true
                        }
                    });
            }

            var options = InstrumentClientOptions(
                new ConfidentialLedgerClientOptions(ServiceVersion.V2024_12_09_Preview)
                {
                    CertificateEndpoint = TestEnvironment.ConfidentialLedgerPruningIdentityUrl,
                    EnableArchivedCollectionFallback = true,
                });

            TokenCredential credential = TestEnvironment.Credential;
            string accessToken = Environment.GetEnvironmentVariable("CONFIDENTIALLEDGER_PRUNING_ACCESS_TOKEN");
            if (Mode != RecordedTestMode.Playback && !string.IsNullOrEmpty(accessToken))
            {
                credential = new RecordingTokenCredential(accessToken);
            }

            _client = InstrumentClient(
                new ConfidentialLedgerClient(
                    TestEnvironment.ConfidentialLedgerPruningUrl,
                    credential: credential,
                    clientCertificate: null,
                    ledgerOptions: options,
                    identityServiceCert: serviceCert.Cert));
        }

        [RecordedTest]
        public async Task GetCurrentLedgerEntry_ReturnsArchivedEntryWithoutConfiguration()
        {
            Response response = await _client.GetCurrentLedgerEntryAsync(
                TestEnvironment.ConfidentialLedgerPrunedCollectionId,
                new RequestContext());

            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
            using JsonDocument document = JsonDocument.Parse(response.Content);
            Assert.AreEqual(
                TestEnvironment.ConfidentialLedgerPrunedCollectionId,
                document.RootElement.GetProperty("collectionId").GetString());
            Assert.That(document.RootElement.GetProperty("contents").GetString(), Is.Not.Empty);
            Assert.That(document.RootElement.GetProperty("transactionId").GetString(), Is.Not.Empty);
        }

        private sealed class RecordingTokenCredential : TokenCredential
        {
            private readonly AccessToken _token;

            public RecordingTokenCredential(string token)
            {
                _token = new AccessToken(token, DateTimeOffset.UtcNow.AddMinutes(30));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) => _token;

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new ValueTask<AccessToken>(_token);
        }
    }
}
