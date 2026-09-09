// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Security.ConfidentialLedger.Certificate;
using NUnit.Framework;
using static Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions;

namespace Azure.Security.ConfidentialLedger.Tests
{
    /// <summary>
    /// Recorded end-to-end coverage for cross-ledger read failover.
    /// </summary>
    /// <remarks>
    /// A test transport returns a deterministic 503 for the primary data-plane request. Identity Service
    /// discovery, secondary certificate lookup, endpoint-bound TLS validation, authentication, and the
    /// secondary data-plane request all use the real staging services while recording.
    /// </remarks>
    public class ConfidentialLedgerFailoverLiveTests : RecordedTestBase<ConfidentialLedgerEnvironment>
    {
        private FailPrimaryTransport _failPrimaryTransport;
        private ConfidentialLedgerClient _client;

        public ConfidentialLedgerFailoverLiveTests(bool isAsync) : base(isAsync)
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
            if (!TestEnvironment.IsFailoverLedgerConfigured)
            {
                Assert.Ignore(
                    "Set CONFIDENTIALLEDGER_FAILOVER_PRIMARY_URL, CONFIDENTIALLEDGER_FAILOVER_SECONDARY_URL, " +
                    "CONFIDENTIALLEDGER_FAILOVER_IDENTITY_URL, CONFIDENTIALLEDGER_FAILOVER_COLLECTION_ID, and " +
                    "CONFIDENTIALLEDGER_FAILOVER_EXPECTED_CONTENT to record the cross-ledger failover test.");
            }

            var identityClient = new ConfidentialLedgerCertificateClient(
                TestEnvironment.ConfidentialLedgerFailoverIdentityUrl,
                InstrumentClientOptions(new ConfidentialLedgerCertificateClientOptions()));
            (System.Security.Cryptography.X509Certificates.X509Certificate2 Cert, string PEM) primaryCert =
                ConfidentialLedgerClient.GetIdentityServerTlsCert(
                    TestEnvironment.ConfidentialLedgerFailoverPrimaryUrl,
                    new ConfidentialLedgerCertificateClientOptions(),
                    identityClient);
            (System.Security.Cryptography.X509Certificates.X509Certificate2 Cert, string PEM) secondaryCert =
                ConfidentialLedgerClient.GetIdentityServerTlsCert(
                    TestEnvironment.ConfidentialLedgerFailoverSecondaryUrl,
                    new ConfidentialLedgerCertificateClientOptions(),
                    identityClient);

            if (Mode != RecordedTestMode.Playback)
            {
                string publicRoot = string.Empty;
                string publicRootBase64 = Environment.GetEnvironmentVariable("CONFIDENTIALLEDGER_FAILOVER_PUBLIC_ROOT_CERT_BASE64");
                Assert.That(
                    publicRootBase64,
                    Is.Not.Empty,
                    "Set CONFIDENTIALLEDGER_FAILOVER_PUBLIC_ROOT_CERT_BASE64 to the base64-encoded Identity Service public root certificate when recording.");
                publicRoot = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(publicRootBase64));
                await SetProxyOptionsAsync(
                    new ProxyOptions
                    {
                        Transport = new ProxyOptionsTransport
                        {
                            TLSValidationCert = primaryCert.PEM + secondaryCert.PEM + publicRoot,
                            AllowAutoRedirect = true
                        }
                    });
            }

            var options = InstrumentClientOptions(
                new ConfidentialLedgerClientOptions(ServiceVersion.V2024_12_09_Preview)
                {
                    CertificateEndpoint = TestEnvironment.ConfidentialLedgerFailoverIdentityUrl
                });
            options.Retry.MaxRetries = 0;
            _failPrimaryTransport = new FailPrimaryTransport(
                options.Transport,
                TestEnvironment.ConfidentialLedgerFailoverPrimaryUrl.Host);
            options.Transport = _failPrimaryTransport;

            TokenCredential credential = TestEnvironment.Credential;
            string accessToken = Environment.GetEnvironmentVariable("CONFIDENTIALLEDGER_FAILOVER_ACCESS_TOKEN");
            if (Mode != RecordedTestMode.Playback && !string.IsNullOrEmpty(accessToken))
            {
                credential = new RecordingTokenCredential(accessToken);
            }

            _client = InstrumentClient(
                new ConfidentialLedgerClient(
                    TestEnvironment.ConfidentialLedgerFailoverPrimaryUrl,
                    credential: credential,
                    clientCertificate: null,
                    ledgerOptions: options,
                    identityServiceCert: primaryCert.Cert));
        }

        [RecordedTest]
        public async Task GetCurrentLedgerEntry_FailsOverToSecondaryLedger()
        {
            Response response = await _client.GetCurrentLedgerEntryAsync(
                TestEnvironment.ConfidentialLedgerFailoverCollectionId,
                new RequestContext());

            Assert.AreEqual(1, _failPrimaryTransport.FailureCount);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
            using JsonDocument document = JsonDocument.Parse(response.Content);
            Assert.AreEqual(
                TestEnvironment.ConfidentialLedgerFailoverCollectionId,
                document.RootElement.GetProperty("collectionId").GetString());
            Assert.AreEqual(
                TestEnvironment.ConfidentialLedgerFailoverExpectedContent,
                document.RootElement.GetProperty("contents").GetString());
            Assert.That(document.RootElement.GetProperty("transactionId").GetString(), Is.Not.Empty);
        }

        private sealed class FailPrimaryTransport : HttpPipelineTransport
        {
            private readonly HttpPipelineTransport _innerTransport;
            private readonly string _primaryHost;
            private int _failureCount;

            public FailPrimaryTransport(HttpPipelineTransport innerTransport, string primaryHost)
            {
                _innerTransport = innerTransport;
                _primaryHost = primaryHost;
            }

            public int FailureCount => _failureCount;

            public override Request CreateRequest() => _innerTransport.CreateRequest();

            public override void Process(HttpMessage message)
            {
                if (ShouldFail(message))
                {
                    message.Response = new MockResponse((int)HttpStatusCode.ServiceUnavailable);
                    return;
                }

                _innerTransport.Process(message);
            }

            public override async ValueTask ProcessAsync(HttpMessage message)
            {
                if (ShouldFail(message))
                {
                    message.Response = new MockResponse((int)HttpStatusCode.ServiceUnavailable);
                    return;
                }

                await _innerTransport.ProcessAsync(message).ConfigureAwait(false);
            }

            private bool ShouldFail(HttpMessage message)
            {
                if (!string.Equals(message.Request.Uri.Host, _primaryHost, StringComparison.OrdinalIgnoreCase) ||
                    !message.Request.Uri.Path.Contains("/app/transactions/current"))
                {
                    return false;
                }

                Interlocked.Increment(ref _failureCount);
                return true;
            }
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
